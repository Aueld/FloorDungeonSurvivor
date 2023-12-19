using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto : MonoBehaviour
{
    WaitForSeconds one;
    public GameObject other;

    private void Awake()
    { one = new WaitForSeconds(1f); }
    
    private void OnEnable()
    {
        if (ieAuto != null)
        { StopCoroutine(ieAuto); }
        ieAuto = StartCoroutine(AutoCor());
    }

    private void OnDisable()
    { StopCor(); }

    public void StopCor()
    {
        if (ieAuto != null)
        { StopCoroutine(ieAuto); }
    }

    Coroutine ieAuto;
    IEnumerator AutoCor()
    {
        bool flag = true;
        while (flag)
        {
            if (!other.activeInHierarchy)
            {
                if (CsvLoader.dStoryData.ContainsKey(StoryController.inst.talkNumb-1))
                {
                    int length = CsvLoader.dSelectedStoryTextData[StoryController.inst.talkNumb-1].Length;
                    float baseTime = length * DataController.duSettingData[1].value * 0.1f;

                    if (!CsvLoader.dStoryData[StoryController.inst.talkNumb - 1].Voice.Equals(string.Empty))
                    {
                        yield return new WaitForSeconds(baseTime + 1.5f); //텍스트 스피드
                    }
                    else
                    { yield return new WaitForSeconds(baseTime + 1.5f); }//텍스트 스피드

                    StoryController.inst.UpdateNextTalk();
                }
                else
                {
                    if(StoryController.inst.talkNumb.Equals(0))
                    { StoryController.inst.Click(); }
                    yield return new WaitForSeconds(10f);
                }
            }
            else
            { flag = false; }
        }
    }
}
