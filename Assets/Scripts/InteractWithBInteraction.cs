using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class InteractWithBInteraction : MonoBehaviour
{
    private Camera _camera;
    private DoorTriggerer _doorTriggerer;
    public GameObject btnDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _doorTriggerer = btnDoor.GetComponent<DoorTriggerer>();
    }

    /*
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 2.0)) return;
        BoxCollider cldr = _btnDoor.GetComponent<BoxCollider>();
        if (cldr.bounds.Contains(hit.point)) {
            _gm.OpenDoor();
        }

    }
    */
}

/* visually see what I click
RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit ))
            {
                Debug.DrawRay(transform.position,hit.point - transform.position,
                    Color.green);
                Debug.Log("Did Hit "+hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(transform.position,ray.direction * 100f, Color.red);
                Debug.Log("Did not Hit");
            }
        }
*/