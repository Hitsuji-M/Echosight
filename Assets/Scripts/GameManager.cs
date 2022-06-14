using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    private GameObject _canvas;
    private AudioRegister _senseLabSentences;
    private AudioSource _speakers;

    // Start is called before the first frame update
    void Start()
    {
        _playing = true;
        _canvas = GameObject.Find("Canvas");
        _speakers = GetComponent<AudioSource>();
        _senseLabSentences = GetComponent<AudioRegister>();
        
        _canvas.SetActive(false);
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
    public void PlayAudio(string soundName)
    {
        _speakers.PlayOneShot(_senseLabSentences.GetSound(soundName));
    }
    
}
