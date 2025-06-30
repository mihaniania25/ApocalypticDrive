using UnityEngine;
using Zenject;

namespace MeShineFactory.ApocalypticDrive.Audio
{
    public class AudioManager : IAudioManager
    {
        [Inject] AudioConfig audioConfig;

        public void PlaySound(SoundID soundID, AudioSource audioSource)
        {
            AudioData audioData = audioConfig.AudioDataSet.Find(d => d.ID == soundID);

            if (audioData != null)
            {
                audioSource.clip = audioData.Clip;
                audioSource.volume = audioData.Volume;
                audioSource.Play();
            }
        }
    }
}
