using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    private static AudioMenu _instance;

    /// <summary>
    /// If there is no instance of this object, then make this the instance. If there is an instance, then destroy this
    /// object
    /// Put it in DontDestroyOnLoad to keep the music playing while changing scenes
    /// </summary>
    private void Awake()
    {
        if (!_instance) {
            _instance = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
