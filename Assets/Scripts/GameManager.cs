using System;
using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    private GameObject _canvas;
    private GameObject _btn;
    private AudioRegister _senseLabSentences;
    private AudioSource _speakers;
    private SUPERCharacterAIO _scc;
    private TakeItem _takeItem;

    // Start is called before the first frame update
    void Awake()
    {
        _playing = true;
        _canvas = GameObject.Find("Canvas");
        _btn = GameObject.Find("Btn");
        _speakers = GetComponent<AudioSource>();
        _senseLabSentences = GetComponent<AudioRegister>();
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        _scc = player.GetComponent<SUPERCharacterAIO>();
        _takeItem = player.GetComponent<TakeItem>();
        
        _canvas.SetActive(false);
        SetPlayerStatus(true);
        SetTakeStatus(false);
        SetBtnStatus(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UpdateUI();
        }
    }

    /**
     * Hide or show the UserInterface to the player and  set the cursor movement to lock or confined
     */
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

    /**
     * Set the cursor movement to locked when the UI is shown or locked otherwise
     */
    public void SetCursorMvmt(bool status)
    {
        Cursor.lockState = status ? CursorLockMode.Locked : CursorLockMode.Confined;
    }

    /**
     * Set the timeScale to stop or resume the game
     */
    public void SetTimeScale(bool status)
    {
        Time.timeScale = (status ? 1 : 0);
    }

    /**
     * Play the first audio that welcomes the player
     */
    public AudioClip PlayAudio(string soundName)
    {
        AudioClip clip = _senseLabSentences.GetSound(soundName);
        _speakers.PlayOneShot(clip);
        return clip;
    }
    
    public void SetPlayerStatus(bool inPause)
    {
        if (inPause) {
            _scc.PausePlayer(PauseModes.BlockInputOnly);
        } else {
            _scc.UnpausePlayer();
        }
    }

    public void SetTakeStatus(bool canGrab)
    {
        _takeItem.SetGrabStatus(canGrab);
    }

    public void SetBtnStatus(bool isActive)
    {
        _btn.SetActive(isActive);
    }
}
