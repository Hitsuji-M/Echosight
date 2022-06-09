using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject waveController;
    public float soundSharpness;
    private WaveShaderExpansion controller;
    private Rigidbody rb;
    float impact;

    // Start is called before the first frame update
    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(rb.velocity);
        for (int i = 0; i < collision.contactCount; i++)
        {

            Debug.Log(rb.velocity.magnitude);
            impact = rb.mass * rb.velocity.magnitude ;
            Debug.Log(impact);
            controller.Spawn(collision.GetContact(i).point, waveStrength : impact, waveSharpness : soundSharpness);
            
        }
    }
}
