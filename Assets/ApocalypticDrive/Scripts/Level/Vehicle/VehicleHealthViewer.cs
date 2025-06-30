using UnityEngine;
using Zenject;
using MeShineFactory.ApocalypticDrive.Level.Model;
using MeShineFactory.ApocalypticDrive.UI;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class VehicleHealthViewer : MonoBehaviour
    {
        [Inject] private GameSessionModel sessionModel;
        [Inject] private LazyInject<IVehicle> vehicle;

        [SerializeField] private ProgressBar healthBar;

        private void Awake()
        {
            sessionModel.Health.Subscribe(OnHealthChange, false);
        }

        private void OnHealthChange(float health)
        {
            healthBar.gameObject.SetActive(health > 0f);
            healthBar.Progress.Value = health / vehicle.Value.MaxHealth;
        }

        private void OnDestroy()
        {
            sessionModel.Health.Unsubscribe(OnHealthChange);
        }
    }
}
