using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderOnClick : MonoBehaviour
{
    public GameObject waveController;

    private WaveShaderExpansion controller;
    
    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
    }
    // Update is called once per frame
    /// <summary>
    /// If the mouse is clicked, then the raycast will be casted from the camera to the mouse position.
    /// If the raycast hits something, then the spawn point will be set to the hit point
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                controller.Spawn(hit.point);
            }
        }
    }
}
