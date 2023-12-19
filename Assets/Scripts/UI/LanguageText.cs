using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    public Text txt;
    public int id;

    private void Start()
    {
        txt.text = CsvLoader.dSelectedLanguage[id];
    }

    public void SetUpText()
    {
        txt.text = CsvLoader.dSelectedLanguage[id];
    }
}
