using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyFxController
    {
        private EnemyComponents components;

        public EnemyFxController(EnemyComponents components)
        {
            this.components = components;
        }

        public void PlayInjuryFx()
        {
            Transform container = components.Root.transform.parent;
            GameObject injuryParticles = GameObject.Instantiate(components.InjuryParticlesPrefab, 
                components.InjuryParticlesMount.position, Quaternion.identity);
            injuryParticles.transform.SetParent(container);

            components.Animator.SetTrigger(components.AnimInjuryTriggerName);
        }
    }
}
