using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    [Serializable]
    public class EnemyComponents
    {
        [field: SerializeField] public GameObject Root { get;private set; }

        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public AnimatorListener AnimatorListener { get; private set; }
        [field: SerializeField] public string AnimDeadStateName { get; private set; }
        [field: SerializeField] public ParticleSystem BloodParticles { get; private set; }

        [field: SerializeField] public Collider MainCollider { get; private set; }
        [field: SerializeField] public Rigidbody MainRigidbody { get; private set; }
    }
}
