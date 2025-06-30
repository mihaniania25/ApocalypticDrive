using System;
using System.Collections;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive.Fx
{
    public class FlashFX : MonoBehaviour
    {
        private const string FLASH_PARAM = "BlinkValue";

        [SerializeField] private MeshRenderer meshRenderer;

        [SerializeField] private float flashDelay = 0.05f;
        [SerializeField] private float flashInDuration = 0.02f;
        [SerializeField] private float flashIdleDuration = 0.02f;
        [SerializeField] private float flashOutDuration = 0.02f;
        [Range(0f, 1f)]
        [SerializeField] private float targetStrength = 1f;

        private Material material;
        private Coroutine flashCoroutine;

        private void Awake()
        {
            material = meshRenderer.material;
        }

        public void ShowFlashFx()
        {
            if (flashCoroutine != null)
                StopCoroutine(flashCoroutine);

            flashCoroutine = StartCoroutine(FlashCoro());
        }

        private IEnumerator FlashCoro()
        {
            float inStart = Time.time;
            float t;

            UpdateFlashStrength(0f);
            yield return new WaitForSeconds(flashDelay);

            do
            {
                t = (Time.time - inStart) / flashInDuration;
                t = Mathf.Clamp01(t);

                float strength = Mathf.Lerp(0f, targetStrength, t);
                UpdateFlashStrength(strength);

                yield return null;
            }
            while (t != 1);

            yield return new WaitForSeconds(flashIdleDuration);

            float outStart = Time.time;
            do
            {
                t = (Time.time - outStart) / flashOutDuration;
                t = Mathf.Clamp01(t);

                float strength = Mathf.Lerp(targetStrength, 0f, t);
                UpdateFlashStrength(strength);

                yield return null;
            }
            while (t != 1);

            flashCoroutine = null;
        }

        private void UpdateFlashStrength(float strength)
        {
            material.SetFloat(FLASH_PARAM, strength);
        }
    }
}
