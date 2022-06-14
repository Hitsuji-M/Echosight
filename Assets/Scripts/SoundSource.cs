using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    private AudioSource _soundSrc;
    private AudioClip _soundSFX;
    private GameObject _soundWave;

    // Start is called before the first frame update
    void Start()
    {
        _soundSrc = GetComponent<AudioSource>();
        _soundSFX = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        //Play sound and spawn wave on 'Space'
        if (Input.GetKeyDown(KeyCode.Space)) {
            _soundSrc.PlayOneShot(_soundSFX, 1);
            Instantiate(_soundWave, transform.position, transform.rotation);
        }    
    }
}
