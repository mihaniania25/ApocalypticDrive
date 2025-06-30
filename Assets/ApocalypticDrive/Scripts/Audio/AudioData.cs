using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Audio
{
    [Serializable]
    public class AudioData
    {
        [field: SerializeField] public SoundID ID { get; private set; }
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; } = 1f;
    }
}
