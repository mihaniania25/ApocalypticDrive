using UnityEngine;
using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateChase : BaseEnemyState
    {
        public override async UniTask Start(IStateData stateData)
        {
            await base.Start(stateData);

            components.Animator.SetBool(components.AnimRunningStateName, true);

            while (isAlive && GetDistanceToVehicle() <= components.VehicleVisibilityDistance)
            {
                transform.LookAt(vehicle.Transform);
                components.MainRigidbody.velocity = transform.forward * components.Speed;

                await UniTask.Yield();
            }

            if (isAlive)
                TrySwitchState(EnemyStateType.Idle);
        }

        public override async UniTask Stop()
        {
            await base.Stop();

            components.MainRigidbody.velocity = Vector3.zero;
            components.Animator.SetBool(components.AnimRunningStateName, false);
        }
    }
}
