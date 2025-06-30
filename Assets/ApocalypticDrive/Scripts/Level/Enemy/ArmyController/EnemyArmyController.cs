using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Config;
using MeShineFactory.ApocalypticDrive.Level.Model;
using System.Collections.Generic;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyArmyController : IEnemyArmyController
    {
        [Inject] private DiContainer diContainer;
        [Inject] private LevelConfig levelConfig;
        [Inject] private LazyInject<IVehicle> vehicle;
        [Inject] private GameSessionModel sessionModel;

        private Transform enemiesContainer;

        private EnemiesGenerationSettings genSettings => levelConfig.EnemiesGenerationSettings;

        public void Setup()
        {
            GameObject containerGO = new GameObject("Enemies Container");
            enemiesContainer = containerGO.transform;
        }

        public void DestroyAllEnemies()
        {
            List<IEnemy> enemies = new(sessionModel.Enemies);
            enemies.ForEach(e =>
            {
                e.Mute();
                e.Die();
            });
        }

        public void GenerateEnemies()
        {
            float fieldStart = vehicle.Value.Position.z + genSettings.DistanceOffsetStart;
            float fieldEnd = vehicle.Value.Position.z + levelConfig.LevelDistance - genSettings.DistanceOffsetEnd;
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
            enemyGO.transform.SetParent(enemiesContainer);

            IEnemy enemy = enemyGO.GetComponent<IEnemy>();
            sessionModel.Enemies.Add(enemy);

            enemy.OnDead += OnEnemyDead;
        }

        private void OnEnemyDead(IEnemy enemy)
        {
            enemy.OnDead -= OnEnemyDead;
            sessionModel.Enemies.Remove(enemy);
        }
    }
}
