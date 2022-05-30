using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera _camera;
    private GameObject _btnDoor;
    private GameManager _gm;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _btnDoor = GameObject.FindWithTag("door_button");
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, 2.0f)) return;
        
        
        BoxCollider cldr = _btnDoor.GetComponent<BoxCollider>();
        if (cldr.bounds.Contains(hit.point)) {
            _gm.OpenDoor();
        }
    }
}
