using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTriggerSphere : MonoBehaviour
{
    SphereCollider sphereCollider;
    public float maxRadius;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0;
    }

    // Update is called once per frame
    // Expands the sphere collider until it reaches its max radius
    void Update()
    {
        sphereCollider.radius += Time.deltaTime * WaveShaderExpansion.waveSpeed;
        if (sphereCollider.radius > maxRadius * 0.8f)
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
