using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMessage : MonoBehaviour
{
    private bool _triggered;
    private GameObject _msg;
    
    private void Start()
    {
        _msg = GameObject.Find("EndMessage");
        _msg.SetActive(false);
    }

    /**
     * When an object with the tag player enters the trigger
     * It activates the message object and set his text
     */
    private void OnTriggerEnter(Collider other)
    {
        if (!_triggered && other.gameObject.CompareTag("Player"))
        {
            _msg.SetActive(true);
            _msg.GetComponent<MsgFollowPlayer>().SetText("Félicitations, vous avez fini le niveau\nen " + Time.time + " secondes");
            _triggered = true;
        }
    }
}