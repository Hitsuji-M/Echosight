using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public float expansionSpeed;
    public Material material;

    public Vector4 waveOrigin = Vector4.zero;
    public Vector3 Spawn { set { waveOrigin = new Vector4(value.x, value.y, value.z, 0); } }
    // Update is called once per frame
    void Update()
    {
        waveOrigin.w = Mathf.Min(waveOrigin.w + (Time.deltaTime * expansionSpeed / 10), 1);
        material.SetVector("_WaveOrigin", waveOrigin);
        // Debug.Log(waveOrigin);
    }
}
