using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnim : MonoBehaviour
{
    public Sprite[] sprites, dead;
    private Image spr;
    WaitForSeconds sec;
    public float animSpeed;

    private void Awake()
    {
        spr = GetComponent<Image>();
    }
    public void Start()
    {
        StartAnim(sprites);
    }

    public void StartAnim(Sprite[] _sprites)
    {
        if (crAnimating != null)
        { StopCoroutine(crAnimating); }
        crAnimating = StartCoroutine(ieAnimating(_sprites));
    }

    public Coroutine crAnimating;
    IEnumerator ieAnimating(Sprite[] animspr)
    {
        int i = 0;
        sec = new WaitForSeconds(animSpeed);
        while (true)
        {
            spr.sprite = animspr[i];
            yield return sec;
            i++;
            if (animspr.Length <= i)
            {
                i = 0;
            }
        }
    }
}
