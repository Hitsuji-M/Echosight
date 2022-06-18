using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    private AudioSource _soundSrc;
    private AudioClip _soundSFX;
    private GameObject _soundWave;
    
    /// <summary>
    /// The Start function is called when the game starts
    /// </summary>
    void Start()
    {
        _soundSrc = GetComponent<AudioSource>();
        _soundSFX = GetComponent<AudioClip>();
    }
    
    /// <summary>
    /// > When the player presses the space bar, play a sound and spawn a sound wave
    /// </summary>
    void Update()
    {
        //Play sound and spawn wave on 'Space'
        if (Input.GetKeyDown(KeyCode.Space)) {
            _soundSrc.PlayOneShot(_soundSFX, 1);
            Instantiate(_soundWave, transform.position, transform.rotation);
        }    
    }
}
