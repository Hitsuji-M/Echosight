using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private GameObject _waveCtrl;
    private float _soundSharpness;
    private WaveShaderExpansion _ctrl;
    private Rigidbody _rb;
    private Vector3 _pos;
    private Quaternion _rotation;

    // Start is called before the first frame update
    void Start()
    {
        _waveCtrl = GameObject.Find("WaveController");
        _soundSharpness = 1.0f;
        _ctrl = _waveCtrl.GetComponent<WaveShaderExpansion>();
        _rb = GetComponent<Rigidbody>();
        _pos = transform.position;
        _rotation = transform.rotation;
    }


    void Update()
    {
        // If the position is below -5, replace objects at their initial position
        if (transform.position.y < -5)
        {
            transform.position = _pos;
            transform.rotation = _rotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // On Collision spawns a wave depending collider attributes
    void OnCollisionEnter(Collision collision)
    {
        float impact = _rb.mass * _rb.velocity.magnitude * 20;
        for (int i = 0; i < collision.contactCount; i++) {
            _ctrl.Spawn(collision.GetContact(i).point, waveStrength : impact, 
                                                       waveSharpness : _soundSharpness, 
                                                       waveFade : impact,
                                                       waveIntensity : impact * _soundSharpness / 10);
        }    
    }
}
