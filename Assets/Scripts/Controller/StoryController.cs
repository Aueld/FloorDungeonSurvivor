using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Coffee.UIEffects;
using UnityEngine.Video;
using TMPro;


public class StoryController : MonoBehaviour{
    public static StoryController inst;

    public GameObject talkObj, otherEventGroup;
    public Image black, talkLastImg, bgImg, beforeBgImg, imagePopUpGroup, nameTag, newPopUpGroup;
    public Character A, B, C, D, E, F;
    public Text nameText, talkText, dayText;
    public Button menuBtn;
    public Material grayScale;
    public int talkNumb;
    public string last;
    public bool endChangeImg = true, readyRead = true, endCharacter = true, uiOn = true, endSound = true, videoPlay = false;

    public Auto autoObj;

    public Transform transitionPos, popUpDrawing;
    public UITransitionEffect bgEffect;
    public Texture[] textures;
    public BlurTimer blur, backBlur;
    public Canvas canvas, videoCanvas;

    public TMP_Text TMP_Text;

    public VideoPlayer videoPlayer;
    public VideoClip[] videos;
    public RawImage videoBlack;

    public List<TMPro.TMP_FontAsset> tmp_Fonts;
    public TextMeshProUGUI textMessageUI;

    public List<Font> fonts;

    private void Awake()
    {
        if (inst == null)
        { inst = this; }
        else
        {
            if (inst != this)
            { Destroy(gameObject); }
        }

        talkNumb = 0;
        talkLastImg.DOFade(1f, 1f).SetLoops(-1, LoopType.Yoyo);
        InputController.inst.SetScrennSize();

        grayScale.SetFloat("_GrayscaleAmount", 0f);

        System.GC.Collect();
        Resources.UnloadUnusedAssets();

        SetMessageText();
    }

    //textMessageUI
    public void SetMessageText()
    {
        int localizedKey = (int)DataController.duSettingData[10].value;

        textMessageUI.font = tmp_Fonts[localizedKey];
        dayText.font = fonts[localizedKey];
        nameText.font = UIController.inst.boldFonts[localizedKey];
    }

    private void OnEnable()
    {
        autoObj = UIController.inst.auto;
        UIController.inst.UICanvas.worldCamera = Camera.main;

        UIController.inst.black.gameObject.SetActive(true);
        UIController.inst.black.color = Color.black;

        if (!GameController.inst.isEndless) //스토리씬 시작시 텍스트 출력
        {
            uiOn = false;
            float t = 2.4f;

            int localizedKey = (int)DataController.duSettingData[10].value;

            if (GameController.inst.nowFileName.Equals("0_0"))
            {
              SetDayText(localizedKey, "이 게임은 노벨피아의 웹소설\n'게임 폐인 동거녀와 순애는 어떠신가요?'를\n원작으로 각색된 이야기입니다.",
                    "このゲームはノベルピアのウェブ小説、\n「同棲中のコミュ症ネトゲ女子との純愛はいかが？」を原作とし、\nストーリーを構成しています。",
                    "This game is an adaptation of the web novel 'The Chaste Love of Two Failed Gamer Roommates?'\nhosted on the website Novelpia.");
        
                t = 4.8f;
            }
            else if (GameController.inst.nowFileName.Equals("0_30"))
                SetDayText(localizedKey, "3년 후", "3年後", "Three years later");

            Invoke("DayText", t);
        }
    }

    public void SetDayText(int localizedKey, string kr, string jp, string en)
    {
        if (localizedKey.Equals(0))
            dayText.text = kr;
        else if (localizedKey.Equals(1)) //일본어
            dayText.text = jp;
        else if (localizedKey.Equals(2)) //영어
            dayText.text = en;
    }

    void DayText()
    {
        dayText.DOFade(0f, 2f).OnComplete(()=>
        {
            uiOn = true;
            UpdateNextTalk();
        });
    }

    public void Start()
    {
        CsvLoader.inst.LoadStoryData(GameController.inst.nowFileName);

        talkObj.transform.DOLocalMoveY(-540, 0.5f);
    }

    public void SetTalkBox() //대화창 보이기 안보이기
    {
        if (talkObj.transform.localPosition.y.Equals(-540))
        {
            uiOn = false;
            talkObj.transform.DOLocalMoveY(-1000, 0.5f);
        }
        else if (talkObj.transform.localPosition.y.Equals(-1000))
        { talkObj.transform.DOLocalMoveY(-540, 0.5f).OnComplete(()=> uiOn = true);  }
    }

    public void UpdateNextTalk() //다음 대사로 넘어가기
    {
      if (endChangeImg && readyRead && endCharacter && uiOn && endSound && !videoPlay)
        {
            TalkTextSet();
            BGSet();
            CharacterSet();
            OtherEventSet();
            SoundSet();
            talkNumb++;
        }
    }

    public void SoundSet() //사운드 출력
    {
        if (!talkNumb.Equals(0))
        {
            if (CsvLoader.dStoryData.ContainsKey(talkNumb))
            {
                int numb = CsvLoader.dStoryData[talkNumb].BGM;

                SoundController.inst.StartBGM(numb);
                SoundController.inst.EffectSound(CsvLoader.dStoryData[talkNumb].EffectSound);
            }
        }
    }

    public void MenuPop()
    {
        UIController.inst.menuPop.gameObject.SetActive(true);
    }

    public void OtherEventSet()  //효과
    {
        string tmpStr, strEtc;
        if (CsvLoader.dStoryData.ContainsKey(talkNumb))
        {
            for (int i = 0; i < 2; i++)
            {
                if (i.Equals(0))
                {
                    tmpStr = CsvLoader.dStoryData[talkNumb].OtherEvent;
                    strEtc = CsvLoader.dStoryData[talkNumb].Etc;
                }
                else
                {
                    tmpStr = CsvLoader.dStoryData[talkNumb].OtherEvent1;
                    strEtc = CsvLoader.dStoryData[talkNumb].Etc1;
                }

                switch (tmpStr)
                {
                    case "C": //다음으로 넘어가기
                        SoundController.inst.VoiceSound("A", null);
                        UIController.inst.GoNext();
                        break;
                    case "E": //엔딩으로 넘어가기
                        SoundController.inst.VoiceSound("A", null);
                        UIController.inst.GoEnd();
                        break;
                    case "S": //시작화면으로 넘어가기
                        SoundController.inst.VoiceSound("A", null);
                        UIController.inst.GoMain();
                        break;
                    case "EyeClose": //눈감는 효과
                        EyeClose();
                        break;
                    case "EyeOpen":  //눈뜨는 효과
                        EyeOpen();
                        break;
                    case "Blur":  //블러효과
                        Blur(float.Parse(strEtc));
                        break;
                    case "BGBlur": //배경만 블러
                        BGBlur(float.Parse(strEtc));
                        break;
                    case "Focus": //집중이미지
                        Focus(int.Parse(strEtc));
                        break;
                    case "Focus2": //집중이미지2
                        Focus2(int.Parse(strEtc));
                        break;
                    case "Remind": //흑백효과
                        grayScale.DOFloat(float.Parse(strEtc), "_GrayscaleAmount", 0.5f);
                        break;
                    case "CloseUp4": //확대
                        CloseUp4(strEtc);
                        break;
                    case "ZoomIn": //줌인
                        ZoomIn(strEtc);
                        break;
                    case "HandHeld": //핸드헬드
                        HandHeld(strEtc);
                        break;
                    case "Shake": //흔들림
                        endChangeImg = false;
                        bgImg.transform.parent.parent.transform.DOShakePosition(float.Parse(strEtc), new Vector3(20, 20, 0), 50).OnComplete(() => endChangeImg = true);
                        bgImg.transform.parent.parent.transform.DOShakeRotation(float.Parse(strEtc), new Vector3(0, 0, 5), 50);
                        break;
                    case "PopUp": //팝업이미지 
                        string before = string.Empty;
                        if (!talkNumb.Equals(0))
                        {
                            if (i.Equals(0))
                            { before = CsvLoader.dStoryData[talkNumb - 1].Etc; }
                            else
                            { before = CsvLoader.dStoryData[talkNumb - 1].Etc1; }
                        }
                        PopUp(strEtc, before);
                        break;
                    case "PopUpNew": //팝업이미지
                        PopUpNew(strEtc);
                        break;
                    case "PopUpDrawing": //팝업이미지
                        PopUpDrawing(strEtc);
                        break;
                    case "VideoPlay": //비디오 재생
                        {
                            //StartVideo(0);
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }


    public void Focus(int numb)
    {
        endChangeImg = false;
        Image img = otherEventGroup.transform.GetChild(1).GetComponent<Image>();

        img.gameObject.SetActive(true);
        if(numb.Equals(1))
        {
            if(!img.color.Equals(Color.white))
            { img.DOFade(numb, 1f).OnComplete(() => endChangeImg = true); }
            else
            { endChangeImg = true; }
        }
        else
        {
            if (!img.color.Equals(SetColor.whiteClear))
            { img.DOFade(numb, 1f).OnComplete(() =>
            {
                if (numb.Equals(0))
                { img.gameObject.SetActive(false); }
                endChangeImg = true;
            }); }
            else
            { endChangeImg = true; }
        }
        
    }
    public void Focus2(int numb)
    {
        endChangeImg = false;
        Image img = otherEventGroup.transform.GetChild(2).GetComponent<Image>();

        img.gameObject.SetActive(true);

        if (numb.Equals(1))
        {
            if (!img.color.Equals(Color.white))
            { img.DOFade(numb, 1f).OnComplete(() => endChangeImg = true); }
            else
            { endChangeImg = true; }
        }
        else
        {
            if (!img.color.Equals(SetColor.whiteClear))
            {
                img.DOFade(numb, 1f).OnComplete(() =>
                {
                    if (numb.Equals(0))
                    { img.gameObject.SetActive(false); }
                    endChangeImg = true;
                });
            }
            else
            { endChangeImg = true; }
        }
    }

    public void Blur(float numb)
    {
        endSound = false;
        if (numb > 0f)
        { blur.gameObject.SetActive(true); }

        blur.material.DOFloat(numb, "_Size", 0.5f).OnComplete(() =>
        {
            if (numb.Equals(0f))
            { blur.gameObject.SetActive(false); }
            endSound = true;
        });
    }
    public void BGBlur(float numb)
    {
        endSound = false;
        if (numb > 0f)
        { backBlur.gameObject.SetActive(true); }

        backBlur.material.DOFloat(numb, "_Size", 1).OnComplete(() =>
        {
            if (numb.Equals(0f))
            { backBlur.gameObject.SetActive(false); }
            endSound = true;
        });
    }

    public void EyeOpen()
    {
        endChangeImg = false;
        Image img = otherEventGroup.transform.GetChild(0).GetComponent<Image>();
        Image img0 = otherEventGroup.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Image img1 = otherEventGroup.transform.GetChild(0).GetChild(1).GetComponent<Image>();

        img.rectTransform.DOSizeDelta(new Vector2(3840, 2160), 2.5f).OnComplete(() =>
        {
            img.DOFade(0f, 1f);
            img0.DOFade(0f, 1f);
            img1.DOFade(0f, 1f).OnComplete(() => { img.gameObject.SetActive(false); endChangeImg = true; });
        });
    }

    public void EyeClose()
    {
        endChangeImg = false;
        Image img = otherEventGroup.transform.GetChild(0).GetComponent<Image>();
        Image img0 = otherEventGroup.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Image img1 = otherEventGroup.transform.GetChild(0).GetChild(1).GetComponent<Image>();

        img.color = Color.clear;
        img0.color = Color.clear;
        img1.color = Color.clear;

        //img.transform.localScale = Vector3.one;
        img.gameObject.SetActive(true);

        img.DOFade(1f, 1f);
        img0.DOFade(1f, 1f);
        img1.DOFade(1f, 1f);

        img.rectTransform.DOSizeDelta(new Vector2(3840, 0), 3f).OnComplete(()=> { endChangeImg = true; });
    }

    public void PopUpDrawing(string strEtc)
    {
        endCharacter = false;
        if (strEtc.Equals("-1"))
        {
            for (int i = 0; i < popUpDrawing.childCount; i++)
            {
                if (popUpDrawing.GetChild(i).gameObject.activeInHierarchy)
                {
                    Image img = popUpDrawing.GetChild(i).GetComponent<Image>();
                    img.DOFade(0f, 0.5f).OnComplete(() => img.gameObject.SetActive(false));
                }
            }
            endCharacter = true;
        }
        else
        {
            for (int i = 0; i < popUpDrawing.childCount; i++)
            {
                if (!i.Equals(int.Parse(strEtc)))
                {
                    if (popUpDrawing.GetChild(i).gameObject.activeInHierarchy)
                    {
                        Image pop = popUpDrawing.GetChild(i).GetComponent<Image>();
                        pop.DOFade(0f, 0.5f).OnComplete(() => pop.gameObject.SetActive(false));
                    }
                }
            }

            Image obj = popUpDrawing.GetChild(int.Parse(strEtc)).GetComponent<Image>();
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.color = SetColor.whiteClear;
                obj.gameObject.SetActive(true);
                obj.DOFade(1f, 0.5f).OnComplete(() => endCharacter = true);
            }
            else
            { endCharacter = true; }
        }
    }

    public void PopUpNew(string strEtc)
    {
        endCharacter = false;
        if (strEtc.Equals("-1"))
        {
            for (int i = 0; i < newPopUpGroup.transform.GetChild(0).childCount; i++)
            {
                if (newPopUpGroup.transform.GetChild(0).GetChild(i).gameObject.activeInHierarchy)
                {
                    Image img = newPopUpGroup.transform.GetChild(0).GetChild(i).GetComponent<Image>();
                    img.DOFade(0f, 0.5f).OnComplete(() => img.gameObject.SetActive(false));
                }
            }

            Image monitor = newPopUpGroup.transform.GetChild(0).GetComponent<Image>();
            monitor.DOFade(0f, 0.5f);
            newPopUpGroup.DOFade(0f, 0.5f).OnComplete(() =>
            {
                newPopUpGroup.gameObject.SetActive(false);
                endCharacter = true;
            });
        }
        else
        {
            if (newPopUpGroup.gameObject.activeInHierarchy)
            {
                for (int i = 0; i < newPopUpGroup.transform.GetChild(0).childCount; i++)
                {
                    if (newPopUpGroup.transform.GetChild(0).GetChild(i).gameObject.activeInHierarchy)
                    { newPopUpGroup.transform.GetChild(0).GetChild(i).gameObject.SetActive(false); }
                }

                Image obj = newPopUpGroup.transform.GetChild(0).GetChild(int.Parse(strEtc)).GetComponent<Image>();
                if(!obj.color.Equals(Color.white))
                { obj.color = Color.white; }
                obj.gameObject.SetActive(true);
                endCharacter = true;
            }
            else
            {
                Image monitor = newPopUpGroup.transform.GetChild(0).GetComponent<Image>();
                Image obj = newPopUpGroup.transform.GetChild(0).GetChild(int.Parse(strEtc)).GetComponent<Image>();

                obj.color = SetColor.whiteClear;
                monitor.color = SetColor.whiteClear;
                newPopUpGroup.color = Color.clear;

                obj.gameObject.SetActive(true);
                newPopUpGroup.gameObject.SetActive(true);
                monitor.DOFade(1f, 0.5f);
                obj.DOFade(1f, 0.5f);
                newPopUpGroup.DOFade(0.5f, 0.5f).OnComplete(() => endCharacter = true );
            }
        }
    }

    public void PopUp(string strEtc, string before)
    {
        string str = strEtc;
        if (!str.Equals(string.Empty))
        {
            endCharacter = false;
            if (str.Equals("-1"))
            {
                imagePopUpGroup.DOFade(0f, 0.5f);

                for (int j = 0; j < imagePopUpGroup.transform.childCount; j++)
                {
                    if (imagePopUpGroup.transform.GetChild(j).gameObject.activeInHierarchy)
                    {
                        Image obj = imagePopUpGroup.transform.GetChild(j).GetComponent<Image>();
                        if (obj != null)
                        {
                            if(j.Equals(3))
                            {
                                for (int k = 0; k < imagePopUpGroup.transform.GetChild(3).transform.childCount; k++)
                                {
                                    if (imagePopUpGroup.transform.GetChild(3).GetChild(k).gameObject.activeInHierarchy)
                                    {
                                        Image pop = imagePopUpGroup.transform.GetChild(3).GetChild(k).GetComponent<Image>();
                                        pop.DOFade(0f, 0.5f).OnComplete(() => pop.gameObject.SetActive(false));
                                    }
                                }
                            }
                            obj.DOFade(0f, 0.5f).OnComplete(() =>
                            {
                                obj.gameObject.SetActive(false);
                                endCharacter = true;
                            });
                        }
                        else
                        {
                            imagePopUpGroup.transform.GetChild(j).gameObject.SetActive(false);
                            endCharacter = true;
                        }
                    }
                }
            }
            else
            {
                string tmp = before;
                int tmpNumb = int.Parse(str);

                if (!tmpNumb.Equals(1) && !tmpNumb.Equals(2))
                { imagePopUpGroup.DOFade(0.5f, 0.5f); }

                if (tmpNumb > 2 && tmpNumb < 13) // 블로그
                {
                    bool flag = false;
                    if (!str.Equals(tmp))
                    {
                        for (int j = 0; j < imagePopUpGroup.transform.GetChild(3).transform.childCount; j++)
                        {
                            if (imagePopUpGroup.transform.GetChild(3).GetChild(j).gameObject.activeInHierarchy)
                            {
                                Image pop = imagePopUpGroup.transform.GetChild(3).GetChild(j).GetComponent<Image>();
                                pop.DOFade(0f, 0.5f).OnComplete(() => pop.gameObject.SetActive(false));
                                flag = true;
                            }
                        }
                        Image obj = imagePopUpGroup.transform.GetChild(3).GetChild(tmpNumb - 3).GetComponent<Image>();
                        obj.color = SetColor.whiteClear;
                        obj.gameObject.SetActive(true);
                        obj.DOFade(1f, 0.5f).OnComplete(() => endCharacter = true);
                    }
                    else
                    { endCharacter = true; }

                    Image objParent = imagePopUpGroup.transform.GetChild(3).GetComponent<Image>();
                    if (!flag)
                    {
                        if (!objParent.color.Equals(Color.white))
                        {
                            objParent.color = SetColor.whiteClear;
                            objParent.gameObject.SetActive(true);
                            objParent.DOFade(1f, 0.5f);
                        }
                    }
                }
                else
                {
                    int numb = int.Parse(str);
                    if(numb > 12)
                    { numb -= 9; }

                    if (!str.Equals(tmp))
                    {
                        for (int j = 0; j < imagePopUpGroup.transform.childCount; j++)
                        {
                            if (imagePopUpGroup.transform.GetChild(j).gameObject.activeInHierarchy)
                            {
                                Image pop = imagePopUpGroup.transform.GetChild(j).GetComponent<Image>();
                                pop.DOFade(0f, 0.5f).OnComplete(() => pop.gameObject.SetActive(false));
                            }
                        }
                    }
                    Image obj = imagePopUpGroup.transform.GetChild(numb).GetComponent<Image>();
                    if (obj != null)
                    {
                        obj.color = SetColor.whiteClear;
                        obj.gameObject.SetActive(true);
                        obj.DOFade(1f, 0.5f).OnComplete(() => endCharacter = true);
                    }
                    else //particle
                    {
                        imagePopUpGroup.transform.GetChild(numb).gameObject.SetActive(true);
                        endCharacter = true;
                    }
                }
            }
        }
    }

    public void CloseUp4(string strEtc)
    {
        int numb = int.Parse(strEtc);
        GameObject newone = imagePopUpGroup.transform.parent.gameObject;

        if (numb > 0)
        {
            newone.transform.localScale = Vector3.one * 2;
            if (numb.Equals(1))
            { newone.transform.localPosition = new Vector3(850, -425, 0); }
            else if (numb.Equals(2))
            { newone.transform.localPosition = new Vector3(-850, -425, 0); }
            else if (numb.Equals(3))
            { newone.transform.localPosition = new Vector3(850, 425, 0); }
            else if (numb.Equals(4))
            { newone.transform.localPosition = new Vector3(-850, 425, 0); }
            else if (numb.Equals(5))
            { newone.transform.localPosition = new Vector3(0, -425, 0); }
            else if (numb.Equals(6))
            { newone.transform.localPosition = new Vector3(0, 425, 0); }
            else if (numb.Equals(7))
            { newone.transform.localPosition = new Vector3(850, 0, 0); }
            else if (numb.Equals(8))
            { newone.transform.localPosition = new Vector3(-850, 0, 0); }
        }
        else
        {
            newone.transform.localScale = Vector3.one * 1.1f;
            newone.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void HandHeld(string strEtc)
    {
        int numb = int.Parse(strEtc);
        GameObject newone = imagePopUpGroup.transform.parent.gameObject;

        if (numb.Equals(1))
        {
            if(ieHandHeld != null)
            { StopCoroutine(ieHandHeld); }
            ieHandHeld = StartCoroutine(HandHeldCor());
        }
        else
        {
            endSound = false;

            if (ieHandHeld != null)
            { StopCoroutine(ieHandHeld); }
            newone.transform.DOPause();
            newone.transform.DOKill();
            newone.transform.DOLocalMove(Vector3.zero, 1f).OnComplete(() => endSound = true);
        }
    }

    public void HandHeldStop()
    {
        if (ieHandHeld != null)
        { StopCoroutine(ieHandHeld); }
        GameObject newone = imagePopUpGroup.transform.parent.gameObject;
        newone.transform.DOPause();
        newone.transform.DOKill();
        newone.transform.localPosition = Vector3.zero;
    }

    public Coroutine ieHandHeld;
    IEnumerator HandHeldCor()
    {
        GameObject newone = imagePopUpGroup.transform.parent.gameObject;
        Vector2 pos;
        while (true)
        {
            pos = new Vector2(Random.Range(-17, 17), Random.Range(-17, 17));
            float time = Random.Range(3.5f, 5f);
            newone.transform.DOLocalMove(pos, time).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(time);
        }
    }

    public void ZoomIn(string strEtc)
    {
        int numb = int.Parse(strEtc);
        GameObject newone = imagePopUpGroup.transform.parent.gameObject;
        endChangeImg = false;

        if (numb > 0)
        {
            Vector3 pos = Vector3.zero;

            if (numb.Equals(1))
            { pos = new Vector3(850, -425, 0); }
            else if (numb.Equals(2))
            { pos = new Vector3(-850, -425, 0); }
            else if (numb.Equals(3))
            { pos = new Vector3(850, 425, 0); }
            else if (numb.Equals(4))
            { pos = new Vector3(-850, 425, 0); }
            else if (numb.Equals(5))
            { pos = new Vector3(0, -425, 0); }
            else if (numb.Equals(6))
            { pos = new Vector3(0, 425, 0); }
            else if (numb.Equals(7))
            { pos = new Vector3(850, 0, 0); }
            else if (numb.Equals(8))
            { pos = new Vector3(-850, 0, 0); }

            newone.transform.DOScale(Vector3.one * 2, 1f);
            newone.transform.DOLocalMove(pos, 1f).OnComplete(()=> endChangeImg =  true);
        }
        else
        {
            newone.transform.DOScale(Vector3.one * 1.1f, 1f);
            newone.transform.DOLocalMove(Vector3.zero, 1f).OnComplete(() => endChangeImg = true);
        }
    }

    public void TalkTextSet() // 대사출력
    {
        if (CsvLoader.dSelectedStoryTextData.Count > talkNumb)
        {
            if (InputController.inst.isSpace)
            { DoText(0, CsvLoader.dSelectedStoryTextData[talkNumb].Trim()); }
            else
            { DoText(DataController.duSettingData[1].value, CsvLoader.dSelectedStoryTextData[talkNumb].Trim()); }
            PlayVoice();
        }
    }

    public void BGSet(bool notLog = true) // 배경이미지
    {
        if (CsvLoader.dStoryData.ContainsKey(talkNumb))
        {
            int tmpNumb = CsvLoader.dStoryData[talkNumb].BGNumber;
            if (!tmpNumb.Equals(-100))
            {
                string effect = CsvLoader.dStoryData[talkNumb].BGEffect;

                Sprite spr = null;

                if (tmpNumb.Equals(55)|| tmpNumb.Equals(56)|| tmpNumb.Equals(57) || tmpNumb.Equals(79) || tmpNumb.Equals(132) ||
                    tmpNumb.Equals(148)||tmpNumb.Equals(149)|| tmpNumb.Equals(150) || tmpNumb.Equals(158) || tmpNumb.Equals(159) ||
                    tmpNumb.Equals(163) )
                {
                    int localizedKey = (int)DataController.duSettingData[10].value;

                    if (localizedKey.Equals(1))
                        spr = Resources.Load<Sprite>("BG/" + tmpNumb.ToString("000")+"_JP");
                    else if(localizedKey.Equals(2))
                        spr = Resources.Load<Sprite>("BG/" + tmpNumb.ToString("000") + "_EN");
                    //[syw]
                    else if (localizedKey.Equals(3))
                        spr = Resources.Load<Sprite>("BG/" + tmpNumb.ToString("000") + "_ZHS");
                    else if (localizedKey.Equals(4))
                        spr = Resources.Load<Sprite>("BG/" + tmpNumb.ToString("000") + "_ZHT");
                    //[syw]
                }                

                if(spr==null)
                    spr = Resources.Load<Sprite>("BG/" + tmpNumb.ToString("000"));

                switch (effect)
                {
                    case "NewFadein":
                        endChangeImg = false;

                        bgImg.color = SetColor.whiteClear;
                        bgImg.sprite = spr;
                        bgImg.DOColor(Color.white, float.Parse(CsvLoader.dStoryData[talkNumb].BGEtc)).OnComplete(() =>
                        {
                            beforeBgImg.sprite = spr;
                            endChangeImg = true;
                        });
                        break;
                    case "Fadein":
                        endChangeImg = false;
                        bgImg.DOColor(Color.black, 0.5f).OnComplete(() =>
                        {
                            bgImg.sprite = spr;
                            beforeBgImg.sprite = spr;
                            bgImg.DOColor(Color.white, 0.5f).OnComplete(() => endChangeImg = true); ;
                        });
                        break;
                    case "Transition":
                        endChangeImg = false;
                        if (int.Parse(CsvLoader.dStoryData[talkNumb].BGEtc) < 2)
                        {
                            beforeBgImg.sprite = spr;
                            Transform img = transitionPos.GetChild(int.Parse(CsvLoader.dStoryData[talkNumb].BGEtc));
                            img.gameObject.SetActive(true);
                            img.DOLocalMoveX(0, 2f).OnComplete(() =>
                            {
                                bgImg.sprite = spr;
                                img.DOLocalMoveX(3700, 2f).OnComplete(() =>
                                {
                                    beforeBgImg.sprite = spr;
                                    img.gameObject.SetActive(false);
                                    img.transform.localPosition = new Vector2(-3700, 0);
                                    endChangeImg = true;
                                });
                            });
                        }
                        else
                        {
                            beforeBgImg.sprite = bgImg.sprite;
                            beforeBgImg.color = Color.white;

                            bgImg.material = null;
                            bgEffect.transitionTexture = textures[int.Parse(CsvLoader.dStoryData[talkNumb].BGEtc) - 2];
                            bgEffect.effectFactor = 0f;
                            bgEffect.enabled = true;
                            bgImg.sprite = spr;
                            StartCoroutine(TransCor(2f));
                        }
                        break;
                    default:
                        if (notLog)
                        {
                            if(!bgImg.sprite.Equals(spr))
                            {
                                bgImg.sprite = spr;
                                beforeBgImg.sprite = spr;
                            }
                        }
                        else
                        {
                            bgImg.sprite = spr;
                            beforeBgImg.sprite = spr;
                        }
                        break;
                }
            }
        }
    }

    public IEnumerator TransCor(float duration)
    {
        float time = 0f;
        while (duration >= time)
        {
            time += Time.deltaTime;
            bgEffect.effectFactor = time;
            yield return null;  
        }
        bgEffect.enabled = false;
        bgImg.material = beforeBgImg.material;
        beforeBgImg.sprite = bgImg.sprite;
        endChangeImg = true;
    }

    public void CharacterSet(bool notLog = true)
    {
        if (CsvLoader.dStoryData.ContainsKey(talkNumb))
        {
            if (!talkNumb.Equals(0))
            {
                if (notLog)
                {
                    CharacterCheck(A, CsvLoader.dStoryData[talkNumb].A_posX, CsvLoader.dStoryData[talkNumb - 1].A_posX,
                        CsvLoader.dStoryData[talkNumb].A_posY, CsvLoader.dStoryData[talkNumb - 1].A_posY,
                        CsvLoader.dStoryData[talkNumb].A_img, CsvLoader.dStoryData[talkNumb - 1].A_img,
                        CsvLoader.dStoryData[talkNumb].A_face, CsvLoader.dStoryData[talkNumb - 1].A_face,
                        CsvLoader.dStoryData[talkNumb].A_size, CsvLoader.dStoryData[talkNumb - 1].A_size,
                        CsvLoader.dStoryData[talkNumb].A_effect, CsvLoader.dStoryData[talkNumb - 1].A_effect);

                    CharacterCheck(B, CsvLoader.dStoryData[talkNumb].B_posX, CsvLoader.dStoryData[talkNumb - 1].B_posX,
                        CsvLoader.dStoryData[talkNumb].B_posY, CsvLoader.dStoryData[talkNumb - 1].B_posY,
                        CsvLoader.dStoryData[talkNumb].B_img, CsvLoader.dStoryData[talkNumb - 1].B_img,
                        CsvLoader.dStoryData[talkNumb].B_face, CsvLoader.dStoryData[talkNumb - 1].B_face,
                        CsvLoader.dStoryData[talkNumb].B_size, CsvLoader.dStoryData[talkNumb - 1].B_size,
                        CsvLoader.dStoryData[talkNumb].B_effect, CsvLoader.dStoryData[talkNumb - 1].B_effect);

                    CharacterCheck(C, CsvLoader.dStoryData[talkNumb].C_posX, CsvLoader.dStoryData[talkNumb - 1].C_posX,
                        CsvLoader.dStoryData[talkNumb].C_posY, CsvLoader.dStoryData[talkNumb - 1].C_posY,
                        CsvLoader.dStoryData[talkNumb].C_img, CsvLoader.dStoryData[talkNumb - 1].C_img,
                        CsvLoader.dStoryData[talkNumb].C_face, CsvLoader.dStoryData[talkNumb - 1].C_face,
                        CsvLoader.dStoryData[talkNumb].C_size, CsvLoader.dStoryData[talkNumb - 1].C_size,
                        CsvLoader.dStoryData[talkNumb].C_effect, CsvLoader.dStoryData[talkNumb - 1].C_effect);

                    CharacterCheck(D, CsvLoader.dStoryData[talkNumb].D_posX, CsvLoader.dStoryData[talkNumb - 1].D_posX,
                        CsvLoader.dStoryData[talkNumb].D_posY, CsvLoader.dStoryData[talkNumb - 1].D_posY,
                        CsvLoader.dStoryData[talkNumb].D_img, CsvLoader.dStoryData[talkNumb - 1].D_img,
                        CsvLoader.dStoryData[talkNumb].D_face, CsvLoader.dStoryData[talkNumb - 1].D_face,
                        CsvLoader.dStoryData[talkNumb].D_size, CsvLoader.dStoryData[talkNumb - 1].D_size,
                        CsvLoader.dStoryData[talkNumb].D_effect, CsvLoader.dStoryData[talkNumb - 1].D_effect);

                    CharacterCheck(E, CsvLoader.dStoryData[talkNumb].E_posX, CsvLoader.dStoryData[talkNumb - 1].E_posX,
                        CsvLoader.dStoryData[talkNumb].E_posY, CsvLoader.dStoryData[talkNumb - 1].E_posY,
                        CsvLoader.dStoryData[talkNumb].E_img, CsvLoader.dStoryData[talkNumb - 1].E_img,
                        CsvLoader.dStoryData[talkNumb].E_face, CsvLoader.dStoryData[talkNumb - 1].E_face,
                        CsvLoader.dStoryData[talkNumb].E_size, CsvLoader.dStoryData[talkNumb - 1].E_size,
                        CsvLoader.dStoryData[talkNumb].E_effect, CsvLoader.dStoryData[talkNumb - 1].E_effect);

                    CharacterCheck(F, CsvLoader.dStoryData[talkNumb].F_posX, CsvLoader.dStoryData[talkNumb - 1].F_posX,
                        CsvLoader.dStoryData[talkNumb].F_posY, CsvLoader.dStoryData[talkNumb - 1].F_posY,
                        CsvLoader.dStoryData[talkNumb].F_img, CsvLoader.dStoryData[talkNumb - 1].F_img,
                        CsvLoader.dStoryData[talkNumb].F_face, CsvLoader.dStoryData[talkNumb - 1].F_face,
                        CsvLoader.dStoryData[talkNumb].F_size, CsvLoader.dStoryData[talkNumb - 1].F_size,
                        CsvLoader.dStoryData[talkNumb].F_effect, CsvLoader.dStoryData[talkNumb - 1].F_effect);
                }
                else
                {
                    CharacterCheck(A, CsvLoader.dStoryData[talkNumb].A_posX, CsvLoader.dStoryData[talkNumb - 1].A_posX,
                        CsvLoader.dStoryData[talkNumb].A_posY, CsvLoader.dStoryData[talkNumb - 1].A_posY,
                        CsvLoader.dStoryData[talkNumb].A_img, CsvLoader.dStoryData[talkNumb - 1].A_img,
                        CsvLoader.dStoryData[talkNumb].A_face, CsvLoader.dStoryData[talkNumb - 1].A_face,
                        CsvLoader.dStoryData[talkNumb].A_size, CsvLoader.dStoryData[talkNumb - 1].A_size,
                        CsvLoader.dStoryData[talkNumb].A_effect, CsvLoader.dStoryData[talkNumb - 1].A_effect, false);

                    CharacterCheck(B, CsvLoader.dStoryData[talkNumb].B_posX, CsvLoader.dStoryData[talkNumb - 1].B_posX,
                        CsvLoader.dStoryData[talkNumb].B_posY, CsvLoader.dStoryData[talkNumb - 1].B_posY,
                        CsvLoader.dStoryData[talkNumb].B_img, CsvLoader.dStoryData[talkNumb - 1].B_img,
                        CsvLoader.dStoryData[talkNumb].B_face, CsvLoader.dStoryData[talkNumb - 1].B_face,
                        CsvLoader.dStoryData[talkNumb].B_size, CsvLoader.dStoryData[talkNumb - 1].B_size,
                        CsvLoader.dStoryData[talkNumb].B_effect, CsvLoader.dStoryData[talkNumb - 1].B_effect, false);

                    CharacterCheck(C, CsvLoader.dStoryData[talkNumb].C_posX, CsvLoader.dStoryData[talkNumb - 1].C_posX,
                        CsvLoader.dStoryData[talkNumb].C_posY, CsvLoader.dStoryData[talkNumb - 1].C_posY,
                        CsvLoader.dStoryData[talkNumb].C_img, CsvLoader.dStoryData[talkNumb - 1].C_img,
                        CsvLoader.dStoryData[talkNumb].C_face, CsvLoader.dStoryData[talkNumb - 1].C_face,
                        CsvLoader.dStoryData[talkNumb].C_size, CsvLoader.dStoryData[talkNumb - 1].C_size,
                        CsvLoader.dStoryData[talkNumb].C_effect, CsvLoader.dStoryData[talkNumb - 1].C_effect, false);

                    CharacterCheck(D, CsvLoader.dStoryData[talkNumb].D_posX, CsvLoader.dStoryData[talkNumb - 1].D_posX,
                        CsvLoader.dStoryData[talkNumb].D_posY, CsvLoader.dStoryData[talkNumb - 1].D_posY,
                        CsvLoader.dStoryData[talkNumb].D_img, CsvLoader.dStoryData[talkNumb - 1].D_img,
                        CsvLoader.dStoryData[talkNumb].D_face, CsvLoader.dStoryData[talkNumb - 1].D_face,
                        CsvLoader.dStoryData[talkNumb].D_size, CsvLoader.dStoryData[talkNumb - 1].D_size,
                        CsvLoader.dStoryData[talkNumb].D_effect, CsvLoader.dStoryData[talkNumb - 1].D_effect, false);

                    CharacterCheck(E, CsvLoader.dStoryData[talkNumb].E_posX, CsvLoader.dStoryData[talkNumb - 1].E_posX,
                        CsvLoader.dStoryData[talkNumb].E_posY, CsvLoader.dStoryData[talkNumb - 1].E_posY,
                        CsvLoader.dStoryData[talkNumb].E_img, CsvLoader.dStoryData[talkNumb - 1].E_img,
                        CsvLoader.dStoryData[talkNumb].E_face, CsvLoader.dStoryData[talkNumb - 1].E_face,
                        CsvLoader.dStoryData[talkNumb].E_size, CsvLoader.dStoryData[talkNumb - 1].E_size,
                        CsvLoader.dStoryData[talkNumb].E_effect, CsvLoader.dStoryData[talkNumb - 1].E_effect, false);

                    CharacterCheck(F, CsvLoader.dStoryData[talkNumb].F_posX, CsvLoader.dStoryData[talkNumb - 1].F_posX,
                        CsvLoader.dStoryData[talkNumb].F_posY, CsvLoader.dStoryData[talkNumb - 1].F_posY,
                        CsvLoader.dStoryData[talkNumb].F_img, CsvLoader.dStoryData[talkNumb - 1].F_img,
                        CsvLoader.dStoryData[talkNumb].F_face, CsvLoader.dStoryData[talkNumb - 1].F_face,
                        CsvLoader.dStoryData[talkNumb].F_size, CsvLoader.dStoryData[talkNumb - 1].F_size,
                        CsvLoader.dStoryData[talkNumb].F_effect, CsvLoader.dStoryData[talkNumb - 1].F_effect, false);
                }
            }
        }
    }

    public void CharacterCheck(Character character, int posX, int beforePosX, int posY, int beforePosY, int img, int beforeImg, int face, int beforeFace, float size, float beforeSize, string effect, string beforeEffect, bool notLog = true)
    {
        if (size.Equals(-100))
        {
            if (character.nowPose.pose.color.Equals(Color.white)) //꺼져야할때
            { character.nowPose.Off(character); }
            if(character.beforePose.gameObject.activeInHierarchy)
            { character.beforePose.Off(character); }
        }
        else
        {
            if (notLog)
            {
                if (img.Equals(beforeImg)) // 이미 켜져있음
                {
                    if (size.Equals(beforeSize)) //사이즈 같을때 
                    {
                        if (!posX.Equals(beforePosX) || !posY.Equals(beforePosY)) // 위치 다를때
                        { character.nowPose.ChangePosition(character, img, face, size, posX, posY); }
                        else
                        {
                            if (!face.Equals(beforeFace)) // 표정 다를때
                            { character.nowPose.ChangeFace(character, face); }

                        }
                    }
                    else //사이즈 다를때
                    { character.nowPose.ChangePosition(character, img, face, size, posX, posY); }
                }
                else // 켜져야할때
                {
                    if (character.nowPose.pose.color.Equals(Color.white))
                    { character.nowPose.ChangePosition(character, img, face, size, posX, posY); }
                    else
                    {
                        character.beforePose.Off(character);
                        character.nowPose.On(character, img, face, size, posX, posY);
                    }
                }
            }
            else
            { character.nowPose.ChangePosition(character, img, face, size, posX, posY, true); }
        }
    }

    //대사출력
    void DoText(float duration, string str) // TMP_text 
    {
        if(duration.Equals(0f))
        { duration = 0.1f; }

        readyRead = false;
        talkLastImg.gameObject.SetActive(false);
        TMP_Text.maxVisibleCharacters = 0;
        TMP_Text.text = str;

        if (CsvLoader.dSelectedStoryNameData[talkNumb].Equals(string.Empty))
        {
            nameTag.gameObject.SetActive(false);
            TMP_Text.colorGradient = new VertexGradient(SetColor.lightGray, SetColor.lightGray, SetColor.lightGray, SetColor.lightGray);
        }
        else
        {
            if (CsvLoader.dSelectedStoryNameData[talkNumb].Equals("END"))
            {
                nameTag.gameObject.SetActive(false);
                TMP_Text.colorGradient = new VertexGradient(SetColor.lightGray, SetColor.lightGray, SetColor.lightGray, SetColor.lightGray);
            }
            else
            {
                string name = CsvLoader.dSelectedStoryNameData[talkNumb];
                bool check = true;

                if (name.Contains("Player"))
                {
                    nameText.color = SetColor.lightPink; 
                }
                else if (name.Contains("Sub"))
                {
                    nameText.color = SetColor.lightYellow;
                }
                else if (name.Contains("Teacher"))
                {
                    nameText.color = Color.white;
                }
                else if (name.Contains("Bad"))
                {
                    nameText.color = Color.white;
                }
                else
                {
                    nameText.color = SetColor.lightGray; 
                    check = false;
                }
                
                nameTag.color = nameText.color;
                nameText.text = name;

                if (check)
                { TMP_Text.colorGradient = new VertexGradient(Color.white, Color.white, nameText.color, nameText.color); }
                else
                { TMP_Text.colorGradient = new VertexGradient(SetColor.lightGray, SetColor.lightGray, SetColor.lightGray, SetColor.lightGray); }
                nameTag.gameObject.SetActive(true);
            }
        }

        DOTween.To(x => TMP_Text.maxVisibleCharacters = (int)x, 0f, str.Length, (str.Length + 1) * duration * 0.1f).OnComplete(() =>
        {
            talkLastImg.gameObject.SetActive(true);
            readyRead = true;

            if (str.Equals(string.Empty))
            {
                talkLastImg.transform.localPosition = new Vector3(-600, 43, 0);
            }
            else
            {
                Vector3 pos = Vector3.zero;
                
                pos = TMP_Text.textInfo.characterInfo[TMP_Text.textInfo.characterCount - 1].bottomRight;
                pos.y += 20;
                if (pos.y >= 13.0f)
                    pos.y = 43.0f;
                else if (pos.y > -47.0f)
                    pos.y = -17.0f;
                else if (pos.y > -107.0f)
                    pos.y = -77.0f;
                talkLastImg.transform.localPosition = pos;
            }
        });

    }

    public void StartVideo(int num)
    {
        StartCoroutine(StartVideos(num));
    }

    IEnumerator StartVideos(int num)
    {
        videoPlay = true;
        videoBlack.color = SetColor.whiteClear;
        videoPlayer.clip = videos[num];
        videoPlayer.SetDirectAudioVolume(0, DataController.duSettingData[8].value * DataController.duSettingData[2].value);
        videoCanvas.gameObject.SetActive(true);
        videoBlack.DOColor(Color.white, 2f);
        videoPlayer.Play();
        
        yield return new WaitForSeconds(float.Parse(videoPlayer.clip.length.ToString()) - 2f);
        GameController.inst.SceneChange("StartScene");
        videoBlack.DOColor(Color.black, 1f);
    }

    public void Click()
    {
        UpdateNextTalk();
    }

    public void Auto()
    { 
        autoObj.gameObject.SetActive(true); 
    }
    
    public void PlayVoice()
    {
        if (!talkNumb.Equals(0))
        {
            if (!CsvLoader.dStoryData[talkNumb - 1].Voice.Equals(string.Empty))
            { SoundController.inst.StopVoice(); }
        }

        if (!CsvLoader.dStoryData[talkNumb].Voice.Equals(string.Empty))
        {
            string str = CsvLoader.dStoryData[talkNumb].Voice.Substring(0, 1);
        }
    }
    
    void PrintPos(Text textComp, int charIndex, string last)
    {
        string text = textComp.text;
        readyRead = true;

        if (charIndex >= text.Length)
            return;

        TextGenerator textGen = new TextGenerator(text.Length);
        Vector2 extents = textComp.gameObject.GetComponent<RectTransform>().rect.size;
        textGen.Populate(text, textComp.GetGenerationSettings(extents));

        int newLine = text.Substring(0, charIndex).Split('\n').Length - 1;
        int whiteSpace = text.Substring(0, charIndex).Split(' ').Length - 1;

        int indexOfTextQuad = (charIndex * 4) + (newLine * 4) - (whiteSpace * 4);

        if (indexOfTextQuad < textGen.vertexCount)
        {
            Vector3 avgPos = (textGen.verts[indexOfTextQuad].position +
                textGen.verts[indexOfTextQuad + 1].position +
                textGen.verts[indexOfTextQuad + 2].position +
                textGen.verts[indexOfTextQuad + 3].position) / 4f;

            if (last.Equals(",") || last.Equals(".") || last.Equals("…"))
            { talkLastImg.rectTransform.pivot = new Vector2(-1f, 0.2f); }
            else
            { talkLastImg.rectTransform.pivot = new Vector2(-1f, 0.5f); }
            
            talkLastImg.transform.localPosition = avgPos / canvas.scaleFactor;
            talkLastImg.gameObject.SetActive(true);
        }
    }
}
