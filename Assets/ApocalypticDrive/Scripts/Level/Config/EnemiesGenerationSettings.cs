using System;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level.Config
{
    [Serializable]
    public class EnemiesGenerationSettings
    {
        [field: SerializeField] public GameObject EnemyPrefab { get; private set; }
        [field: SerializeField] public int EnemiesCount { get; private set; }
        [field: SerializeField] public float DistanceOffsetStart { get; private set; }
        [field: SerializeField] public float DistanceOffsetEnd { get; private set; }
        [field: SerializeField] public float WidthOfGenerationField { get; private set; }
    }
}
