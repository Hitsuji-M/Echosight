using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTriggerSphere : MonoBehaviour
{
    SphereCollider sphereCollider;
    float maxRadius;
    float lifespan;
    cakeslice.Outline objectOutline;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        //maxRadius = GameObject.Find("WaveController").GetComponent<WaveShaderExpansion>().impactStrength;
        maxRadius = 10;
        lifespan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifespan += Time.deltaTime;
        sphereCollider.radius = maxRadius * lifespan;
        if (lifespan > 1)
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
