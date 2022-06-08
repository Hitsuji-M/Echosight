using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject waveController;
    private WaveShaderExpansion controller;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++) 
        {
            controller.Spawn(collision.GetContact(i).point);
            // Debug.Log(collision.GetContact(i).point);
        }
    }
}
