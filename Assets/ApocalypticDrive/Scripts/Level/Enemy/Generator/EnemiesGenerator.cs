using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Level.Model;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemiesGenerator : IEnemiesGenerator
    {
        [Inject] private DiContainer diContainer;
        [Inject] private LevelConfig levelConfig;
        [Inject] private LazyInject<IVehicle> vehicle;
        [Inject] private GameSessionModel sessionModel;

        private EnemiesGenerationSettings genSettings => levelConfig.EnemiesGenerationSettings;

        public void GenerateEnemies()
        {
            float fieldStart = vehicle.Value.Position.z + genSettings.DistanceOffset;
            float fieldEnd = vehicle.Value.Position.z + levelConfig.LevelDistance - genSettings.DistanceOffset;
            float fieldHalfWidth = genSettings.WidthOfGenerationField / 2.0f;

            for (int i = 0; i < genSettings.EnemiesCount; i++)
            {
                float zPos = Random.Range(fieldStart, fieldEnd);
                float xPos = Random.Range(-fieldHalfWidth, fieldHalfWidth);

                CreateEnemyAtPosition(new(xPos, 0, zPos));
            }
        }

        private void CreateEnemyAtPosition(Vector3 position)
        {
            GameObject enemyGO = diContainer.InstantiatePrefab(genSettings.EnemyPrefab);
            enemyGO.transform.position = position;
            enemyGO.transform.Rotate(Vector3.up, Random.Range(0, 360f));

            IEnemy enemy = enemyGO.GetComponent<IEnemy>();
            sessionModel.Enemies.Add(enemy);
        }
    }
}
