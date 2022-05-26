using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        _playing = true;
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
        _playing = !_playing;
        canvas.SetActive(!_playing);
        Time.timeScale = (_playing ? 1 : 0);
    }
}
