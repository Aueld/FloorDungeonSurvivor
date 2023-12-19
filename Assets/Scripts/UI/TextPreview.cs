using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextPreview : MonoBehaviour
{
    public Text txt;

    //[syw]
    //[Header("바뀔 폰트-(한글, 일본어, 영어)")]
    [Header("바뀔 폰트-(한글, 일본어, 영어, 간체, 번체)")]
    //[syw]
    public List<Font> changeFonts;

    //[syw]
    //[Header("바뀔 텍스트-(한글, 일본어, 영어)")]
    [Header("바뀔 텍스트-(한글, 일본어, 영어, 간체, 번체)")]
    //[syw]
    public List<string> changeTexts;

    string texts;
    Coroutine cor;

    private void OnEnable()
    {
        cor = StartCoroutine(TextPreviewCor());
    }

    private void OnDisable()
    {
        if(cor != null)
        { StopCoroutine(cor); }
    }

    IEnumerator TextPreviewCor()
    {
        int localizedKey = (int)DataController.duSettingData[10].value;
        texts = changeTexts[localizedKey].Replace("\\n", "\n");
        txt.font = changeFonts[localizedKey];

        while (true)
        {
            txt.text = string.Empty;
            txt.DOText(texts, 3.7f * DataController.duSettingData[1].value, false);
            yield return new WaitForSeconds(DataController.duSettingData[1].value * 3.7f + 1);
        }
    }
}
