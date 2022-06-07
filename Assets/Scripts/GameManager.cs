using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    private SUPERCharacterAIO _scc;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        _playing = true;
        _scc = GameObject.Find("Player").GetComponent<SUPERCharacterAIO>();
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
        SetUpPlayer(_playing);
        Time.timeScale = (_playing ? 1 : 0);
    }

    private void SetUpPlayer(bool isActive)
    {
        _scc.enableCameraControl = isActive;
        _scc.enableMovementControl = isActive;
        _scc.enableFootstepSounds = isActive;
    }
}
