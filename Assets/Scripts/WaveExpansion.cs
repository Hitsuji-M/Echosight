using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveExpansion : MonoBehaviour
{
    //Wave lifespan
    public float lifespan;

    //Wave expansion speed
    public float expansionSpeed;

    //Reverb wave summoned on collision
    public GameObject reverbWave;

    //List of collided object by wave
    private List<Collider> collidedObject;
    

    // Start is called before the first frame update
    void Start()
    {
        collidedObject = new List<Collider>();
        /*TODO
        List<float> angle = new List<float>();
        for (float angle_i = 0; angle_i < 2 * Math.PI; angle_i += 2 * (float) Math.PI / 100) 
        {
            angle.Add((float) angle_i);
        }*/  
    }

    // Update is called once per frame
    void Update()
    {
        //Expand wave size while decreasing its lifespan
        transform.localScale += Vector3.one * expansionSpeed * Time.deltaTime;
        lifespan -= 1;

        //Destroy wave when no lifespan left
        if (lifespan < 0) {
            Destroy(gameObject);
        }
    }

    //On collision with collider/rigidbody
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.blue);
            if (collision.collider.CompareTag("HasReverb") && !collidedObject.Contains(collision.collider)){
                SpawnWave(contact.point, lifespan);
                Debug.Log("Collision!");
                collidedObject.Add(collision.collider);
            }
        }
        //## For now, only draw normal vector of the collision point
    }

    void OnTriggerStay(Collider collider) 
    {

    }

/*  ###TODO
    void DrawCircle(Vector3 center, float radius, Vector3 normalV) {
        Vector3 tangent = Vector3.one;
        Vector3.OrthoNormalize(ref normalV, ref tangent);
        for (int i = 0, i < angle.Length, i++) {
            Debug.DrawRay()
        }
        
    }
    */

    //Set lifespan
    private void SetLifespan(float newLifespan) {
        lifespan = newLifespan;
    }
    
    //Spawn Wave on the collider with set lifespan
    void SpawnWave(Vector3 position, float pLifespan) {
        WaveExpansion expandingWave = reverbWave.GetComponent<WaveExpansion>();
        expandingWave.SetLifespan(pLifespan);
        Instantiate(reverbWave, position, reverbWave.transform.rotation);
    }

}
