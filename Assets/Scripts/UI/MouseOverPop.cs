using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverPop : MonoBehaviour
{
    private void OnEnable()
    {
        SoundController.inst.UISound(6);
    }
}
