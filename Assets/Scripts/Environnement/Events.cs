using System;
using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using UnityEngine;

public class Events : MonoBehaviour
{
    private int _nbSteps = 0;
    private bool _hasJumped = false;
    private bool _ctrlStatus = false;

    private bool _itemTaken = false;
    private bool _itemDropped = false;
    private bool _itemThrow = false;
    private bool _takeStatus = false;

    private bool _hasWon = false;

    private GameManager _gm;
    private SUPERCharacterAIO _scc;
    private float _duration;
    private bool _check;
    private int _statusSound;

    /// <summary>
    /// This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only)
    /// </summary>
    private void Awake()
    {
        _statusSound = 0;
        _check = true;
    }

    /// <summary>
    /// Loads the GameManager component
    /// </summary>
    void Start()
    {
        _gm = GetComponent<GameManager>();
    }
    
    /// <summary>
    /// > If no sound is played then check if there's one to play
    /// > Else check if the player finished the movement tutorial
    /// > If the player has taken an item, dropped it, and thrown it, then the player has completed the tutorial
    /// </summary>
    /// <returns>
    /// The _takeStatus variable is being returned.
    /// </returns>
    void Update()
    {
        if (_check) CheckSound();
            
        if (_takeStatus) return;

        if (!_ctrlStatus) {
            _ctrlStatus = _nbSteps > 2 && _hasJumped;
            return;
        }
        
        _takeStatus = _itemTaken && _itemDropped && _itemThrow;
    }

    /// <summary>
    /// It checks the status of the game and plays the corresponding sound
    /// </summary>
    void CheckSound()
    {
        switch (_statusSound)
        {
            case 0:
                LaunchAudio("intro_echosight");
                break;

            case 1:
                LaunchAudio("1_intro");
                GameObject.Find("Player").GetComponent<TipsMessage>()?.ShowMoveTip();
                break;

            case 2:
                if (_ctrlStatus) LaunchAudio("2_some_steps");
                break;
            
            case 3:
                if (_takeStatus) LaunchAudio("3_lance_objet");
                break;
            
            case 4:
                if (_hasWon) LaunchAudio("4_fin");
                break;
            
            case 6:
                GameObject.Find("Player").GetComponent<TipsMessage>()?.ShowMoveTip(1);
                _statusSound++;
                break;
        }
    }

    /// <summary>
    /// It plays the audio clip, gets its duration, and starts a coroutine that waits for the duration of the clip to end
    /// </summary>
    /// <param name="soundName">The name of the sound to play.</param>
    void LaunchAudio(string soundName)
    {
        _check = false;
        AudioClip clip = _gm.PlayAudio(soundName);
        _duration = clip.length;
        StartCoroutine(WaitEndSound());
    }
    
    /// <summary>
    /// It waits for the duration of the sound to finish playing, then it sets the check to true, increments the
    /// statusSound, and calls the Enable function
    /// </summary>
    IEnumerator WaitEndSound()
    {
        yield return new WaitForSeconds(_duration);
        _check = true;
        _statusSound++;
        Enable();
    }

    /// <summary>
    /// Enable player status during the tutorial (allows to move, take objects or interact)
    /// </summary>
    void Enable()
    {
        switch (_statusSound)
        {
            case 2:
                _gm.SetPlayerStatus(false);
                break;
            
            case 3:
                _gm.SetTakeStatus(true);
                break;
            
            case 4:
                _gm.SetBtnStatus(true);
                break;
        }
    }

    /// <summary>
    /// It increments the number of steps by one
    /// </summary>
    public void AddFootStep()
    {
        _nbSteps++;
    }

    /// <summary>
    /// This function sets the value of the private variable _hasJumped to the value of the parameter status
    /// </summary>
    /// <param name="status">This is a boolean value that will be used to set the _hasJumped variable.</param>
    public void SetJump(bool status)
    {
        _hasJumped = status;
    }

    /// <summary>
    /// This function sets the status if the player taken an item 
    /// </summary>
    /// <param name="status">true or false</param>
    public void SetTake(bool status)
    {
        _itemTaken = status;
    }

    /// <summary>
    /// This function sets the status if the player dropped an item to true or false
    /// </summary>
    /// <param name="status">This is a boolean value that will be used to set the _itemDropped variable.</param>
    public void SetDrop(bool status)
    {
        _itemDropped = status;
    }

    /// <summary>
    /// This function sets the _itemThrow variable to the status variable
    /// </summary>
    /// <param name="status">This is a boolean value that determines whether the player can throw the item or not.</param>
    public void SetThrow(bool status)
    {
        _itemThrow = status;
    }

    /// <summary>
    /// This function sets the value of the private variable _hasWon to the value of the parameter status
    /// </summary>
    /// <param name="status">true if the player has won, false if the player has lost.</param>
    public void SetWin(bool status)
    {
        _hasWon = status;
    }

    /// <summary>
    /// This function sets the status of the sound
    /// </summary>
    /// <param name="status">The status of the sound.</param>
    public void SetStatusSound(int status)
    {
        _statusSound = status;
    }
}
