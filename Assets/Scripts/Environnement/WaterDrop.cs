using System.Collections;
using UnityEngine;

public class  WaterDrop : MonoBehaviour
{
    // Spawns waves at regular intervals and play water drop sound
  
    private GameObject _waveCtrl;
    [SerializeField] AudioClip[] clips;

    void Start()
    {
        _waveCtrl = GameObject.Find("WaveController");
        StartCoroutine(SpawnDrop());
    }

    IEnumerator SpawnDrop()
    {
        while (true)
        {
            float delay = Random.Range(5, 9);
            yield return new WaitForSeconds(delay);

            _waveCtrl.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), 4);
            int index = Random.Range(0, clips.Length);
            AudioClip clip = clips[index];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
