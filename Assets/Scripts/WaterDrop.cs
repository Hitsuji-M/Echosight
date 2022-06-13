using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject waveController;
    float dropInterval;

    void Start()
    {
        dropInterval = Random.value * 10;
    }
    // Update is called once per frame
    void Update()
    {
        dropInterval -= Time.deltaTime;
        if (dropInterval < 0)
        {
            waveController.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x,transform.position.y,transform.position.z), 5);
            dropInterval = Random.value * 10;
        }
        Debug.Log(dropInterval);
    }
}
