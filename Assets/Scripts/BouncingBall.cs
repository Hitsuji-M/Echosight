using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public GameObject waveController;

    private WaveShaderExpansion controller;
    private Rigidbody bouncingBallRb;

    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
        bouncingBallRb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++) 
        {
            controller.Spawn(collision.GetContact(i).point);
        }
        bouncingBallRb.AddForce(Random.onUnitSphere * 10 + Vector3.up * 2, ForceMode.Impulse);
    }
}
