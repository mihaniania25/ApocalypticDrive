using Cysharp.Threading.Tasks;
using MeShineFactory.ApocalypticDrive.Pattern.StateMachine;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class EnemyStateIdle : BaseEnemyState
    {
        public override async UniTask Start(IStateData stateData)
        {
            await base.Start(stateData);
        }
    }
}
