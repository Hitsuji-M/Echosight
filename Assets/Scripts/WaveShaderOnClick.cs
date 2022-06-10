using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderOnClick : MonoBehaviour
{
    public GameObject waveController;

    private WaveShaderExpansion controller;
    
    int incremental;
    float incrementalf;

    void Start()
    {
        controller = waveController.GetComponent<WaveShaderExpansion>();
        incremental = 1;
        incrementalf = 10f;
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
                controller.Spawn(hit.point, waveStrength: 10, waveIntensity: incrementalf/10);
                incrementalf = incrementalf - 1;
                incremental++;

            }
        }
    }
}
