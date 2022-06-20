using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTriggerSphere : MonoBehaviour
{
    
    SphereCollider _sphereClldr;
    public float maxRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        _sphereClldr = GetComponent<SphereCollider>();
        _sphereClldr.radius = 0;
    }
    
    /// <summary>
    /// > The radius of the sphere collider is increased by deltaTime every frame. If the radius is greater than 80% of
    /// the maximum radius, the game object is destroyed
    /// </summary>
    void Update()
    {
        _sphereClldr.radius += Time.deltaTime * WaveShaderExpansion.waveSpeed;
        if (_sphereClldr.radius > maxRadius * 0.8f)
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// When the player enters the trigger of an object, if the object is tagged as "Outlinable" or "Item", then the
    /// object's outline is enabled
    /// </summary>
    /// <param name="other">The collider that is being entered.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Outlinable") || other.CompareTag("Item"))
        {
            other.gameObject.GetComponent<cakeslice.Outline>().OnEnable();
        }
    }
}
