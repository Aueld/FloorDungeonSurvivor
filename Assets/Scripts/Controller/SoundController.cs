using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundController : MonoBehaviour{
    public static SoundController inst;
    public AudioSource BGM, Effect, VoiceA, VoiceB, VoiceC, VoiceO, UI;
    public AudioClip[] BGMClip, EffectClip, AClip, BClip, CClip, OClip, UISoundClip, tests;



    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (inst != this)
            { Destroy(gameObject); }
        }
    }


    public void StartBGM(int numb) //BGM 재생 및 변경
    {
        if (numb.Equals(-100))
        {
            if (BGM.isPlaying)
            { BGM.DOFade(0f, 1f).OnComplete(() => BGM.Stop()); }
        }
        else
        {
            if (BGM.isPlaying)
            {
                if (!BGM.clip.Equals(BGMClip[numb]))
                {
                    if (StoryController.inst != null)
                    { StoryController.inst.uiOn = false; }
                    BGM.DOFade(0f, 1f).OnComplete(() =>
                    {
                        if (StoryController.inst != null)
                        { StoryController.inst.uiOn = true; }
                        BGM.clip = BGMClip[numb];
                        BGM.Play();
                        BGM.DOFade(DataController.duSettingData[2].value * DataController.duSettingData[8].value, 1f);
                    });
                }
            }
            else
            {
                BGM.DOPause();
                BGM.DOKill();
                BGM.volume = 0;
                BGM.clip = BGMClip[numb];
                BGM.DOFade(DataController.duSettingData[2].value * DataController.duSettingData[8].value, 1f);
                BGM.Play();
            }
        }
    }

    public void EffectSound(int numb) // 효과음 재생
    {
        if (!numb.Equals(-100))
        {
            if (numb.Equals(-1))
            {
                if (Effect.loop)
                {
                    StoryController.inst.endSound = false;
                    Effect.DOFade(0f, 1f).OnComplete(() =>
                    {
                        Effect.Stop();
                        StoryController.inst.endSound = true;
                    });
                }
                else
                { Effect.Stop(); }
            }
            else
            {
                if (EffectClip[numb].name.Contains("loop"))
                {
                    Effect.loop = true;

                    if (Effect.isPlaying)
                    {
                        if (Effect.clip != null)
                        {
                            if (!Effect.clip.Equals(EffectClip[numb]))
                            {
                                StoryController.inst.endSound = false;
                                Effect.DOFade(0f, 1f).OnComplete(() =>
                                {
                                    Effect.clip = EffectClip[numb];
                                    Effect.DOFade(DataController.duSettingData[8].value * DataController.duSettingData[3].value, 1f).OnComplete(()=> StoryController.inst.endSound = true);
                                    Effect.Play();
                                });
                            }
                        }
                    }
                    else
                    {
                        StoryController.inst.endSound = false;
                        Effect.clip = EffectClip[numb];
                        Effect.DOFade(DataController.duSettingData[8].value * DataController.duSettingData[3].value, 1f).OnComplete(()=> StoryController.inst.endSound = true);
                        Effect.Play();
                    }
                }
                else
                {
                    Effect.loop = false;
                    Effect.volume = DataController.duSettingData[8].value * DataController.duSettingData[3].value;
                    Effect.PlayOneShot(EffectClip[numb]);
                }
            }
        }
        //else
        //{ Effect.Stop(); }
    }

    public void StopVoice() // 더빙 중지
    {
        if (VoiceA.isPlaying)
        { VoiceA.Stop(); }
        if (VoiceB.isPlaying)
        { VoiceB.Stop(); }
        if (VoiceC.isPlaying)
        { VoiceC.Stop(); }
        if (VoiceO.isPlaying)
        { VoiceO.Stop(); }
    }


    //0:menuClick  1:미니게임 카운팅   2:팝업 온 오프   3:미니게임시작시 OnEnable  4:쓰레기버릴때    5:쓰레기 잘못버릴때     6:마우스오버    7:대기실넥스트버튼   8:대기실책넘김    9:대기실책닫기   10:소코바움직임(캐릭터)   11:소코반움직임(물건)
    //12:미니게임 리셋    13:미니게임 스킵 	14:GameStart  15:소코반캐릭터터짐 16:다이어리 오픈  17:미니게임 승리  18:미니게임 패배

    public void UISound(int numb) //UI효과음 및 미니게임 효과음 
    {
        if (UISoundClip[numb] != null)
        { UI.PlayOneShot(UISoundClip[numb]); }
    }
    public void UISoundStop()
    {
        if(UI.isPlaying)
        { UI.Stop(); }
    }

    public void TestVoice(int id) //설정창 보이스 재생
    {
        int voiceKey = (int)DataController.duSettingData[12].value;

        if (voiceKey.Equals(0)) //한국어
        {
            if (id.Equals(0))
            { VoiceSound("A", tests[id]); }
            else if (id.Equals(1))
            { VoiceSound("B", tests[id]); }
            else if (id.Equals(2))
            { VoiceSound("C", tests[id]); }
            else
            { VoiceSound("D", tests[id]); }
        }
        else //일본어
        {
            if (id.Equals(0))
            { VoiceSound("A", tests[id + 4]); }
            else if (id.Equals(1))
            { VoiceSound("B", tests[id + 4]); }
            else if (id.Equals(2))
            { VoiceSound("C", tests[id + 4]); }
            else
            { VoiceSound("D", tests[id + 4]); }
        }
    }

    public void VoiceSound(string kind, AudioClip clip) //더빙 재생
    {
        if (VoiceA.isPlaying)
        { VoiceA.Stop(); }
        if (VoiceB.isPlaying)
        { VoiceB.Stop(); }
        if (VoiceC.isPlaying)
        { VoiceC.Stop(); }
        if (VoiceO.isPlaying)
        { VoiceO.Stop(); }

        if (clip != null)
        {
            if (kind.Equals("A"))
            { VoiceA.PlayOneShot(clip); }
            else if (kind.Equals("B"))
            { VoiceB.PlayOneShot(clip); }
            else if (kind.Equals("C"))
            { VoiceC.PlayOneShot(clip); }
            else if(kind.Equals("Z"))
            {
                VoiceO.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[7].value * 0.5f;
                VoiceO.PlayOneShot(clip);
            }
            else
            {
                VoiceO.volume = DataController.duSettingData[8].value * DataController.duSettingData[9].value * DataController.duSettingData[7].value;
                VoiceO.PlayOneShot(clip);
            }
        }
    }

}
