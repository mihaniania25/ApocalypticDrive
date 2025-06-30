using MeShineFactory.ApocalypticDrive.UI;
using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    [Serializable]
    public class EnemyComponents
    {
        public PropagationField<float> Health { get; private set; } = new();
        public bool IsMuted { get; set; } = false;
        public EnemyEventBus EventBus { get; private set; } = new();
        public EnemyStateMachine StateMachine { get; set; }
        public EnemyFxController FxController { get; set; }
        public EnemyHealthController HealthController { get; set; }

        [field: SerializeField] public GameObject Root { get;private set; }

        [field: SerializeField] public AudioSource AudioSource { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public AnimatorListener AnimatorListener { get; private set; }
        [field: SerializeField] public string AnimDeadStateName { get; private set; }
        [field: SerializeField] public string AnimRunningStateName { get; private set; }
        [field: SerializeField] public string AnimInjuryTriggerName { get; private set; }
        [field: SerializeField] public ParticleSystem BloodParticles { get; private set; }
        [field: SerializeField] public GameObject InjuryParticlesPrefab { get; private set; }

        [field: SerializeField] public Collider MainCollider { get; private set; }
        [field: SerializeField] public Rigidbody MainRigidbody { get; private set; }
        [field: SerializeField] public Transform InjuryParticlesMount { get; private set; }
        [field: SerializeField] public ProgressBar HealthBar { get; private set; }

        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float VehicleVisibilityDistance { get; private set; }
    }
}
