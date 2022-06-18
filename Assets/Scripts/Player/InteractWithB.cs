using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SUPERCharacter;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithB : MonoBehaviour ,IInteractable
{
    // Script on button to trigger the door opening animation
    [SerializeField] AudioClip _clip;
    private GameObject _btnDoor;
    private DoorAnimator _doorAnimator;
    private GameObject _waveCtrl;
    private bool _isActivated;
    
    /// <summary>
    /// This function finds the door object and the wave controller object, and sets the door to not be activated
    /// </summary>
    void Start()
    {
        _btnDoor = GameObject.FindWithTag("final_door");
        _doorAnimator = _btnDoor.GetComponent<DoorAnimator>();
        _waveCtrl = GameObject.Find("WaveController");
        _isActivated = false;
    }

    /// <summary>
    /// If the door is not activated, trigger the door animation, spawn a wave shader expansion, play a sound, and set the
    /// door to activated
    /// </summary>
    /// <returns>
    /// A boolean value.
    /// </returns>
    public bool Interact()
    {
        if (!_isActivated)
        {
            _doorAnimator.TriggerDoor();
            _waveCtrl.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x,transform.position.y, transform.position.z), 4);
            GetComponent<AudioSource>().PlayOneShot(_clip);
            _isActivated = !_isActivated;
        }
        return true;
    }
}
