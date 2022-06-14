using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioRegister : MonoBehaviour
{
    public string folderName;
    public List<SoundAudioClip> audioLister;

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

    public AudioClip GetSound(string soundname)
    {
        return this.audioLister.Find(clip => clip.sound.Contains(soundname)).audioClip;
    }

    [ContextMenu("reset List")]
    public void ResetList()
    {
        this.audioLister.Clear();
        GenerateSound(folderName);
    }

    [System.Serializable]
    public class SoundAudioClip : IEquatable<SoundAudioClip>
    {
        public string sound;
        public AudioClip audioClip;

        public SoundAudioClip(AudioClip clip)
        {
            sound = clip.name;
            audioClip = clip;
        }

        public bool Equals(SoundAudioClip other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(audioClip, other.audioClip);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SoundAudioClip)obj);
        }

        public override int GetHashCode()
        {
            return (audioClip != null ? audioClip.GetHashCode() : 0);
        }
    }
}