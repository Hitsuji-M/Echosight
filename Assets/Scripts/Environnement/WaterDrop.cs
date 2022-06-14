using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    // Spawns waves at regular intervals and play water drop sound (to be implemented)

    private GameObject _waveCtrl;

    void Start()
    {
        _waveCtrl = GameObject.Find("WaveController");
        StartCoroutine(SpawnDrop());
    }

    IEnumerator SpawnDrop()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            _waveCtrl.GetComponent<WaveShaderExpansion>().Spawn(new Vector3(transform.position.x,transform.position.y+1, transform.position.z), 4);
        }

    }
}
