using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Audio
{
    public interface IAudioManager
    {
        void PlaySound(SoundID soundID, AudioSource audioSource);
    }
}
