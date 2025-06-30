using System.Collections.Generic;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Config/Audio Config")]
    public class AudioConfig : ScriptableObject
    {
        [field: SerializeField] public List<AudioData> AudioDataSet { get; private set; }
    }
}
