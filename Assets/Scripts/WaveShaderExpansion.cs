using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public Color waveColor;
    public float impactStrength;
    public float soundSharpness;
    public Material[] material;
    public Vector4[] waveOrigin;

    private static readonly Vector4[] emptyVector = new Vector4[] { new Vector4(0, 0, 0, 1) };
    private int waveIndex;
    private int nMaterial;

    void Start(){
        waveOrigin = new Vector4[10];
        waveIndex = 0;
        nMaterial = material.Length;
        for (int i = 0; i < 10; i++) 
        {
            waveOrigin[i] = new Vector4(0, 0, 0, 1);
        }
        Vector2 waveParam = new Vector2(impactStrength, soundSharpness);
        for (int i = 0; i < nMaterial; i++)
        {
            material[i].SetVector("_WaveParam", waveParam);
            material[i].SetColor("_Color", waveColor);
        }
    }
    public void Spawn(Vector3 spawnPoint) 
    {
        waveOrigin[waveIndex] = ( new Vector4(spawnPoint.x, spawnPoint.y, spawnPoint.z, 0));
        waveIndex = (waveIndex + 1) % 10;
    }
    // Update is called once per frame
    void Update()
    {
        int nbWaves = waveOrigin.Length;
        for (int i = 0; i < nMaterial; i++) {
            material[i].SetInt("nbWave", nbWaves);
        }
        for (int i = 0; i < nbWaves; i++) {
            waveOrigin[i] = new Vector4(waveOrigin[i].x,
                                        waveOrigin[i].y,
                                        waveOrigin[i].z,
                                        Mathf.Min(waveOrigin[i].w + Time.deltaTime/4, 1));
            for (int j = 0; j < nMaterial; j++)
            {
                material[j].SetVectorArray("_WaveOrigin", waveOrigin);
            }
        }
        //Debug.Log(material.GetVectorArray("_WaveOrigin")[1]);
        //Debug.Log(material.GetVectorArray("_WaveParam")[0]);
        
    }
}
