using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsEnableSound : MonoBehaviour
{
    private void OnEnable()
    { SoundController.inst.UISound(2); }

    private void OnDisable()
    { SoundController.inst.UISound(2); }
}
