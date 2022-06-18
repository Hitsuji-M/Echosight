using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioRegister : MonoBehaviour
{
    public string folderName;
    public List<SoundAudioClip> audioLister;

    /// <summary>
    /// If the folder name is not empty, generate the sound
    /// </summary>
    private void OnValidate()
    {
        if (!folderName.Equals(""))
        {
            GenerateSound(folderName);
        }
        else
        {
            Debug.LogWarning("folder name is empty");
        }
    }

    /// <summary>
    /// It loads all the audio clips in the directory and adds them to the audioLister
    /// </summary>
    /// <param name="path">The path to the folder in the Resources folder.</param>
    private void GenerateSound(string path)
    {
        var directory = "Audio/" + path + "/";
        foreach (var audioClip in Resources.LoadAll<AudioClip>(directory))
        {
            var sac = new SoundAudioClip(audioClip);
            if (!audioLister.Contains(sac))
            {
                audioLister.Add(sac);
            }
        }
    }

    /// <summary>
    /// It returns the audio clip that has the same name as the string passed to it
    /// </summary>
    /// <param name="soundname">The name of the sound you want to play.</param>
    /// <returns>
    /// The audio clip that contains the sound name.
    /// </returns>
    public AudioClip GetSound(string soundname)
    {
        return this.audioLister.Find(clip => clip.sound.Contains(soundname)).audioClip;
    }

    /// <summary>
    /// This function clears the list of audio files and then calls the GenerateSound function to repopulate the list
    /// </summary>
    [ContextMenu("reset List")]
    public void ResetList()
    {
        this.audioLister.Clear();
        GenerateSound(folderName);
    }
    
    [Serializable]
    public class SoundAudioClip : IEquatable<SoundAudioClip>
    {
        public string sound;
        public AudioClip audioClip;
        
        public SoundAudioClip(AudioClip clip)
        {
            sound = clip.name;
            audioClip = clip;
        }

        /// <summary>
        /// If the other object is null, return false. If the other object is the same object, return true. If the other
        /// object is not null and not the same object, return whether the audioClip is equal to the other object's
        /// audioClip
        /// </summary>
        /// <param name="other">The class that we're overriding the Equals method for.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public bool Equals(SoundAudioClip other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(audioClip, other.audioClip);
        }

        /// <summary>
        /// If the object is null, return false. If the object is the same object, return true. If the object is not the
        /// same type, return false. Otherwise, return the result of the Equals function
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SoundAudioClip)obj);
        }

        /// <summary>
        /// If the audioClip is not null, return the hashcode of the audioClip. Otherwise, return 0
        /// </summary>
        /// <returns>
        /// The hash code of the audio clip.
        /// </returns>
        public override int GetHashCode()
        {
            return (audioClip != null ? audioClip.GetHashCode() : 0);
        }
    }
}