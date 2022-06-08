using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public Color waveColor;
    public float impactStrength;
    public float soundSharpness;
    public Material material;
    public Vector4[] waveParams;
    public Vector4[] waveOrigin;

    public GameObject outlineTrigger;
    private int waveIndex;
    int nbWaves;

    void Start(){
        waveOrigin = new Vector4[20];
        waveParams = new Vector4[20];
        waveIndex = 0;
        for (int i = 0; i < 20; i++) 
        {
            waveOrigin[i] = new Vector4(0, 0, 0, 1);
            waveParams[i] = new Vector4(10, 0.5f, 1, 1); //impactStregth, width, fadeSpeed, colorIntensity
        }
        nbWaves = waveOrigin.Length;
        material.SetColor("_Color", waveColor);
    }
    public void Spawn(Vector3 spawnPoint, int waveStrength = 10, float waveSharpness = 0.5f, float waveFade = 1, float waveColorIntensity = 1) 
    {
        waveOrigin[waveIndex] = new Vector4(spawnPoint.x, spawnPoint.y, spawnPoint.z, 0);
        waveParams[waveIndex] = new Vector4(waveStrength, waveSharpness, waveFade, waveColorIntensity);
        Instantiate(outlineTrigger, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), Quaternion.identity);
        waveIndex = (waveIndex + 1) % 10;
        material.SetVectorArray("_WaveParams", waveParams);
    }

    // Update is called once per frame
    void Update()
    {
        material.SetInt("nbWave", nbWaves);
        for (int i = 0; i < nbWaves; i++) {
            waveOrigin[i] = new Vector4(waveOrigin[i].x,
                                        waveOrigin[i].y,
                                        waveOrigin[i].z,
                                        Mathf.Min(waveOrigin[i].w + Time.deltaTime/4, 1));
            material.SetVectorArray("_WaveOrigin", waveOrigin);

        }
        //Debug.Log(material.GetVectorArray("_WaveOrigin")[1]);
        //Debug.Log(material.GetVectorArray("_WaveParam")[0]);

    }
}
