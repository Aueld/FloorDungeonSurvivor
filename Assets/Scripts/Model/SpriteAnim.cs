using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    public Sprite[] sprites, dead;
    private SpriteRenderer spr;
    WaitForSeconds sec;
    public float animSpeed;
    private Image img;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        if (spr == null)
        { img = GetComponent<Image>(); }
    }
    public void Start()
    {
        if (spr != null)
        { StartAnim(sprites); }
        else
        { StartCoroutine(ieImgAnimating(sprites)); }
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

    IEnumerator ieImgAnimating(Sprite[] animspr)
    {
        int i = 0;
        sec = new WaitForSeconds(animSpeed);
        while (true)
        {
            img.sprite = animspr[i];
            yield return sec;
            i++;
            if (animspr.Length <= i)
            {
                i = 0;
            }
        }
    }
}
