using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTriggerSphere : MonoBehaviour
{
    SphereCollider _sphereClldr;
    public float maxRadius;
    // Start is called before the first frame update
    void Start()
    {
        _sphereClldr = GetComponent<SphereCollider>();
        _sphereClldr.radius = 0;
    }

    // Update is called once per frame
    // Expands the sphere collider until it reaches its max radius
    void Update()
    {
        _sphereClldr.radius += Time.deltaTime * WaveShaderExpansion.waveSpeed;
        if (_sphereClldr.radius > maxRadius * 0.8f)
        {
            Destroy(gameObject);
        }
    }

    //Outline object on trigger with the collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outlinable") || other.CompareTag("Item"))
        {
            other.gameObject.GetComponent<cakeslice.Outline>().OnEnable();
        }
    }
}
