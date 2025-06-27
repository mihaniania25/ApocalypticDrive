using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class UserInputController : IUserInputController
    {
        public async UniTask WaitScreenTouch()
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0) is true);
        }
    }
}
