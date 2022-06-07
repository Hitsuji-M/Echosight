using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerer : MonoBehaviour
{
    private GameObject _door;
    private Animator _animator;
    private static readonly int ButtonPress = Animator.StringToHash("ButtonPress");

    // Start is called before the first frame update
    private void Start()
    {
        _door = GameObject.FindWithTag("final_door");
        _animator = _door.GetComponent<Animator>();
    }
    
    /*
    private void OnMouseDown()
    {
        TriggerDoor();
    }
    */

    private void TriggerDoor()
    {
        _animator.SetTrigger(ButtonPress);
    }
}
