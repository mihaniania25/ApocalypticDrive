using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    [Serializable]
    public class EnemyComponents
    {
        public PropagationField<float> Health { get; private set; } = new();
        public EnemyEventBus EventBus { get; private set; } = new();
        public EnemyStateMachine StateMachine { get; set; }

        [field: SerializeField] public GameObject Root { get;private set; }

        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public AnimatorListener AnimatorListener { get; private set; }
        [field: SerializeField] public string AnimDeadStateName { get; private set; }
        [field: SerializeField] public string AnimRunningStateName { get; private set; }
        [field: SerializeField] public ParticleSystem BloodParticles { get; private set; }

        [field: SerializeField] public Collider MainCollider { get; private set; }
        [field: SerializeField] public Rigidbody MainRigidbody { get; private set; }

        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float VehicleVisibilityDistance { get; private set; }
    }
}
