using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderOnClick : MonoBehaviour
{
    public WaveShaderExpansion wave;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("YES");
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                wave.Spawn = hit.point;
                Debug.Log("Hit" + hit.point);

            }
        }
    }
}
