using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterPose : MonoBehaviour
{
    public Image pose, face ,beforeFace;
    //public int id;

    public void On(Character character, int poseNumb, int faceNumb, float size, int posX, int posY)//캐릭터 나타나기
    {
        transform.localScale = Vector3.one * size;
        Vector2 pos = new Vector2(posX, posY);

        transform.localPosition = pos;
        gameObject.SetActive(true);
        
        if (character.Equals(StoryController.inst.A))
        {
            pose.sprite = Resources.Load<Sprite>("Character/A/" + poseNumb.ToString("000"));

            if (poseNumb.Equals(2) || poseNumb.Equals(5) || poseNumb.Equals(8) || poseNumb.Equals(11) || poseNumb.Equals(14) || poseNumb.Equals(17) || poseNumb.Equals(20) || poseNumb.Equals(23)
            || poseNumb.Equals(26) || poseNumb.Equals(30) || poseNumb.Equals(33) || poseNumb.Equals(36) || poseNumb.Equals(39) || poseNumb.Equals(42) || poseNumb.Equals(45) || poseNumb.Equals(67)
            || poseNumb.Equals(48) || poseNumb.Equals(51) || poseNumb.Equals(54) || poseNumb.Equals(57) || poseNumb.Equals(60) || poseNumb.Equals(81) || poseNumb.Equals(85)
            || poseNumb.Equals(89) || poseNumb.Equals(94) || poseNumb.Equals(99) || poseNumb.Equals(103) || poseNumb.Equals(107) || poseNumb.Equals(111))
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/00_1/" + faceNumb.ToString("000")); }
            else
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/" + faceNumb.ToString("000")); }
        }
        else if (character.Equals(StoryController.inst.B))
        {
            int localizedKey = (int)DataController.duSettingData[10].value;

            face.sprite = Resources.Load<Sprite>("Character/B/B_Face/" + faceNumb.ToString("000"));
            
            if (poseNumb.Equals(1))
                pose.sprite = Resources.Load<Sprite>("Character/B/" + poseNumb.ToString("000") + localizedKey.ToString());
            else
                pose.sprite = Resources.Load<Sprite>("Character/B/" + poseNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.C))
        {
            int localizedKey = (int)DataController.duSettingData[10].value;

            face.sprite = Resources.Load<Sprite>("Character/C/C_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/C/" + poseNumb.ToString("000")+localizedKey.ToString());
        }
        else if (character.Equals(StoryController.inst.D))
        {
            face.sprite = Resources.Load<Sprite>("Character/D/D_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/D/" + poseNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.E))
        {
            face.sprite = Resources.Load<Sprite>("Character/E/E_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/E/" + poseNumb.ToString("000"));
        }
        pose.DOFade(1f, 0.5f);
        face.DOFade(1f, 0.5f);
    }

    public void Off(Character character)//캐릭터 끄기
    {
        StoryController.inst.endCharacter = false;
        face.DOFade(0f, 0.5f);
        pose.DOFade(0f, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
            StoryController.inst.endCharacter = true;
        });
    }

    public void ChangeFace(Character character, int faceNumb)//캐릭터 표정바꾸기
    {
        StoryController.inst.endCharacter = false;
        beforeFace.color = Color.white;
        beforeFace.sprite = face.sprite;
        beforeFace.gameObject.SetActive(true);
        face.color = SetColor.whiteClear;

        if (character.Equals(StoryController.inst.A))
        {
            if (pose.sprite == null)
            {
                pose.sprite = Resources.Load<Sprite>("Character/A/" + CsvLoader.dStoryData[StoryController.inst.talkNumb].A_img.ToString("000"));
                pose.DOFade(1f, 0.5f);
            }
            int numb = CsvLoader.dStoryData[StoryController.inst.talkNumb].A_img;
            if (numb.Equals(2) || numb.Equals(5) || numb.Equals(8) || numb.Equals(11) || numb.Equals(14) || numb.Equals(17) || numb.Equals(20) || numb.Equals(23)
                || numb.Equals(26) || numb.Equals(30) || numb.Equals(33) || numb.Equals(36) || numb.Equals(39) || numb.Equals(42) || numb.Equals(45) || numb.Equals(67)
                || numb.Equals(48) || numb.Equals(51) || numb.Equals(54) || numb.Equals(57) || numb.Equals(60) || numb.Equals(81) || numb.Equals(85)
                || numb.Equals(89) || numb.Equals(94) || numb.Equals(99) || numb.Equals(103) || numb.Equals(107) || numb.Equals(111))
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/00_1/" + faceNumb.ToString("000")); }
            else
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/" + faceNumb.ToString("000")); }
        }
        else if (character.Equals(StoryController.inst.B))
        {
            if (pose.sprite == null)
            {
                pose.sprite = Resources.Load<Sprite>("Character/B/" + CsvLoader.dStoryData[StoryController.inst.talkNumb].B_img.ToString("000"));
                pose.DOFade(1f, 0.5f);
            }
            face.sprite = Resources.Load<Sprite>("Character/B/B_Face/" + faceNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.C))
        {
            if (pose.sprite == null)
            {
                pose.sprite = Resources.Load<Sprite>("Character/C/" + CsvLoader.dStoryData[StoryController.inst.talkNumb].C_img.ToString("000"));
                pose.DOFade(1f, 0.5f);
            }
            face.sprite = Resources.Load<Sprite>("Character/C/C_Face/" + faceNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.D))
        {
            if (pose.sprite == null)
            {
                pose.sprite = Resources.Load<Sprite>("Character/D/" + CsvLoader.dStoryData[StoryController.inst.talkNumb].D_img.ToString("000"));
                pose.DOFade(1f, 0.5f);
            }
            face.sprite = Resources.Load<Sprite>("Character/D/D_Face/" + faceNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.E))
        {
            if (pose.sprite == null)
            {
                pose.sprite = Resources.Load<Sprite>("Character/E/" + CsvLoader.dStoryData[StoryController.inst.talkNumb].E_img.ToString("000"));
                pose.DOFade(1f, 0.5f);
            }
            face.sprite = Resources.Load<Sprite>("Character/E/E_Face/" + faceNumb.ToString("000"));
        }

        face.DOFade(1f, 0.5f);
        beforeFace.DOFade(0f, 0.5f).OnComplete(() =>
        {
            StoryController.inst.endCharacter = true;
            beforeFace.gameObject.SetActive(false);
        });
    }

    public void ChangePosition(Character character, int poseNumb, int faceNumb, float size, int posX, int posY, bool isLog = false)//캐릭터 전체 변화
    {
        if (!isLog)
        { character.beforePose.FadeOut(pose.sprite, face.sprite, transform); }

        Vector2 pos = new Vector2(posX, posY);

        face.color = SetColor.whiteClear;
        pose.color = SetColor.whiteClear;
        transform.localScale = Vector3.one * size;
        transform.localPosition = pos;

        if (character.Equals(StoryController.inst.A))
        {
            pose.sprite = Resources.Load<Sprite>("Character/A/" + poseNumb.ToString("000"));

            if (poseNumb.Equals(2) || poseNumb.Equals(5) || poseNumb.Equals(8) || poseNumb.Equals(11) || poseNumb.Equals(14) || poseNumb.Equals(17) || poseNumb.Equals(20) || poseNumb.Equals(23)
                || poseNumb.Equals(26) || poseNumb.Equals(30) || poseNumb.Equals(33) || poseNumb.Equals(36) || poseNumb.Equals(39) || poseNumb.Equals(42) || poseNumb.Equals(45) || poseNumb.Equals(67)
                || poseNumb.Equals(48) || poseNumb.Equals(51) || poseNumb.Equals(54) || poseNumb.Equals(57) || poseNumb.Equals(60) || poseNumb.Equals(81) || poseNumb.Equals(85)
                || poseNumb.Equals(89) || poseNumb.Equals(94) || poseNumb.Equals(99) || poseNumb.Equals(103) || poseNumb.Equals(107) || poseNumb.Equals(111))
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/00_1/" + faceNumb.ToString("000")); }
            else
            { face.sprite = Resources.Load<Sprite>("Character/A_Face/" + faceNumb.ToString("000")); }
        }
        else if (character.Equals(StoryController.inst.B))
        {
            int localizedKey = (int)DataController.duSettingData[10].value;

            face.sprite = Resources.Load<Sprite>("Character/B/B_Face/" + faceNumb.ToString("000"));

            if (poseNumb.Equals(1))
                pose.sprite = Resources.Load<Sprite>("Character/B/" + poseNumb.ToString("000") + localizedKey.ToString());
            else
                pose.sprite = Resources.Load<Sprite>("Character/B/" + poseNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.C))
        {
            int localizedKey = (int)DataController.duSettingData[10].value;

            face.sprite = Resources.Load<Sprite>("Character/C/C_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/C/" + poseNumb.ToString("000") + localizedKey.ToString());
        }
        else if (character.Equals(StoryController.inst.D))
        {
            face.sprite = Resources.Load<Sprite>("Character/D/D_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/D/" + poseNumb.ToString("000"));
        }
        else if (character.Equals(StoryController.inst.E))
        {
            face.sprite = Resources.Load<Sprite>("Character/E/E_Face/" + faceNumb.ToString("000"));
            pose.sprite = Resources.Load<Sprite>("Character/E/" + poseNumb.ToString("000"));
        }

        gameObject.SetActive(true);
        face.DOFade(1f, 0.5f);
        pose.DOFade(1f, 0.5f);
    }

    public void FadeOut(Sprite _pose, Sprite _face, Transform _transform) //캐릭터 변화시 이전 이미지
    {
        StoryController.inst.endCharacter = false;
        gameObject.transform.position = _transform.position;
        gameObject.transform.localScale = _transform.localScale;

        pose.sprite = _pose;
        pose.color = Color.white;
        face.sprite = _face;
        face.color = Color.white;

        gameObject.SetActive(true);

        pose.DOFade(0f, 0.5f);
        face.DOFade(0f, 0.5f).OnComplete(() =>
        {
            StoryController.inst.endCharacter = true;
            gameObject.SetActive(false);
        });
    }
}
