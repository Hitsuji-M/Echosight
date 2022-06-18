using SUPERCharacter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _canvas;
    private GameObject _btn;
    private AudioRegister _senseLabSentences;
    private AudioSource _speakers;
    private SUPERCharacterAIO _scc;
    private TakeItem _takeItem;
    private bool _playing;
    private bool _playText;

    
    /// <summary>
    /// It finds the canvas, button, speakers, and audio register.
    /// </summary>
    void Awake()
    {
        _canvas = GameObject.Find("Canvas");
        _btn = GameObject.Find("Btn");
        _speakers = GetComponent<AudioSource>();
        _senseLabSentences = GetComponent<AudioRegister>();
        _playing = true;
    }

    /// <summary>
    /// Load the the choice of the player to skip the game or not
    /// </summary>
    private void OnEnable()
    {
        _playText = PlayerPrefs.GetInt("play_text") >= 1;
    }

    /// <summary>
    /// The function is called when the game starts. It finds the player object and gets the components of the player
    /// object. It then sets the canvas to inactive, sets the player status to true, sets the take status to false, sets the
    /// button status to false, and if the play text is false, it sets the status sound to 6
    /// </summary>
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        _scc = player.GetComponent<SUPERCharacterAIO>();
        _takeItem = player.GetComponent<TakeItem>();
        _canvas.SetActive(false);

        SetPlayerStatus(_playText);
        SetTakeStatus(!_playText);
        SetBtnStatus(!_playText);

        if (!_playText) {
            GetComponent<Events>().SetStatusSound(6);
        }
    }
    
    /// <summary>
    /// If the user presses the escape key, then update the UI
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UpdateUI();
        }
    }
    
    /// <summary>
    /// It toggles the game state between playing and paused.
    /// </summary>
    public void UpdateUI()
    {
        _playing = !_playing;
        _canvas.SetActive(!_playing);

        if (!_playing) {
            _speakers.Pause();
        } else {
            _speakers.UnPause();
        }
        
        SetCursorMvmt(_playing);
        SetTimeScale(_playing);
    }

    /// <summary>
    /// If the status is true, the cursor is locked to the center of the screen. If the status is false, the cursor is
    /// confined to the game window
    /// </summary>
    /// <param name="status">true = locked, false = confined</param>
    public void SetCursorMvmt(bool status)
    {
        Cursor.lockState = status ? CursorLockMode.Locked : CursorLockMode.Confined;
    }
    
    /// <summary>
    /// If the status is true, set the time scale to 1, otherwise set it to 0
    /// </summary>
    /// <param name="status">true or false</param>
    public void SetTimeScale(bool status)
    {
        Time.timeScale = (status ? 1 : 0);
    }
    
    /// <summary>
    /// > Play the sound with the name `soundName` from the `_senseLabSentences` object
    /// </summary>
    /// <param name="soundName">The name of the sound you want to play.</param>
    /// <returns>
    /// The AudioClip that was played.
    /// </returns>
    public AudioClip PlayAudio(string soundName)
    {
        AudioClip clip = _senseLabSentences.GetSound(soundName);
        _speakers.PlayOneShot(clip);
        return clip;
    }
    
    /// <summary>
    /// If the player is in pause mode, then unpause the player. If the player is not in pause mode, then pause the player
    /// </summary>
    /// <param name="inPause">true if the player is in pause, false if the player is unpaused.</param>
    public void SetPlayerStatus(bool inPause)
    {
        if (inPause) {
            _scc.PausePlayer(PauseModes.BlockInputOnly);
        } else {
            _scc.UnpausePlayer();
        }
    }

    /// <summary>
    /// This function set the authorization to grab an object of the player
    /// It's called by Events script when the third dialog
    /// </summary>
    /// <param name="canGrab">true or false</param>
    public void SetTakeStatus(bool canGrab)
    {
        _takeItem.SetGrabStatus(canGrab);
    }

    /// <summary>
    /// This function sets the status of the button to active or inactive
    /// </summary>
    /// <param name="isActive">Whether the button is active or not.</param>
    public void SetBtnStatus(bool isActive)
    {
        _btn.SetActive(isActive);
    }
}
