using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject waveController;
    public AudioClip[] soundEffects;
    private AudioSource soundSource;
    private WaveShaderExpansion controller;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
        rb = GetComponent<Rigidbody>();
        soundSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(rb.velocity);
        for (int i = 0; i < collision.contactCount; i++)
        {
            Debug.Log(rb.velocity.magnitude);
            controller.Spawn(collision.GetContact(i).point);
            soundSource.PlayOneShot(soundEffects[0], 1.0f);
            
        }
    }
}
