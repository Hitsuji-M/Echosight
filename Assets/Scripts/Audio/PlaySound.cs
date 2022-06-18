using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _firstCollisionShouldBeHeard;

    /// <summary>
    /// The Start function is called once when the game starts
    /// </summary>
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// If the first collision should be heard, play the sound. Otherwise, set the first collision to be heard
    /// </summary>
    /// <param name="collision">The collision object that contains information about the collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (_firstCollisionShouldBeHeard) _audioSource.Play();
        else _firstCollisionShouldBeHeard = true;
    }
}
