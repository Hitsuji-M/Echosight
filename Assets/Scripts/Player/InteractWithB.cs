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
    private bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        _btnDoor = GameObject.FindWithTag("final_door");
        _doorAnimator = _btnDoor.GetComponent<DoorAnimator>();
        _waveCtrl = GameObject.Find("WaveController");
        isActivated = false;

    }

    public bool Interact()
    {
        if (!isActivated)
        {
            _doorAnimator.TriggerDoor();
            _waveCtrl.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x,transform.position.y, transform.position.z), 4);
            GetComponent<AudioSource>().PlayOneShot(_clip);
            isActivated = !isActivated;
            GameObject.Find("Player").GetComponent<TipsMessage>().SetStatusTrue("interact");
        }
        return true;
    }
}
