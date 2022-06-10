using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public Color waveColor;
    public Material material;
    public Vector4[] waveParams;
    public Vector4[] waveOrigin;

    public GameObject outlineTrigger;
    public static float waveSpeed = 10;
    private int waveIndex;
    int nbWaves;
    float[] radius;

    float maxRadius;
    OutlineTriggerSphere outlineTriggerCs;

    void Start(){
        waveOrigin = new Vector4[20];
        waveParams = new Vector4[20];
        radius = new float[20];
        waveIndex = 0;
        for (int i = 0; i < 20; i++) 
        {
            waveOrigin[i] = new Vector4(0, 0, 0, 1);
            waveParams[i] = new Vector4(10, 0.5f, 1, 1); //impactStrength, width, fadeSpeed, colorIntensity7
            radius[i] = 0;
        }
        nbWaves = waveOrigin.Length;
        material.SetColor("_Color", waveColor);
    }
    public void Spawn(Vector3 spawnPoint, float waveStrength = 10, float waveSharpness = 0.5f, float waveFade = 5, float waveOffset = 0f) 
    {
        /****************Spawn new sound wave*****************/
        waveOrigin[waveIndex] = new Vector4(spawnPoint.x, spawnPoint.y, spawnPoint.z, 0);
        waveParams[waveIndex] = new Vector4(waveStrength, waveSharpness, waveFade, waveOffset);
        radius[waveIndex] = 0;
        //Debug.Log(radius[waveIndex]);
        waveIndex = (waveIndex + 1) % nbWaves;
        material.SetVectorArray("_WaveParams", waveParams);
        //Debug.Log(waveStrength);

        /***************Outline Trigger Sphere****************/
        maxRadius = waveParams[waveIndex][0];
        outlineTriggerCs = outlineTrigger.GetComponent<OutlineTriggerSphere>();
        outlineTriggerCs.maxRadius = maxRadius;
        Instantiate(outlineTrigger, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        material.SetInt("nbWave", nbWaves);
        for (int i = 0; i < nbWaves; i++) {
            waveOrigin[i] = new Vector4(waveOrigin[i].x,
                                        waveOrigin[i].y,
                                        waveOrigin[i].z,
                                        Mathf.Min(waveOrigin[i].w + Time.deltaTime, 1));
            radius[i] = Mathf.Min(radius[i] + Time.deltaTime * waveSpeed, waveParams[i][0]); 
            material.SetVectorArray("_WaveOrigin", waveOrigin);
            material.SetFloatArray("radius", radius);
        }
        //Debug.Log(material.GetVectorArray("_WaveOrigin")[1]);
        //Debug.Log(material.GetVectorArray("_WaveParam")[0]);

    }
}
