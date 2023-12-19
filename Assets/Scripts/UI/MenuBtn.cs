using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuBtn : MonoBehaviour
{
    public GameObject content;

    public void Click()
    {
        if (content != null)
        {
            SoundController.inst.UISound(0);

            if (UIController.inst.contents.Count > 0)
            { UIController.inst.contents[0].gameObject.SetActive(false); }
            content.SetActive(true);
        }
        else // start
        {
            SoundController.inst.UISound(14);
            GameController.inst.SceneChange("NameSetScene");
        }
    }

    public void UpdateUI(bool setActive)
    {
        gameObject.SetActive(setActive);
        content.SetActive(false);
    }
}
