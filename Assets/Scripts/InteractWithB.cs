using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithB : MonoBehaviour
{
    private Camera _camera;
    private DoorAnimator _doorAnimator;
    public GameObject btnDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _doorAnimator = btnDoor.GetComponent<DoorAnimator>();
    }

    private void OnMouseDown()
    {

        _doorAnimator.TriggerDoor();
    }
}
