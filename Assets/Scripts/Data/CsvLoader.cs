using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvLoader : MonoBehaviour{
    public static CsvLoader inst;


    StoryData[] storyDatas;
    StoryStringData[] storyStringDatas;
    LanguageData[] languageDatas;
    SceneData[] sceneDatas;

    public static Dictionary<int, StoryData> dStoryData = new Dictionary<int, StoryData>();

    public static Dictionary<int, String> dSelectedLanguage = new Dictionary<int, String>();
    public static Dictionary<int, String> dSelectedStoryTextData = new Dictionary<int, String>();
    public static Dictionary<int, String> dSelectedStoryNameData = new Dictionary<int, String>();

    public static Dictionary<string, SceneData> dSceneData = new Dictionary<string, SceneData>();
    

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { Destroy(gameObject); }
    }

    //씬 데이터 로드
    public void LoadSceneData()
    {
        dSceneData.Clear();

        FileInfo fileInfo = new FileInfo(Application.dataPath + "/CSV/ProjectEp - SceneData.csv");
        if (fileInfo.Exists)
        { LoadCSVStream(out sceneDatas, Application.dataPath + "/CSV/ProjectEp - SceneData.csv"); }
        else
        { LoadCSV(out sceneDatas, "CSV/ProjectEp - SceneData"); }

        for (int i = 0; i < sceneDatas.Length; i++)
        { dSceneData.Add(sceneDatas[i].NowScene, sceneDatas[i]); }
    }

    //스토리 씬 데이터 로드
    public void LoadStoryData(string fileName)
    {
        dStoryData.Clear();
        string path = "CSV/ProjectEp - ";
        if (GameController.inst.isStory)
        { path = "CSV/Stream/ProjectEp - "; }

        FileInfo fileInfo = new FileInfo(Application.dataPath + "/" + path + fileName + ".csv");
        if (fileInfo.Exists)
        { LoadCSVStream(out storyDatas, Application.dataPath + "/" + path + fileName + ".csv"); }
        else
        { LoadCSV(out storyDatas, path + fileName); }

        for (int i = 0; i < storyDatas.Length; i++)
        { dStoryData.Add(i, storyDatas[i]); }

        dSelectedStoryNameData.Clear();
        dSelectedStoryTextData.Clear();
        fileInfo = new FileInfo(Application.dataPath + "/" + path + fileName + "_Language.csv");
        if (fileInfo.Exists)
        { LoadCSVStream(out storyStringDatas, Application.dataPath + "/" + path + fileName + "_Language.csv"); }
        else
        { LoadCSV(out storyStringDatas, path + fileName + "_Language"); }

        int numb = (int)DataController.duSettingData[6].value;

        if (numb.Equals(0))
        {
            for (int i = 0; i < storyStringDatas.Length; i++)
            {
                dSelectedStoryNameData.Add(i, storyStringDatas[i].KoreanName);
                dSelectedStoryTextData.Add(i, storyStringDatas[i].Korean);
            }
        }
        else if (numb.Equals(1))
        {
            for (int i = 0; i < storyStringDatas.Length; i++)
            {
                dSelectedStoryNameData.Add(i, storyStringDatas[i].JapaneseName);
                dSelectedStoryTextData.Add(i, storyStringDatas[i].Japanese);
            }
        }
        else if (numb.Equals(2))
        {
            for (int i = 0; i < storyStringDatas.Length; i++)
            {
                dSelectedStoryNameData.Add(i, storyStringDatas[i].EnglishName);
                dSelectedStoryTextData.Add(i, storyStringDatas[i].English);
            }
        }
    }

    public void LanguageSet()
    {
        dSelectedLanguage.Clear();

        LoadCSV(out languageDatas, "CSV/Language");
        
        int numb = (int)DataController.duSettingData[10].value;
        if (numb.Equals(0))
        {
            for (int i = 0; i < languageDatas.Length; i++)
            { dSelectedLanguage.Add(languageDatas[i].id, languageDatas[i].Korean); }
        }
        else if (numb.Equals(1))
        {
            for (int i = 0; i < languageDatas.Length; i++)
            { dSelectedLanguage.Add(languageDatas[i].id, languageDatas[i].Japanese); }
        }
        else if (numb.Equals(2))
        {
            for (int i = 0; i < languageDatas.Length; i++)
            { dSelectedLanguage.Add(languageDatas[i].id, languageDatas[i].English); }
        }
    }

    public void LoadCSV<T>(out T[] OutputArr, string path) where T : new()
    {
        TextAsset asset = Resources.Load<TextAsset>(path);

        if (asset == null)
        {
            Debug.LogError("wrong path " + path);
            OutputArr = null;
            return;
        }
        string data = asset.text;
        data += "\n";

        #region Split Line by Line
        const string WINDOWS_DELIMITER = "\n";
        const string UNIX_DELIMITER = "\r\n";
        const string MAC_DELIMITER = "\r";

        if (data.Contains(UNIX_DELIMITER))
        {
            data = data.Replace(UNIX_DELIMITER, WINDOWS_DELIMITER);
        }
        else if (data.Contains(MAC_DELIMITER))
        {
            data = data.Replace(MAC_DELIMITER, WINDOWS_DELIMITER);
        }

        string[] lineData = data.Split('\n');
        #endregion

        OutputArr = new T[lineData.Length - 2];
        string[] fieldNameArr = lineData[0].Split(',');

        for (int i = 0; i < lineData.Length - 2; i++)
        {
            string[] currentLineSplited = GenerateLineSplit(lineData[i + 1]);
         
            OutputArr[i] = new T();
            Type type = typeof(T);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            int fieldID = 0;

            for (int j = 0; j < fields.Length; j++)
            {
                Type propertyType = fields[j].FieldType;

                if (fieldNameArr.Length > j && fields[j].Name == fieldNameArr[j])
                { fieldID = j; }
                else
                {
                    bool skipFlag = true;
                    for (int k = 0; k < fieldNameArr.Length; k++)
                    {
                        if (fields[j].Name == fieldNameArr[k])
                        {
                            fieldID = k;
                            skipFlag = false;
                            break;
                        }
                    }
                    if (skipFlag)
                    { continue; }
                }

                if (propertyType.IsArray)
                {
                    string[] strList = GenerateLineSplit(currentLineSplited[fieldID]);
                    Type arrayFieldType = propertyType.GetElementType();

                    Array newArray = Array.CreateInstance(arrayFieldType, strList.Length);

                    if (strList != null)
                    {
                        newArray = Array.CreateInstance(arrayFieldType, strList.Length);

                        for (int k = 0; k < newArray.Length; ++k)
                        {
                            if (arrayFieldType.IsGenericType &&
                                arrayFieldType.GetGenericTypeDefinition() == typeof(List<>))
                            {
                                string[] listArr = GenerateLineSplit(strList[k]);
                                Type baseType = typeof(List<>);
                                Type itemType = arrayFieldType.GetGenericArguments()[0];
                                IList list = (IList)Activator.
                                    CreateInstance(baseType.MakeGenericType(arrayFieldType.GetGenericArguments()[0]));

                                for (int l = 0; l < listArr.Length; l++)
                                {
                                    if (itemType.IsEnum)
                                    { list.Insert(l, Enum.Parse(itemType, listArr[l])); }
                                    else if (itemType == typeof(int))
                                    { list.Insert(l, int.Parse(listArr[l])); }
                                    else if (itemType == typeof(float))
                                    { list.Insert(l, float.Parse(listArr[l])); }
                                    else if (itemType == typeof(bool))
                                    { list.Insert(l, bool.Parse(listArr[l])); }
                                    else if (itemType == typeof(double))
                                    { list.Insert(l, double.Parse(listArr[l])); }
                                    else if (itemType == typeof(string))
                                    { list.Insert(l, listArr[l].Replace("\\n", "\n")); }
                                    else
                                    { list.Insert(l, null); }
                                }
                                newArray.SetValue(list, k);
                            }
                            else if (arrayFieldType.IsEnum)
                            { newArray.SetValue(Enum.Parse(arrayFieldType, strList[k]), k); }
                            else if (arrayFieldType == typeof(int))
                            { newArray.SetValue(int.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(float))
                            { newArray.SetValue(float.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(bool))
                            { newArray.SetValue(bool.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(double))
                            { newArray.SetValue(double.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(string))
                            { newArray.SetValue(strList[k].Replace("\\n", "\n"), k); }
                            else
                            { newArray.SetValue(null, k); }
                        }
                    }
                    fields[j].SetValue(OutputArr[i], newArray);
                }
                else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    string[] strList = GenerateLineSplit(currentLineSplited[fieldID]);
                    Type baseType = typeof(List<>);
                    Type itemType = propertyType.GetGenericArguments()[0];

                    IList list = (IList)Activator.
                        CreateInstance(baseType.MakeGenericType(propertyType.GetGenericArguments()[0]));

                    for (int k = 0; k < strList.Length; k++)
                    {
                        if (itemType.IsEnum)
                        { list.Insert(k, Enum.Parse(itemType, strList[k])); }
                        else if (itemType == typeof(int))
                        { list.Insert(k, int.Parse(strList[k])); }
                        else if (itemType == typeof(float))
                        { list.Insert(k, float.Parse(strList[k])); }
                        else if (itemType == typeof(bool))
                        { list.Insert(k, bool.Parse(strList[k])); }
                        else if (itemType == typeof(double))
                        { list.Insert(k, double.Parse(strList[k])); }
                        else if (itemType == typeof(string))
                        { list.Insert(k, strList[k].Replace("\\n", "\n")); }
                        else
                        { list.Insert(k, null); }
                    }

                    fields[j].SetValue(OutputArr[i], list);
                }
                else if (propertyType.IsEnum)
                {
                    fields[j].SetValue(OutputArr[i], Enum.Parse(propertyType, currentLineSplited[fieldID]));
                }
                else if (propertyType == typeof(int) ||
                         propertyType == typeof(float) ||
                         propertyType == typeof(double))
                {
                    if (currentLineSplited[fieldID].Equals(string.Empty))
                    { fields[j].SetValue(OutputArr[i], Convert.ChangeType(-100, propertyType)); }
                    else
                    { fields[j].SetValue(OutputArr[i], Convert.ChangeType(currentLineSplited[fieldID], propertyType)); }
                }
                else if (propertyType == typeof(bool))
                { fields[j].SetValue(OutputArr[i], Convert.ChangeType(currentLineSplited[fieldID], propertyType)); }
                else
                {
                    if (currentLineSplited[fieldID].Equals("NONE") || currentLineSplited[fieldID].Equals(null))
                    { currentLineSplited[fieldID] = string.Empty; }

                    
                    fields[j].SetValue(OutputArr[i], currentLineSplited[fieldID].Replace("\\n", "\n")); 
                }
            }
        }
    }

    public void LoadCSVStream<T>(out T[] OutputArr, string path) where T : new()
    {
        StreamReader sr = new StreamReader(path);
        
        if (sr == null)
        {
            Debug.LogError("wrong path " + path);
            OutputArr = null;
            return;
        }
        string data = sr.ReadToEnd();
        data += "\n";

        #region Split Line by Line
        const string WINDOWS_DELIMITER = "\n";
        const string UNIX_DELIMITER = "\r\n";
        const string MAC_DELIMITER = "\r";

        if (data.Contains(UNIX_DELIMITER))
        {
            data = data.Replace(UNIX_DELIMITER, WINDOWS_DELIMITER);
        }
        else if (data.Contains(MAC_DELIMITER))
        {
            data = data.Replace(MAC_DELIMITER, WINDOWS_DELIMITER);
        }

        string[] lineData = data.Split('\n');
        #endregion

        OutputArr = new T[lineData.Length - 2];
        string[] fieldNameArr = lineData[0].Split(',');

        for (int i = 0; i < lineData.Length - 2; i++)
        {
            string[] currentLineSplited = GenerateLineSplit(lineData[i + 1]);

            OutputArr[i] = new T();
            Type type = typeof(T);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            int fieldID = 0;

            for (int j = 0; j < fields.Length; j++)
            {
                Type propertyType = fields[j].FieldType;

                if (fieldNameArr.Length > j && fields[j].Name == fieldNameArr[j])
                { fieldID = j; }
                else
                {
                    bool skipFlag = true;
                    for (int k = 0; k < fieldNameArr.Length; k++)
                    {
                        if (fields[j].Name == fieldNameArr[k])
                        {
                            fieldID = k;
                            skipFlag = false;
                            break;
                        }
                    }
                    if (skipFlag)
                    { continue; }
                }

                if (propertyType.IsArray)
                {
                    string[] strList = GenerateLineSplit(currentLineSplited[fieldID]);
                    Type arrayFieldType = propertyType.GetElementType();

                    Array newArray = Array.CreateInstance(arrayFieldType, strList.Length);

                    if (strList != null)
                    {
                        newArray = Array.CreateInstance(arrayFieldType, strList.Length);

                        for (int k = 0; k < newArray.Length; ++k)
                        {
                            if (arrayFieldType.IsGenericType &&
                                arrayFieldType.GetGenericTypeDefinition() == typeof(List<>))
                            {
                                string[] listArr = GenerateLineSplit(strList[k]);
                                Type baseType = typeof(List<>);
                                Type itemType = arrayFieldType.GetGenericArguments()[0];
                                IList list = (IList)Activator.
                                    CreateInstance(baseType.MakeGenericType(arrayFieldType.GetGenericArguments()[0]));

                                for (int l = 0; l < listArr.Length; l++)
                                {
                                    if (itemType.IsEnum)
                                    { list.Insert(l, Enum.Parse(itemType, listArr[l])); }
                                    else if (itemType == typeof(int))
                                    { list.Insert(l, int.Parse(listArr[l])); }
                                    else if (itemType == typeof(float))
                                    { list.Insert(l, float.Parse(listArr[l])); }
                                    else if (itemType == typeof(bool))
                                    { list.Insert(l, bool.Parse(listArr[l])); }
                                    else if (itemType == typeof(double))
                                    { list.Insert(l, double.Parse(listArr[l])); }
                                    else if (itemType == typeof(string))
                                    { list.Insert(l, listArr[l].Replace("\\n", "\n")); }
                                    else
                                    { list.Insert(l, null); }
                                }
                                newArray.SetValue(list, k);
                            }
                            else if (arrayFieldType.IsEnum)
                            { newArray.SetValue(Enum.Parse(arrayFieldType, strList[k]), k); }
                            else if (arrayFieldType == typeof(int))
                            { newArray.SetValue(int.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(float))
                            { newArray.SetValue(float.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(bool))
                            { newArray.SetValue(bool.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(double))
                            { newArray.SetValue(double.Parse(strList[k]), k); }
                            else if (arrayFieldType == typeof(string))
                            { newArray.SetValue(strList[k].Replace("\\n", "\n"), k); }
                            else
                            { newArray.SetValue(null, k); }
                        }
                    }
                    fields[j].SetValue(OutputArr[i], newArray);
                }
                else if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    string[] strList = GenerateLineSplit(currentLineSplited[fieldID]);
                    Type baseType = typeof(List<>);
                    Type itemType = propertyType.GetGenericArguments()[0];

                    IList list = (IList)Activator.
                        CreateInstance(baseType.MakeGenericType(propertyType.GetGenericArguments()[0]));

                    for (int k = 0; k < strList.Length; k++)
                    {
                        if (itemType.IsEnum)
                        { list.Insert(k, Enum.Parse(itemType, strList[k])); }
                        else if (itemType == typeof(int))
                        { list.Insert(k, int.Parse(strList[k])); }
                        else if (itemType == typeof(float))
                        { list.Insert(k, float.Parse(strList[k])); }
                        else if (itemType == typeof(bool))
                        { list.Insert(k, bool.Parse(strList[k])); }
                        else if (itemType == typeof(double))
                        { list.Insert(k, double.Parse(strList[k])); }
                        else if (itemType == typeof(string))
                        { list.Insert(k, strList[k].Replace("\\n", "\n")); }
                        else
                        { list.Insert(k, null); }
                    }
                    fields[j].SetValue(OutputArr[i], list);
                }
                else if (propertyType.IsEnum)
                {
                    fields[j].SetValue(OutputArr[i], Enum.Parse(propertyType, currentLineSplited[fieldID]));
                }
                else if (propertyType == typeof(int) ||
                         propertyType == typeof(float) ||
                         propertyType == typeof(double))
                {
                    if (currentLineSplited[fieldID].Equals(string.Empty))
                    { fields[j].SetValue(OutputArr[i], Convert.ChangeType(-100, propertyType)); }
                    else
                    { fields[j].SetValue(OutputArr[i], Convert.ChangeType(currentLineSplited[fieldID], propertyType)); }
                }
                else if (propertyType == typeof(bool))
                { fields[j].SetValue(OutputArr[i], Convert.ChangeType(currentLineSplited[fieldID], propertyType)); }
                else
                {
                    if (currentLineSplited[fieldID].Equals("NONE") || currentLineSplited[fieldID].Equals(null))
                    { currentLineSplited[fieldID] = string.Empty; }

                    fields[j].SetValue(OutputArr[i], currentLineSplited[fieldID].Replace("\\n", "\n"));
                }
            }
        }
    }

    private string[] GenerateLineSplit(string currentLine)
    {
        string[] currentLineSplited;
        char[] MarkArr = { '\"' };
        
        if (currentLine.IndexOfAny(MarkArr) >= 0) //문장에 큰 따옴표가 있다면..
        {
            List<string> result = new List<string>();

            //int checker = 0;
            int startIndex = 0;
            int commaIndex = currentLine.IndexOf(',', startIndex);
            int markIndex = currentLine.IndexOfAny(MarkArr, startIndex);
            int secondMark = 0;
            bool isQuot;

            //Debug.LogWarning(currentLine);

            while (true)
            {
                //Debug.LogWarning(checker + " ::: " + startIndex + " : " + markIndex + " : " + commaIndex +" : "+ secondMark);
                //checker++;
                //다음으로 자를 문장에 콤마가 있는경우
                if (commaIndex < markIndex && startIndex <= commaIndex)
                {
                    string block = currentLine.Substring(startIndex, commaIndex - startIndex);
                    result.Add(block);
                    //Debug.LogWarning(block);
                    startIndex = commaIndex;
                }
                else
                {
                    secondMark = currentLine.IndexOfAny(MarkArr, startIndex);
                    if (secondMark.Equals(-1)) // 큰따옴표 없을때
                    {
                        if (commaIndex.Equals(-1)) //더 자를거 없을때(=마지막 문장일때)
                        {

                            string str = currentLine.Substring(startIndex);
                            //Debug.LogWarning(str);
                            result.Add(str);
                            break;
                        }

                        //큰따옴표 없고, 마지막문장 아닐때
                        string block = currentLine.Substring(startIndex, commaIndex - startIndex);
                        result.Add(block);
                        //Debug.LogWarning(block);
                        startIndex = commaIndex;
                    }
                    else
                    {
                        if (markIndex < 0)
                        { break; }

                        startIndex = markIndex;

                        isQuot = currentLine[markIndex].Equals(MarkArr[0]);
                        if (isQuot)
                        {
                            markIndex = currentLine.IndexOf(MarkArr[0], startIndex);
                            while (markIndex < currentLine.Length - 1 && !currentLine[markIndex + 1].Equals(','))
                            { markIndex = currentLine.IndexOf(MarkArr[0], markIndex + 1); }
                        }

                        string block = currentLine.Substring(startIndex, markIndex + 1 - startIndex);
                        block = block.Remove(block.Length - 1, 1);
                        block = block.Remove(0, 1);
                        //Debug.LogWarning(block);
                        result.Add(block);
                        startIndex = markIndex + 1;

                        markIndex = currentLine.IndexOfAny(MarkArr, startIndex);
                    }
                }

                commaIndex = currentLine.IndexOf(',', startIndex);
                //자를게 남았지만다음문장이 없는경우
                if (startIndex == commaIndex && startIndex < currentLine.Length)
                {
                    startIndex++;
                    commaIndex = currentLine.IndexOf(',', startIndex);
                }

            }
            currentLineSplited = result.ToArray();
        }
        else
        { currentLineSplited = currentLine.Split(','); }

        return currentLineSplited;
    }

    public StoryStringData Get_storyStringDatas(int index)
    {
        return storyStringDatas[index];
    }
}
