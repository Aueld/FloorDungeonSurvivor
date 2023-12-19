using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBtn : MonoBehaviour
{
    public int id;
    public Text story, numb, time;
    public Image storyImage, noneImage;

    public UserSaveData thisData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }
    public void Click() //세이브 버튼 클릭시 해당 장면으로 이동
    {
        if(DataController.duSaveData.ContainsKey(id))
        {
            GameController.inst.isEndless = true;

            GameController.inst.nowFileName = thisData.fileName;
            GameController.inst.SceneChange("StoryScene");
           
            Invoke("SetOff", 1f);
            Invoke("TalkNumbSet", 1.2f);
        }
    }

    void SetOff()  //씬 변경시 팝업 닫기
    {
        if (id.Equals(0))
        { transform.parent.parent.gameObject.SetActive(false); }
        else
        { transform.parent.parent.parent.gameObject.SetActive(false); }
    }

    public void Delete()  // 세이브파일 삭제
    {
        UIController.inst.SaveLoadPopSet(this);
    }

    public void UpdateUI()
    {
        if (!DataController.duSaveData.ContainsKey(id))
        { storyImage.gameObject.SetActive(false); }
        else
        {
            thisData = DataController.duSaveData[id];
            storyImage.gameObject.SetActive(true);

            if (!thisData.fileName.Equals(string.Empty))
            {
                int localizedKey = (int)DataController.duSettingData[6].value;

                story.font = UIController.inst.boldFonts[localizedKey];
            }

            numb.text = string.Format("No.{0}", id);
        }
    }
}
