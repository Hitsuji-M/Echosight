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
    private WaveShaderExpansion _ctrl;

    // Start is called before the first frame update
    private void Start()
    {
        this._isOpen = false;
        _door = GameObject.FindWithTag("final_door");
        _animator = _door.GetComponent<Animator>();
        _ctrl = GameObject.Find("WaveController").GetComponent<WaveShaderExpansion>();
    }

    public void TriggerDoor()
    {
        if(!_isOpen)
        {
            _animator.SetTrigger(ButtonPress);
        }
    }

    public bool IsOpen => _isOpen;

    //Open door on call
    public void SetDoorOpen()
    {
        this._isOpen = true;
    }

    //Spawn wave at door position
    public void SpawnWave()
    {
        _ctrl.Spawn(new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), 5);
    }
}
