using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedTextTMP_meta : MonoBehaviour
{
    [Header("GUI용인지 체크")]
    public bool isUiType = false;

    [Space]
    [Header("바뀔 텍스트-(영어, 한글, 일본어)")]
    public List<string> changeTexts;

    [Header("텍스트 폰트 싸이즈-(영어, 한글, 일본어)")]
    public List<int> changeFontSizes;

    private TextMeshPro mainText;
    private TextMeshProUGUI mainTextUI;

    

    private void Awake()
    {
        /*
        //int localizedKey = ES3.Load<int>("Localized");
        string text = changeTexts[localizedKey].Replace("\\n", "\n");

        if (isUiType)
        {
            mainTextUI = GetComponent<TextMeshProUGUI>();
            mainTextUI.text = text;
            mainTextUI.fontSize = changeFontSizes[localizedKey];
        }
        else
        {
            mainText = GetComponent<TextMeshPro>();
            mainText.text = text;
            mainText.fontSize = changeFontSizes[localizedKey];
        }
        */
    }
}
