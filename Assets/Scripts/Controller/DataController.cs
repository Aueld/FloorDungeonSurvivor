using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System;
using System.Collections;
using System.Globalization;

public class DataController : MonoBehaviour{
    public static DataController inst;

    public NewUserData nUData;

    public List<UserData> uData = new List<UserData>();
    public List<UserSettingData> uSettingData = new List<UserSettingData>();
    public List<UserSaveData> uSaveData = new List<UserSaveData>();

    public static Dictionary<int, UserData> duData = new Dictionary<int, UserData>();
    public static Dictionary<int, UserSettingData> duSettingData = new Dictionary<int, UserSettingData>(); // 저장된 설정값 data
    public static Dictionary<int, UserSaveData> duSaveData = new Dictionary<int, UserSaveData>(); // 저장된 Save data

    [SerializeField] private string filePath;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(inst != this)
            { Destroy(gameObject); }
        }

        filePath = Application.persistentDataPath + "/fds.bin";  // data 경로

        Application.targetFrameRate = 60;
        
        LoadData(); // 저장되어있는 data Load
    }

    private void Start()
    {
        LoadData(); // 저장되어있는 data Load
    }
    
    public void BinarySerialize<T>(T t, string filepath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        StreamWriter writer = new StreamWriter(filepath);
        MemoryStream stream = new MemoryStream();

        formatter.Serialize(stream, t);
        writer.Write(Convert.ToBase64String(stream.GetBuffer()));
        stream.Close();
        writer.Close();
    }

    public T BinaryDeserialize<T>(string path)
    {
        T t = default;

        BinaryFormatter formatter = new BinaryFormatter();

        StreamReader reader = new StreamReader(path);
        string data = reader.ReadToEnd();

        reader.Close();

        if (!string.IsNullOrEmpty(data))
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(data));
            t = (T)formatter.Deserialize(stream);

            stream.Close();
        }

        return t;
    }
    
    public void LoadData()
    {
        if (File.Exists(filePath)) // 파일이 있을경우 해당 파일 load
        {
            nUData = BinaryDeserialize<NewUserData>(filePath);

            uSettingData = nUData.settingDatas;
            uSaveData = nUData.saveDatas;
        }
        else // 파일이 없을경우 기본 data 저장
        {
            CreateSettingData(0, 0f); //창모드 -
            CreateSettingData(1, 0.41f); //배경음
            CreateSettingData(2, 1f); //효과음
            CreateSettingData(3, 0.5f);  //master volume
            CreateSettingData(4, 1f); //AlwaysOnTop -
            CreateSettingData(5, 0f); //언어 0-한, 1-일  2-영
        }
        InitData();

        CsvLoader.inst.LoadSceneData();
        CsvLoader.inst.LanguageSet();
        GameController.inst.GameStartSet();
        Invoke(nameof(SetSetting), 0.5f);
    }

    public void ResetSettingData() //설정창에서 기본설정값으로
    {
        SetSettingData(0, 0f); //창모드 -
        SetSettingData(1, 0.41f); //배경음
        SetSettingData(2, 1f); //효과음
        SetSettingData(3, 0.5f);  //master volume
        SetSettingData(4, 1f); //AlwaysOnTop -
        SetSettingData(5, 0f); //언어 0-한, 1-일  2-영

        UIController.inst.SettingBtnUpdateUI();
    }

    void SetSetting()
    {
        SoundController.inst.StartBGM(30); // 메인화면 BGM
        
        InputController.inst.StartSetScreenSize(); // 화면 사이즈 조정
        UIController.inst.SettingBtnAddListener(); // 설정창 slider 설정
    }

    void InitData() //load된 데이터 적용
    {
        InitSettingData();

        InitSaveData();

    }

    public void SaveData() // 데이터 save
    {
        BinarySerialize(nUData, filePath);
    }

    public void SetSettingData(int id, float value) // 설정창 data 변경
    {
        if (duSettingData.ContainsKey(id)) //이미 저장된 데이터가 있을경우 변경
        {
            duSettingData[id].value = value;
        }
        else
        {
            CreateSettingData(id, value);
        } //이미 저장된 데이터가 없을경우 새로 저장
        
        InitSettingData(); 
    }

    public void InitSettingData() //데이터 파일 업데이트
    {
        duSettingData.Clear();
        for (int i = 0; i < uSettingData.Count; i++)
        {
            duSettingData.Add(uSettingData[i].id, uSettingData[i]);
        }
        nUData.settingDatas = uSettingData;
        
        SaveData();
    }

    public void CreateSettingData(int id, float value) //새로 저장
    {
        uSettingData.Add(new UserSettingData(id, value));
    }

    public void AddSaveData(bool _end, int _id, int _level, int _gold, int _story, string _fileName)
    {
        if (duSaveData.ContainsKey(_id))
        {
            duSaveData[_id].end = _end;
            duSaveData[_id].level = _level;
            duSaveData[_id].gold = _gold;
            duSaveData[_id].story = _story;
            duSaveData[_id].fileName = _fileName;
        }
        else
        {
            CreateSaveData(_end, _id, _level, _gold, _story, _fileName);
        }

        InitSaveData();
        SaveData();
    }

    void InitSaveData()
    {
        duSaveData.Clear();
        for (int i = 0; i < uSaveData.Count; i++)
        {
            duSaveData.Add(uSaveData[i].id, uSaveData[i]);
        }
        nUData.saveDatas = uSaveData;
    }

    public void CreateSaveData(bool _end, int _id, int _level, int _gold, int _story, string _fileName)
    {
        uSaveData.Add(new UserSaveData(_end, _id, _level, _gold, _story, _fileName));
    }

    public void DeleteSaveData(UserSaveData save) // 저장된 save 파일 삭제
    {
        uSaveData.Remove(save);
        InitSaveData();
        SaveData();
    }
}
