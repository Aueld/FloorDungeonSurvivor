using UnityEngine;


//게임 데이터용 클래스
public class StoryData
{
    public string A_effect, B_effect, C_effect, D_effect, E_effect, F_effect, BGEffect, Voice, OtherEvent, BGEtc, Etc, OtherEvent1, Etc1;
    public int A_posX, A_posY, A_img, A_face, 
                B_posX, B_posY, B_img, B_face, 
                C_posX, C_posY, C_img, C_face, 
                D_posX, D_posY, D_img, D_face, 
                E_posX, E_posY, E_img, E_face, 
                F_posX, F_posY, F_img, F_face, 
                BGNumber, EffectSound, BGM;
    public float A_size, B_size, C_size, F_size, E_size, D_size;
}

public class StoryStringData
{
    public string KoreanName, Korean, ChineseNameS, ChineseS, ChineseNameT, ChineseT, JapaneseName, Japanese, EnglishName, English;
}


public class LanguageData
{
    public int id;
    
    public string Korean, ChineseS, ChineseT, Japanese, English;
}

public class SceneData
{
    public string NowScene, NextScene;
}