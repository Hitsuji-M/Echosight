using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMessage : MonoBehaviour
{
    private bool _triggered;
    public string text;

    private void OnTriggerEnter(Collider other)
    {
        if (!_triggered) Debug.Log("felicitation vous avez fini le niveau à " + Time.time);
        else _triggered = true;
    }
}