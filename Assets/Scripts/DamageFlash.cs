using System.Collections;
using UnityEngine;

//Raphael script
    public class DamageFlash : MonoBehaviour
    {
        [SerializeField] private Material flashMaterial;

        [SerializeField] private float duration;

    [SerializeField] AnimationCurve flashCurve;
    float flashFrame = 0;
    bool isFlashing = false;

        // The SpriteRenderer that should flash.
        private SpriteRenderer spriteRenderer;

        // The material that was in use, when the script started.
        private Material originalMaterial;

        // The currently running coroutine.
        private Coroutine flashRoutine;

        void Start()
        {
            // Get the SpriteRenderer to be used,
            // alternatively you could set it from the inspector.
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Get the material that the SpriteRenderer uses, 
            // so we can switch back to it after the flash ended.
            originalMaterial = spriteRenderer.material;
        }
    private void Update()
    {
        if (isFlashing) {
            flashMaterial.SetFloat("_FlashAmount", flashCurve.Evaluate(flashFrame));
            flashFrame += 2* Time.deltaTime;
        }
    }

    public void Flash()
        {
            // If the flashRoutine is not null, then it is currently running.
            if (flashRoutine != null)
            {
                // In this case, we should stop it first.
                // Multiple FlashRoutines the same time would cause bugs.
                StopCoroutine(flashRoutine);
            }

            // Start the Coroutine, and store the reference for it.
            flashRoutine = StartCoroutine(FlashRoutine());
        }

        private IEnumerator FlashRoutine()
        {
        print("Flash");
        // Swap to the flashMaterial.
        spriteRenderer.material = flashMaterial;
        isFlashing = true;

        


            // Pause the execution of this function for "duration" seconds.
            yield return new WaitForSeconds(duration);
        isFlashing = false;
        flashFrame = 0;
            // After the pause, swap back to the original material.
            spriteRenderer.material = originalMaterial;

            // Set the routine to null, signaling that it's finished.
            flashRoutine = null;
        }
    }