using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [SerializeField] private Material whiteMaterial;
    [SerializeField] private int flashCount = 2;
    [SerializeField] private float flashDuration = 0.08f;

    private SpriteRenderer sr;
    private Material originalMaterial;

    public float TotalDuration => flashCount * flashDuration * 2f;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.sharedMaterial;
    }
    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }
    private IEnumerator FlashRoutine()
    {
        for (int i = 0; i < flashCount; i++)
        {
            sr.sharedMaterial = whiteMaterial;
            yield return new WaitForSeconds(flashDuration);
            sr.sharedMaterial = originalMaterial;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
