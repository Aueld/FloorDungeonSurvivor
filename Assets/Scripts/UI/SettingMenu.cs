using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Image thisImage;
    public SettingMenu otherMenu;
    public int id;

    private void Start()
    {
        if (id.Equals(0))
        {
            if (DataController.duSettingData[0].value.Equals(0))
            { Click(); }
            else
            { otherMenu.Click(); }
        }
        else if (id.Equals(1))
        {
            if (DataController.duSettingData[11].value.Equals(0))
            { Click(); }
            else
            { otherMenu.Click(); }
        }
        else if (id.Equals(2))
        {
            if (GameController.inst.isStory)
            { Click(); }
            else
            { otherMenu.Click(); }
        }
    }


    public void Click()
    {
        otherMenu.Off();
        thisImage.color = SetColor.purple;
    }

    public void Off()
    { thisImage.color = SetColor.darkGray; }
}
