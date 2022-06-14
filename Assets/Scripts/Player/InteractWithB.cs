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
    private GameObject _btnDoor;
    private DoorAnimator _doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _btnDoor = GameObject.FindWithTag("final_door");
        _doorAnimator = _btnDoor.GetComponent<DoorAnimator>();
    }

    public bool Interact()
    {
        _doorAnimator.TriggerDoor();
        return true;
    }
}
