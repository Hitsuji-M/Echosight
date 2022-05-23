using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip soundSFX;
    public GameObject soundWave;

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Play sound and spawn wave on 'Space'
        if (Input.GetKeyDown(KeyCode.Space)) {
            soundSource.PlayOneShot(soundSFX, 1);
            Instantiate(soundWave, transform.position, transform.rotation);
        }    
    }
}
