using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgText : MonoBehaviour
{
    private WaitForSeconds wait = new WaitForSeconds(0.01f);
    private TextMeshPro tmp;
    private Color alpha;

    private float time = 1f;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();

        alpha = new Color32(255, 50, 50, 1);
    }

    private void OnEnable()
    {
        StartCoroutine(CoUpdate());

        Invoke(nameof(ReturnTMPObject), 1);
    }

    private IEnumerator CoUpdate()
    {
        alpha.a = 0.5f;
        tmp.color = alpha;

        for (float t = 0; t < time; t += 0.01f)
        {
            float normalizedTime = t / time; // 정규화된 시간

            transform.Translate(Vector3.up * normalizedTime * 0.1f);
            alpha.a = Mathf.Lerp(1f, 0f, normalizedTime * 2); // Mathf.Lerp 함수를 사용하여 서서히 감소

            tmp.color = alpha;
            
            yield return wait;
        }
    }

    private void ReturnTMPObject()
    {
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
