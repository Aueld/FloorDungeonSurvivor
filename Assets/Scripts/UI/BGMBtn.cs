using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMBtn : MonoBehaviour
{
    public int id;
    public Text nameText;

    public void Click()
    {
        UIController.inst.bgmSlider.value = 0f;
        SoundController.inst.StartBGM(id);
        UIController.inst.nowBgmText.text = nameText.text;
        UIController.inst.bgmNumb = transform.GetSiblingIndex();
    }

    public void Select()
    {
        UIController.inst.bgmSlider.value = 0f;
        SoundController.inst.StartBGM(id);
        UIController.inst.nowBgmText.text = nameText.text;
    }

    public void UpdateUI()
    { nameText.text = string.Format("[No.{0}]", id+1); }
}
