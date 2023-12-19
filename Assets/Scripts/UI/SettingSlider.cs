using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    public int id;
    public Slider slider;


    public void AddListener()
    {
        SetSlider();
        slider.onValueChanged.AddListener(delegate { SetSlider(); });
    }

    public void SetSlider()
    {
        DataController.inst.SetSettingData(id, slider.value);
        // ID : 1-텍스트 스피드, 2-배경음, 3-효과음, 4-A, 5-B, 6-C, 7-Other, 8 -master, 9 - all voice

        if (id.Equals(2))
        { SoundController.inst.BGM.volume = DataController.duSettingData[8].value * DataController.duSettingData[2].value; }
        else if (id.Equals(3))
        {
            SoundController.inst.Effect.volume = DataController.duSettingData[8].value * DataController.duSettingData[3].value;
            SoundController.inst.UI.volume = DataController.duSettingData[8].value * DataController.duSettingData[3].value;
        }
        else if (id.Equals(4))//다혜
        { SoundController.inst.VoiceA.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[4].value; }
        else if (id.Equals(5))//원석이형
        { SoundController.inst.VoiceB.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[5].value; }
        else if (id.Equals(6))//이준엽
        { SoundController.inst.VoiceC.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[6].value; }
        else if (id.Equals(7))//천수연
        { SoundController.inst.VoiceO.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[7].value; }
        else if (id.Equals(8))
        {
            SoundController.inst.BGM.volume = DataController.duSettingData[8].value * DataController.duSettingData[2].value;
            SoundController.inst.Effect.volume = DataController.duSettingData[8].value * DataController.duSettingData[3].value;
            SoundController.inst.UI.volume = DataController.duSettingData[8].value * DataController.duSettingData[3].value;

            SoundController.inst.VoiceA.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[4].value;
            SoundController.inst.VoiceB.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[5].value;
            SoundController.inst.VoiceC.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[6].value;
            SoundController.inst.VoiceO.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[7].value;
        }
        else if (id.Equals(9))
        {
            SoundController.inst.VoiceA.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[4].value;
            SoundController.inst.VoiceB.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[5].value;
            SoundController.inst.VoiceC.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[6].value;
            SoundController.inst.VoiceO.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[7].value;
        }
    }
}
