using System;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IEnemy
    {
        event Action<IEnemy> OnDead;
        void Die();
    }
}
