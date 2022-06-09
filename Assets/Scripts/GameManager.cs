using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _playing;
    private SUPERCharacterAIO _scc;
    public GameObject canvas;
    private AudioRegister _senseLabSentences;
    private AudioSource _speakers;

    // Start is called before the first frame update
    void Start()
    {
        _playing = true;
        _scc = GameObject.Find("Player").GetComponent<SUPERCharacterAIO>();
        _speakers = GetComponent<AudioSource>();
        _senseLabSentences = GetComponent<AudioRegister>();
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
        Cursor.lockState = _playing ? CursorLockMode.Locked : CursorLockMode.Confined;
        Time.timeScale = (_playing ? 1 : 0);
    }

    public void PlayAudio(string soundName)
    {
        _speakers.PlayOneShot(_senseLabSentences.GetSound(soundName));
    }
    
}
