using System.Collections;
using UnityEngine;

public class  WaterDrop : MonoBehaviour
{
    // Spawns waves at regular intervals and play water drop sound
  
    private WaveShaderExpansion _waveCtrl;
    [SerializeField] AudioClip[] clips;

    /// <summary>
    /// It finds the WaveController object and gets the WaveShaderExpansion script from it.
    /// </summary>
    void Start()
    {
        _waveCtrl = GameObject.Find("WaveController").GetComponent<WaveShaderExpansion>();
        StartCoroutine(SpawnDrop());
    }

    /// <summary>
    /// "Wait a random amount of time, then spawn a sound wave and play a random sound."
    /// </summary>
    IEnumerator SpawnDrop()
    {
        while (true)
        {
            float delay = Random.Range(5, 9);
            yield return new WaitForSeconds(delay);

            _waveCtrl.Spawn(new Vector3(transform.position.x, transform.position.y+1, transform.position.z), 4);
            int index = Random.Range(0, clips.Length);
            AudioClip clip = clips[index];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
