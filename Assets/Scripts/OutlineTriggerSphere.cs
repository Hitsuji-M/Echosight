using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTriggerSphere : MonoBehaviour
{
    SphereCollider sphereCollider;
    public float maxRadius;
    cakeslice.Outline objectOutline;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sphereCollider.radius += Time.deltaTime * WaveShaderExpansion.waveSpeed;
        if (sphereCollider.radius > maxRadius)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outlinable") || other.CompareTag("Item"))
        {
            other.gameObject.GetComponent<cakeslice.Outline>().OnEnable();
            // Debug.Log("outline hit");
            // Debug.Log(other + other.tag);
        }
    }
}
