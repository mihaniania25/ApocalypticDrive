using MeShineFactory.ApocalypticDrive.Audio;
using UnityEngine;
using Zenject;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyFxController
    {
        [Inject] private IAudioManager audioManager;

        private EnemyComponents components;

        public EnemyFxController(EnemyComponents components)
        {
            this.components = components;
        }

        public void PlayInjuryFx()
        {
            audioManager.PlaySound(SoundID.BodyInjury, components.AudioSource);

            Transform container = components.Root.transform.parent;
            GameObject injuryParticles = GameObject.Instantiate(components.InjuryParticlesPrefab, 
                components.InjuryParticlesMount.position, Quaternion.identity);
            injuryParticles.transform.SetParent(container);

            components.Animator.SetTrigger(components.AnimInjuryTriggerName);
        }
    }
}
