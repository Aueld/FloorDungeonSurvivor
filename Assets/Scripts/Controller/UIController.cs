using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using System;

using UnityEngine.InputSystem;


public class UIController : MonoBehaviour{
    public static UIController inst;


    public List<Contents> contents = new List<Contents>();
    public Canvas UICanvas;
    public Transform startMenu, saveGroup;

    public Image black, nowVoiceImage;
    public Image[] startImage;
    public Text nowBgmText;
    public Button cgPopBtn;
    public SettingSlider[] settingSliders;

    public GameObject exitPop, firstNameSet, firstModeSet, storyESC, logPop, goFirstPop, menuPop, betweenMenuPop;

    public SaveLoadDeletePop saveLoadPop;

    public List<SaveBtn> saves;
    public List<BGMBtn> bgms;

    public Auto auto, auto2;

    public int bgmNumb = 0;
    public Slider bgmSlider;
    public SettingMenu[] modeBtns;

    public Button[] languageBtns;
    public List<Font> boldFonts;
    public List<Font> regularFonts;

    //K
    //public List<Selectable> MainMenuSelectables;
    //public GameObject MainMenuFirst;

    //public List<Selectable> LoadSelectables;
    //public GameObject LoadFirst;

    //public List<Selectable> LanguageSelectables;
    //public GameObject LaguageFirst;

    //public List<Selectable> SettingSelectables;
    //public GameObject SettingFirst;

    //public List<Selectable> PauseSelectables;
    //public GameObject PauseFirst;

    //public List<Selectable> ExitWarnigSelectables;
    //public GameObject ExitWarningFirst;
    //K


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
        startImage[0].gameObject.SetActive(true);
        startImage[0].DOFade(0f, 1.5f).OnComplete(() => startImage[0].gameObject.SetActive(false));
 
    }

  
    void SetOffStartImage()
    {
        startImage[1].DOFade(0f, 2f).OnComplete(() => startImage[1].gameObject.SetActive(false));
    }

    public void SaveLoadPopSet(SaveBtn btn)
    {
        saveLoadPop.storyImage.sprite = btn.noneImage.sprite;
        saveLoadPop.storyText.text = btn.story.text;
        saveLoadPop.numberText.text = btn.numb.text;
        saveLoadPop.timeText.text = btn.time.text;
        saveLoadPop.thisData = btn.thisData;
        saveLoadPop.gameObject.SetActive(true);
    }

    //씬 변경시 블랙 페이드 인&아웃
    public void BlackInOut(bool isStart)
    {
        black.DOPause();
        black.DOKill();
        if (isStart)
        {
            black.color = Color.black;

            black.DOFade(0f, 1f).OnComplete(() => black.gameObject.SetActive(false));

            if (GameController.inst.nowSceneName.Equals("StartScene"))
            { startMenu.gameObject.SetActive(true); }
            else if (GameController.inst.nowSceneName.Equals("StoryScene"))
            { startMenu.gameObject.SetActive(false); }
            else if (GameController.inst.nowSceneName.Equals("NameSetScene"))
            { startMenu.gameObject.SetActive(false); }
        }
        else
        {
            black.color = Color.clear;
            black.gameObject.SetActive(true);
            black.DOFade(1f, 1f);
        }
    }

    //public void MenuBtnClick()
    //{
    //    menuBtn.interactable = false;

    //    if(menuGroup.gameObject.activeInHierarchy)
    //    {
    //        menuGroup.DOLocalMoveX(1260, 0.5f).OnComplete(() =>
    //        {
    //            menuGroup.gameObject.SetActive(false);
    //            menuBtn.interactable = true;
    //        });
    //    }
    //    else
    //    {
    //        menuGroup.gameObject.SetActive(true);
    //        menuGroup.DOLocalMoveX(960, 0.5f).OnComplete(() => menuBtn.interactable = true);
    //    }
    //}

    //스토리씬에서 처음으로 가기 버튼
    public void StoryGoFirst()
    {
        StoryController.inst.talkNumb = 0;
        StoryController.inst.Click();
    }

    //메인화면에서 bgm조작
    public void BGMPlayBefore()
    {
        SoundController.inst.UISound(0);
        if (bgmNumb.Equals(0))
        { bgmNumb = bgms.Count - 1; }
        else
        { bgmNumb--; }
        
        bgms[bgmNumb].Select();
    }

    public void BGMPlay()
    {
        SoundController.inst.UISound(0);
        bgms[bgmNumb].Select();
    }

    public void BGMStop()
    {
        SoundController.inst.UISound(0);
        SoundController.inst.StartBGM(-100);
    }

    public void BGMAfter()
    {
        SoundController.inst.UISound(0);
        if (bgmNumb.Equals(bgms.Count - 1))
        { bgmNumb = 0; }
        else
        { bgmNumb++; }
        
        bgms[bgmNumb].Select();
    }

    //메인화면에서 cg 확인
    public void CGPopUp(Sprite spr)
    {
        cgPopBtn.interactable = false;
        cgPopBtn.image.sprite = spr;
        cgPopBtn.image.color = SetColor.whiteClear;
        cgPopBtn.gameObject.SetActive(true);
        cgPopBtn.image.DOFade(1f, 0.5f).OnComplete(() => cgPopBtn.interactable = true);
    }
    public void CGPopClose()
    { cgPopBtn.image.DOFade(0f, 0.5f).OnComplete(() => cgPopBtn.gameObject.SetActive(false)); }

    //모드선택
    public void ModeSet(bool isStreamer)
    {
        GameController.inst.isStory = isStreamer;
        if(isStreamer)
        { modeBtns[0].Click(); }
        else
        { modeBtns[1].Click(); }
    }


    //세이브 작동
    public void Save()
    {
        for(int i = 1; i < saves.Count; i++)
        {
        }
    }

    //오토세이브 작동
    public void QuickSave()
    {
        if (GameController.inst.nowSceneName.Equals("StoryScene"))
        {

        }
    }

    private void OnApplicationQuit()
    { QuickSave(); }


    //풀스크린 모드 
    public void SetViewSetting(int numb)
    { DataController.inst.SetSettingData(0, numb); InputController.inst.SetScrennSize(); }

    //alwaysOnTop
    public void SetAlwayOnTop(int numb)
    {
        DataController.inst.SetSettingData(11, numb);
        AlwaysOnTop.inst.AssignTopmostWindow();
    }


    public void GoMain()
    {
        QuickSave();

        GameController.inst.SceneChange("StartScene");
    }

    public void GoEnd()
    {
        QuickSave();
        GameController.inst.SceneChange("EndingScene");
    }

    public void GoNext()
    {
        QuickSave();
        GameController.inst.SceneChange("BetweenScene");
    }

    public void QuickStart()
    { GameController.inst.SceneChange("StoryScene"); }

    public void Exit()
    { Application.Quit(); }


    //설정창 슬라이더
    public void SettingBtnAddListener()
    {
        for (int i = 0; i < settingSliders.Length; i++)
        {
            settingSliders[i].slider.value = DataController.duSettingData[i + 1].value;
            settingSliders[i].id = i + 1;
            settingSliders[i].AddListener();
        }
    }

    public void SettingBtnUpdateUI()
    {
        for (int i = 0; i < settingSliders.Length; i++)
        { settingSliders[i].slider.value = DataController.duSettingData[i + 1].value; }
    }

    //팝업 닫기
    public void OtherContentsOff()
    {
        for (int i = contents.Count - 1; i > -1; i--)
        {
            if (contents[i].gameObject.activeInHierarchy.Equals(true))
            {
                contents[i].SetOff();
                break;
            }
        }
    }
    /* Navigation
    public void EnableNavigation(List<Selectable> menuLayer)
    {
        DisableAllNavigation();
        foreach (var selectable in menuLayer)
        {
            selectable.interactable = true;
        }
    }

    public void DisableNavigation(List<Selectable> menuLayer)
    {
        try
        {
            if(menuLayer != null)
            {
                try
                {
                    foreach(var selectable in menuLayer)
                    {
                        try
                        {
                            selectable.interactable = false;
                        }
                        catch (NullReferenceException)
                        {
                            Debug.Log("DisableNavigation: at interactable assignment");
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Debug.Log("DisableNavigation: at foreach loop");
                }
            }
            else
            {
                Debug.Log("Null List");
                menuLayer.Clear();
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("DisableNavigation: at list null check");
        }
    }

    public void DisableAllNavigation()
    {
        DisableNavigation(MainMenuSelectables);
        DisableNavigation(LoadSelectables);
        DisableNavigation(SettingSelectables);
    }
    public bool CheckNavigation(List<Selectable> menuLayer)
    {
        bool menuEnabled = false;
        try
        {
            if (menuLayer != null)
            {
                try
                {
                    foreach (var selectable in menuLayer)
                    {
                        try
                        {
                            if (selectable.interactable && selectable.IsActive())
                                menuEnabled = true;
                        }
                        catch (NullReferenceException)
                        {
                            Debug.Log("CheckNavigation: at interactable/active check");
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Debug.Log("CheckNavigation: at foreach loop");
                }
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("CheckNavigation: at list null check");
        }

        return menuEnabled;
    }

    public bool CheckEmptyNavigation(List<Selectable> menuLayer)
    {
        bool menuEmpty = false;

        if (menuLayer.Count > 0)
        {
            foreach (var selectable in menuLayer)
            {
                if (selectable == null)
                    menuEmpty = true;
            }
        }
        else
            menuEmpty = true;

        return menuEmpty;
    }

    public int NavigationIndex(List<Selectable> menuLayer, GameObject current)
    {
        int indexFound = -1;
        for (int i = 0; i < menuLayer.Count; i++)
        {
            if (menuLayer[i].gameObject == current)
                indexFound = i;
        }

        return indexFound;
    }
    */
}
