using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(Click);
    }

    void Click()
    { SoundController.inst.UISound(0); }
}
