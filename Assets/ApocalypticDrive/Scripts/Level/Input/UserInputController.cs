using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MeShineFactory.ApocalypticDrive.Level
{
    public class UserInputController : IUserInputController
    {
        public bool IsScreenUnderTouch => Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);

        public async UniTask WaitScreenTouch()
        {
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0) is true);
        }

        public float GetHorizontalViewportInput()
        {
            float mouseX = Input.mousePosition.x;
            float screenWidth = Screen.width;

            float normalized = (mouseX / screenWidth) * 2f - 1f;

            return normalized;
        }
    }
}
