using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public enum buildType { Test, CSVTest, SteamProduct, StoveProduct };

public class GameController : MonoBehaviour
{
    public static GameController inst;

    public GameObject Player;

    public string nowFileName, nowSceneName;
    
    //모드 및 불러오기
    //모드에 따라 CSV 경로가 바뀜
    public bool isStory, isEndless;
    public int day, week, feelTotal;

    private void Awake()
    {
        isEndless = false;

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

        nowSceneName = "StartScene";
    }

    public void SetMode(bool _mode) // 모드설정
    { 
        isStory = _mode;
    }

    private void Start()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }

    public void GameStartSet() // 게임 최초 시작시 설정
    {
        Invoke("StartSet", 0.5f);
    }

    private void StartSet()
    {
        //for (int i = 0; i < UIController.inst.saves.Count; i++) // save 버튼 생성
        //{
        //    UIController.inst.saves[i].id = i;
        //    UIController.inst.saves[i].UpdateUI();
        //}

        // UI 버튼 리스너 부여

        AlwaysOnTop.inst.AssignTopmostWindow(); // 설정에 따른 alwaysOnTop 적용여부
    }

    public void SceneChange(string sceneName) // 씬 변경
    {
        UIController.inst.BlackInOut(false); // 씬 변경시 블랙 페이드인

        StartCoroutine(SceneChangeCor(sceneName));
    }

    IEnumerator SceneChangeCor(string sceneName)
    {
        SoundController.inst.StartBGM(-100);
        SoundController.inst.EffectSound(-1);
        SoundController.inst.VoiceSound("A", null);

        yield return new WaitForSeconds(1f);
        UIController.inst.auto.gameObject.SetActive(false);
        UIController.inst.auto2.gameObject.SetActive(false);

        SceneManager.LoadScene(sceneName);

        UIController.inst.UICanvas.worldCamera = Camera.main;

        nowSceneName = sceneName;
        UIController.inst.BlackInOut(true);

        UIController.inst.betweenMenuPop.SetActive(false);
        UIController.inst.storyESC.SetActive(false);
    }
}
