using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public Color waveColor;
    public float impactStrength;
    public float soundSharpness;
    public Material material;
    public Vector4[] waveOrigin;
    private static readonly Vector4[] emptyVector = new Vector4[] { new Vector4(0, 0, 0, 0) };

    void Start(){
        waveOrigin = new Vector4[10];
        waveOrigin[0] = new Vector4(0, 0, 0, 0);
        Vector2 waveParam = new Vector2(impactStrength, soundSharpness);

        material.SetVector("_WaveParam", waveParam);
        material.SetColor("_Color", waveColor);
    }
    public void Spawn(Vector3 spawnPoint, int waveIndex) 
    {
        waveOrigin[waveIndex] = ( new Vector4(spawnPoint.x, spawnPoint.y, spawnPoint.z, 0));
    }
    // Update is called once per frame
    void Update()
    {
        int nbWaves = waveOrigin.Length;
        material.SetInt("nbWave", nbWaves);
        for (int i = 0; i < nbWaves; i++) {
            waveOrigin[i] = new Vector4(waveOrigin[i].x,
                                        waveOrigin[i].y,
                                        waveOrigin[i].z,
                                        Mathf.Min(waveOrigin[i].w + Time.deltaTime/4, 1));
            material.SetVectorArray("_WaveOrigin", waveOrigin);
        }
        Debug.Log(material.GetVectorArray("_WaveOrigin")[1]);
        //Debug.Log(material.GetVectorArray("_WaveParam")[0]);
        
    }
}
