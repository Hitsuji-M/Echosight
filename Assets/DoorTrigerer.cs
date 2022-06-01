using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigerer : MonoBehaviour
{
    public GameObject door;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = door.GetComponent<Animator>();
    }

    public void triggerDoor()
    {
        _animator.SetTrigger("BountonPousse");
    }
}
