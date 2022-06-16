using System.Collections;
using System.Collections.Generic;
using SUPERCharacter;
using UnityEditor;
using UnityEngine;

public class  WaterDrop : MonoBehaviour
{
    // Spawns waves at regular intervals and play water drop sound
  
    private GameObject _waveCtrl;
    [SerializeField] AudioClip[] _clips;

    void Start()
    {
        _waveCtrl = GameObject.Find("WaveController");
        StartCoroutine(SpawnDrop());
    }

    IEnumerator SpawnDrop()
    {
        while (true)
        {
            float delay = UnityEngine.Random.Range(5, 10);
            yield return new WaitForSeconds(delay);

            _waveCtrl.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x,transform.position.y+1, transform.position.z), 4);
            int index = UnityEngine.Random.Range(0, _clips.Length);
            AudioClip clip = _clips[index];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
