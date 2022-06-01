using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    public GameObject canvas;
    private GameObject _door;
    private bool _isDoorNull;
    private bool _iscanvasNull;

    // Start is called before the first frame update
    void Start()
    {
        _iscanvasNull = canvas == null;
        _isDoorNull = _door == null;
        _playing = true;
        _door = GameObject.FindWithTag("door");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (_iscanvasNull) return;
        
        _playing = !_playing;
        canvas.SetActive(!_playing);
        Time.timeScale = (_playing ? 1 : 0);
    }

    public void OpenDoor()
    {
        if (_isDoorNull) return;
        _door.transform.Translate(Vector3.forward);
    }
}
