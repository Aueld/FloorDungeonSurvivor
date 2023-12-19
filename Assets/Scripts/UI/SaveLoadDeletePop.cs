using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadDeletePop : MonoBehaviour
{
    public Image storyImage;
    public Text storyText, timeText, numberText;
    public UserSaveData thisData;

    public void Delete()
    {
        int id = thisData.id;
        DataController.inst.DeleteSaveData(thisData);
        gameObject.SetActive(false);
        UIController.inst.saves[id].UpdateUI();
    }
}
