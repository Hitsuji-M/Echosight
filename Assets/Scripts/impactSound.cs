using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactSound : MonoBehaviour
{
    public AudioSource impactSource;

    // Start is called before the first frame update
    void Start()
    {
        impactSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        impactSource.Play();
    }
}
