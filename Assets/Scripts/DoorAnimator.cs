using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private GameObject _door;
    private Animator _animator;
    private bool _isOpen;
    private static readonly int ButtonPress = Animator.StringToHash("ButtonPress");

    // Start is called before the first frame update
    private void Start()
    {
        this._isOpen = false;
        _door = GameObject.FindWithTag("final_door");
        _animator = _door.GetComponent<Animator>();
    }

    public void TriggerDoor()
    {
        _animator.SetTrigger(ButtonPress);
    }

    public bool IsOpen => _isOpen;

    public void doorOpen()
    {
        this._isOpen = true;
        Debug.Log("felicitation vous avez fini le niveau à "+Time.time);
    }
}