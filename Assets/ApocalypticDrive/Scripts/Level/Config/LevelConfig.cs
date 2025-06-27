using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Level.Config
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Config/Level Config")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject VehiclePrefab { get; private set; }
    }
}
