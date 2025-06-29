using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Level.Config;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class ClassicLevelEnvironment : ILevelEnvironment
    {
        [Inject] private LazyInject<IVehicle> vehicle;
        [Inject] private LevelConfig levelConfig;

        private bool isBuildingEnabled = false;

        private float tileSize;

        private GameObject tilesContainer;
        private GameObject previousTile;
        private GameObject currentTile;
        private GameObject nextTile;

        public void StartBuilding()
        {
            ProjectLog.Info("[ClassicLevelEnvironment] building started");

            DetectTileBounds();

            isBuildingEnabled = true;
            BuildingRoutine().Forget();
        }

        private void DetectTileBounds()
        {
            GameObject tilePrefab = levelConfig.TilePrefab;

            Renderer renderer = tilePrefab.GetComponentInChildren<Renderer>();
            Bounds bounds = renderer.bounds;

            Vector3 min = bounds.center - bounds.extents;
            Vector3 max = bounds.center + bounds.extents;

            tileSize = max.z - min.z;
            ProjectLog.Info($"[ClassicLevelEnvironment] tile size: {tileSize}");
        }

        private async UniTask BuildingRoutine()
        {
            tilesContainer = new("Tiles Container");

            currentTile = BuildTileAtPosition(Vector3.zero);
            nextTile = BuildTileAtPosition(currentTile.transform.position + Vector3.forward * tileSize);

            while (isBuildingEnabled)
            {
                if (vehicle.Value.Position.z >= currentTile.transform.position.z + tileSize / 2.0f)
                    BuildNextGenTiles();

                await UniTask.Yield();
            }
        }

        private GameObject BuildTileAtPosition(Vector3 position)
        {
            GameObject tile = GameObject.Instantiate(levelConfig.TilePrefab, tilesContainer.transform);
            tile.transform.position = position;
            return tile;
        }

        private void BuildNextGenTiles()
        {
            if (previousTile != null)
                GameObject.Destroy(previousTile);

            previousTile = currentTile;
            currentTile = nextTile;

            nextTile = BuildTileAtPosition(currentTile.transform.position + Vector3.forward * tileSize);
        }

        public void StopBuilding()
        {
            isBuildingEnabled = false;
        }
    }
}