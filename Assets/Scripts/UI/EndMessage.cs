using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMessage : MonoBehaviour
{
    private bool _triggered;
    private GameObject _msg;
    private Events _events;
    
    /// <summary>
    /// We find the GameObject called "EndMessage" and store it in a variable called _msg. We then set the _msg GameObject
    /// to inactive. We also find the GameObject called "GameManager" and store it in a variable called _events
    /// </summary>
    private void Start()
    {
        _msg = GameObject.Find("EndMessage");
        _msg.SetActive(false);
        _events = GameObject.Find("GameManager").GetComponent<Events>();
    }
    
    /// <summary>
    /// If the player enters the trigger, the message is displayed and the win event is triggered
    /// </summary>
    /// <param name="other">The collider that will trigger the event</param>
    private void OnTriggerEnter(Collider other)
    {
        if (!_triggered && other.gameObject.CompareTag("Player"))
        {
            _triggered = true;
            _msg.SetActive(true);
            _msg.GetComponent<MsgFollowPlayer>().SetText(
                "Félicitations, vous avez fini le niveau\nen " + Math.Round(Time.timeSinceLevelLoad, 2) + " secondes",
                0.5f,
                Color.white);
            _events.SetWin(true);
        }
    }
}