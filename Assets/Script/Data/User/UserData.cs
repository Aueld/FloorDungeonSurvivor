using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저 데이터용 클래스

[System.Serializable]
public class NewUserData
{
    public List<UserStoryData> storyDatas;
    public List<UserSettingData> settingDatas;
    public List<UserSaveData> saveDatas;
    public List<UserAbliityData> abliityDatas;

    public NewUserData(List<UserStoryData> _userStoryDatas, List<UserSettingData> _userSettingDatas, List<UserSaveData> _userSaveDatas, List<UserAbliityData> _userAbliityDatas)
    {
        this.storyDatas = _userStoryDatas;
        this.settingDatas = _userSettingDatas;
        this.saveDatas = _userSaveDatas;
        this.abliityDatas = _userAbliityDatas;
    }
}

[System.Serializable]
public class UserData
{
    public List<UserStoryData> storyDatas;
    public List<UserSettingData> settingDatas;
    public List<UserSaveData> saveDatas;
    public List<UserAbliityData> abliityDatas;

    public UserData(List<UserStoryData> _userStoryDatas, List<UserSettingData> _userSettingDatas, List<UserSaveData> _userSaveDatas, List<UserAbliityData> _userAbliityDatas)
    {
        this.storyDatas = _userStoryDatas;
        this.settingDatas = _userSettingDatas;
        this.saveDatas = _userSaveDatas;
        this.abliityDatas = _userAbliityDatas;
    }
}

[System.Serializable]
public class UserStoryData
{
    public bool end;
    public int id;

    public UserStoryData(bool _end, int _id)
    {
        this.end = _end;
        this.id = _id;
    }
}

[System.Serializable]
public class UserSettingData
{
    public int id;
    public float value;

    public UserSettingData(int _id, float _value)
    {
        this.id = _id;
        this.value = _value;
    }
}

[System.Serializable]
public class UserAbliityData
{
    public int id;
    public Ability ability;

    public UserAbliityData(int _id, Ability _ability)
    {
        this.id = _id;
        this.ability = _ability;
    }
}

[System.Serializable]
public class UserSaveData
{
    public bool end;
    public int id, level, gold, story;
    public string fileName;

    public UserSaveData(bool _end, int _id, int _level, int _gold, int _story, string _fileName)
    {
        this.end = _end;
        this.id = _id;
        this.level = _level;
        this.gold = _gold;
        this.story = _story;
        this.fileName = _fileName;
    }
}
