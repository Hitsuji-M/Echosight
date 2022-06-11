using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlaySound : MonoBehaviour
{
    private AudioSource _audioSource;
    public bool firtsColisionShouldBeHeard;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (firtsColisionShouldBeHeard) _audioSource.Play();
        else firtsColisionShouldBeHeard = true;
    }
}
