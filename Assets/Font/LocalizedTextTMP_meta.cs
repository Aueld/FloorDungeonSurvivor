using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedTextTMP_meta : MonoBehaviour
{
    [Header("GUI������ üũ")]
    public bool isUiType = false;

    [Space]
    [Header("�ٲ� �ؽ�Ʈ-(����, �ѱ�, �Ϻ���)")]
    public List<string> changeTexts;

    [Header("�ؽ�Ʈ ��Ʈ ������-(����, �ѱ�, �Ϻ���)")]
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
