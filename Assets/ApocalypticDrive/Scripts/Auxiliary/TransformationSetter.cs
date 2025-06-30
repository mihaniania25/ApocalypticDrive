using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    public class TransformationSetter : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private bool applyRotation;
        [SerializeField] private Vector3 rotationEuler;

        private void OnValidate()
        {
            target = transform;
        }

        private void Update()
        {
            if (target == null)
                return;

            if (applyRotation)
                target.rotation = Quaternion.Euler(rotationEuler);
        }
    }
}
