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

    // On Collision spawns a wave depending collider attributes
    void OnCollisionEnter(Collision collision)
    {

        impact = rb.mass * rb.velocity.magnitude * 20;
        for (int i = 0; i < collision.contactCount; i++) 
        {
            controller.Spawn(collision.GetContact(i).point, waveStrength : impact, 
                                                                    waveSharpness : soundSharpness, 
                                                                    waveFade : impact,
                                                                    waveIntensity : impact * soundSharpness / 10);
        }    
    }
}
