using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _firtsColisionShouldBeHeard;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_firtsColisionShouldBeHeard) _audioSource.Play();
        else _firtsColisionShouldBeHeard = true;
    }
}
