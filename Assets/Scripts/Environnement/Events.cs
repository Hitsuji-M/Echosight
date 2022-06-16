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

    // Start is called before the first frame update
    void Start()
    {
        _gm = GetComponent<GameManager>();
        _statusSound = 0;
        _check = true;
    }

    // Update is called once per frame
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

    void CheckSound()
    {
        switch (_statusSound)
        {
            case 0:
                LaunchAudio("intro_echosight");
                break;

            case 1:
                LaunchAudio("1_intro");
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
        }
    }

    void LaunchAudio(string soundName)
    {
        _check = false;
        AudioClip clip = _gm.PlayAudio(soundName);
        _duration = clip.length;
        StartCoroutine(WaitEndSound());
    }
    
    IEnumerator WaitEndSound()
    {
        yield return new WaitForSeconds(_duration);
        _check = true;
        _statusSound++;
        Enable();
    }

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
                _gm.SetInteractionStatus(true);
                break;
        }
    }

    public void AddFootStep()
    {
        _nbSteps++;
    }

    public void SetJump(bool status)
    {
        _hasJumped = status;
    }

    public void SetTake(bool status)
    {
        _itemTaken = status;
    }

    public void SetDrop(bool status)
    {
        _itemDropped = status;
    }

    public void SetThrow(bool status)
    {
        _itemThrow = status;
    }

    public void SetWin(bool status)
    {
        _hasWon = status;
    }
}
