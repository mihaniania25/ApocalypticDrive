﻿using System;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public interface IEnemy
    {
        event Action<IEnemy> OnDead;
        void Mute();
        void Die();
        void DieInstantly();
        void TakeDamage(float damage);
    }
}
