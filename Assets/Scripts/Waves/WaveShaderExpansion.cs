using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShaderExpansion : MonoBehaviour
{
    public Color waveColor;
    public Material material;
    public Vector4[] waveParams;    // Parameters of sound wave index i
                                    // impactStrength, width, fadeSpeed, waveIntensity
    public Vector4[] waveOrigin;    // Position of sound wave index i

    public GameObject outlineTrigger;
    public static float waveSpeed = 6;
    private int waveIndex;
    int nbWaves;
    float[] radius;         // Radius of sound wave index i

    // Set empty arrays for origins and params
    // 
    // TODO convert wave to Class
    void Start(){
        waveOrigin = new Vector4[20];
        waveParams = new Vector4[20];
        radius = new float[20];
        waveIndex = 0;
        for (int i = 0; i < 20; i++) 
        {
            waveOrigin[i] = new Vector4(0, 0, 0, 1);
            waveParams[i] = new Vector4(0, 0, 1, 0); //impactStrength, width, fadeSpeed, waveIntensity
            radius[i] = 0;
        }
        nbWaves = waveOrigin.Length;
        material.SetColor("_Color", waveColor);
    }

    float maxRadius;
    OutlineTriggerSphere outlineTriggerCs;
    // Spawns a sound wave at position given
    // Spawns an outline trigger sphere with max radius equal to wave strengh parameter
    // waveStrength [0, infinity[
    // waveSharpness [0, 1]
    // waveFade [0, infinity[
    // waveIntensity [0, 1]
    public void Spawn(Vector3 spawnPoint, float waveStrength = 0, float waveSharpness = 0.5f, float waveFade = 3, float waveIntensity = 1f) 
    {
        /****************Spawn new sound wave*****************/
        waveOrigin[waveIndex] = new Vector4(spawnPoint.x, spawnPoint.y, spawnPoint.z, 0);
        waveParams[waveIndex] = new Vector4(waveStrength, waveSharpness, waveFade, waveIntensity);
        radius[waveIndex] = 0;
        material.SetVectorArray("_WaveParams", waveParams);

        /***************Outline Trigger Sphere****************/
        maxRadius = waveParams[waveIndex][0];
        outlineTriggerCs = outlineTrigger.GetComponent<OutlineTriggerSphere>();
        outlineTriggerCs.maxRadius = maxRadius;
        Instantiate(outlineTrigger, new Vector3(spawnPoint.x, spawnPoint.y, spawnPoint.z), Quaternion.identity);

        /*****************Switch to next wave*****************/
        waveIndex = (waveIndex + 1) % nbWaves;

    }

    // Update is called once per frame
    // At each frame, increase the radius of the waves, depending on the wave speed (static constant) and the wave max radius
    void Update()
    {
        material.SetInt("nbWave", nbWaves);
        for (int i = 0; i < nbWaves; i++) {
            radius[i] = Mathf.Min(radius[i] + Time.deltaTime * waveSpeed, 1.5f * waveParams[i][0]); 
            material.SetVectorArray("_WaveOrigin", waveOrigin);
            material.SetFloatArray("radius", radius);
        }
    }
}
