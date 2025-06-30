using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level.Config
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Config/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject VehiclePrefab { get; private set; }
        [field: SerializeField] public GameObject TurretPrefab { get; private set; }
        [field: SerializeField] public GameObject TilePrefab { get; private set; }
        [field: SerializeField] public float LevelDistance { get; private set; }
        [field: SerializeField] public CameraSettings CameraSettings { get; private set; }
        [field: SerializeField] public EnemiesGenerationSettings EnemiesGenerationSettings { get; private set; }
    }
}
