using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public GameObject waveController;

    private WaveShaderExpansion _ctrl;
    private Rigidbody _bouncingBallRb;

    void Start()
    {
        _ctrl = waveController.GetComponent<WaveShaderExpansion>();
        _bouncingBallRb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++) 
        {
            _ctrl.Spawn(collision.GetContact(i).point);
        }
        _bouncingBallRb.AddForce(Random.onUnitSphere * 10 + Vector3.up * 2, ForceMode.Impulse);
    }
}
