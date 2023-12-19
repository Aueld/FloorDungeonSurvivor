using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputController : MonoBehaviour
{
    public static InputController inst;

    int setWidth = 1920, setHeight = 1080, deviceWidth, deviceHeight;
    float set, newWidth, newHeight, device;
    public bool isSpace = false;

    WaitForSeconds time;
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
        time = new WaitForSeconds(1f);
    }


    void Update()
    {
        if (GameController.inst.nowSceneName.Equals("StoryScene"))
        {
            if (Input.GetKeyDown(KeyCode.Space)) // 다음 대사보기
            { StoryController.inst.Click(); }

            if (Input.GetKey(KeyCode.LeftControl)) //빠른 자동실행
            {
                Time.timeScale = 15;
            }
            else
            {
                UIController.inst.auto2.gameObject.SetActive(false);
                Time.timeScale = 1;
            }

            if (Input.GetKey(KeyCode.Space))
            { isSpace = true; }
            else
            { isSpace = false; }

            if (Input.GetMouseButtonDown(1)) //대사창 숨기기
            {
                if (UIController.inst.contents.Count.Equals(0))
                { StoryController.inst.SetTalkBox(); }
            }
        }
        else
        { Time.timeScale = 1; }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!UIController.inst.contents.Count.Equals(0)) //팝업 띄워져있는 상태일 경우 팝업 닫기
            {
                for (int i = UIController.inst.contents.Count - 1; i >= 0; i--)
                {
                    if (UIController.inst.contents[i].gameObject.activeInHierarchy)
                    {
                        UIController.inst.contents[i].SetOff();
                        break;
                    }
                }
            }
            else //팝업 띄워져있는 상태가 아닐 경우 메뉴 팝업 띄우기
            {
                if(GameController.inst.nowSceneName.Equals("BetweenScene"))
                {
                    UIController.inst.betweenMenuPop.SetActive(true);
                }
                else if (GameController.inst.nowSceneName.Equals("StoryScene"))
                {
                    if (!StoryController.inst.videoPlay)
                    {
                        if (StoryController.inst.talkObj.transform.localPosition.y.Equals(-1000))
                        { StoryController.inst.talkObj.transform.DOLocalMoveY(-540, 0.5f).OnComplete(() => StoryController.inst.uiOn = true); }
                        UIController.inst.storyESC.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                { UIController.inst.exitPop.gameObject.SetActive(true); }
            }
        }
    }
    
    public void StartSetScreenSize()
    { StartCoroutine(SetScreenSizeCor()); }

    IEnumerator SetScreenSizeCor() // 스크린사이즈조정
    {
        WaitForSeconds one = new WaitForSeconds(1f);
        WaitForSeconds zeroOne = new WaitForSeconds(0.1f);

        StartSetScrennSize();
        yield return one;
        StartSetScrennSize();
        yield return one;
        while (true)
        {
            if (!DataController.duSettingData[0].value.Equals(0))
            { SetScrennSize(); }
            

            yield return zeroOne;
        }
    }

    public void StartSetScrennSize()// 스크린사이즈조정
    {
        bool isFull = true;

        if (DataController.duSettingData[0].value.Equals(0))
        { isFull = true; }
        else
        { isFull = false; }

        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
        set = (float)setWidth / setHeight;
        device = (float)deviceWidth / deviceHeight;

        if (isFull)
        { Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow); }
        else
        {
            if (deviceHeight > deviceWidth)
            { Screen.SetResolution(deviceWidth, deviceWidth * 16 / 9, FullScreenMode.Windowed); }
            else
            { Screen.SetResolution(deviceHeight * 16 / 9, deviceHeight, FullScreenMode.Windowed); }
        }

        if (device > set)
        {
            float w = set / device;
            float x = (1 - w) / 2;
            Camera.main.rect = new Rect(x, 0.0f, w, 1.0f);
        }
        else
        {
            float h = device / set;
            float y = (1 - h) / 2;
            Camera.main.rect = new Rect(0.0f, y, 1.0f, h);
        }
    }

    public void SetScrennSize()// 스크린사이즈조정
    {
        bool isFull = true;

        if (DataController.duSettingData[0].value.Equals(0))
        { isFull = true; }
        else
        { isFull = false; }

        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
        set = (float)setWidth / setHeight;
        device = (float)deviceWidth / deviceHeight;

        if (isFull)
        { Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow); }
        else
        {
            if (deviceHeight > deviceWidth)
            { Screen.SetResolution(deviceWidth, deviceWidth * 16 / 9, FullScreenMode.Windowed); }
            else
            { Screen.SetResolution(deviceHeight * 16 / 9, deviceHeight, FullScreenMode.Windowed); }
        }

        if (device > set)
        {
            float w = set / device;
            float x = (1 - w) / 2;
            Camera.main.rect = new Rect(x, 0.0f, w, 1.0f);
        }
        else
        {
            float h = device / set;
            float y = (1 - h) / 2;
            Camera.main.rect = new Rect(0.0f, y, 1.0f, h);
        }
    }
}

