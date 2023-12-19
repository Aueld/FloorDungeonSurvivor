using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlurTimer : MonoBehaviour
{
    public float shakePower;
    public Material material;
    bool Out = false;

    public void StartBlur(float size)
    {
        StartCoroutine(BlurStartCoroutine(size));
    }
    public void EndBlur()
    {
        StartCoroutine(BlurEndCoroutine());
    }

    protected IEnumerator BlurStartCoroutine(float size)
    {
        while (shakePower < size && !Out)
        {
            shakePower += Time.deltaTime * 10f;
            material.SetFloat("_Size", shakePower);

            yield return null;
        }
    }

    protected IEnumerator BlurEndCoroutine()
    {
        Out = true;
        while (shakePower > 0.1f)
        {
            shakePower -= Time.deltaTime * 30f;
            material.SetFloat("_Size", shakePower);

            yield return null;
        }
        Out = false;
    }
    private void OnDisable()
    {
        shakePower = 0;
        material.SetFloat("_Size", shakePower);
    }
}

