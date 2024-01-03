using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityManager : MonoBehaviour
{
    public Player player;
    public GameObject rewardPanel;

    public List<Ability> abilities;
    public List<Passive> passives;

    public TextMeshProUGUI[] abilityNameText;
    public TextMeshProUGUI[] abilityContentText;
    public TextMeshProUGUI[] abilityLevelText;
    public Image[] abilitySpriteImage;

    public Image[] takenAbilityImage;
    public Image[] takenPassiveAbilityImage;

    //--------------------------------------------------

    private List<int> abilityOrder;

    private List<string> totalName;
    private List<string> totalContent;
    private List<Sprite> totalSprites;

    private List<int> abilityLevel;
    private List<int> passiveLevel;
    private List<int> totalLevel;

    private int takenAbility = 0;
    private int takenPassiveAbility = 0;

    private void Awake()
    {
        abilityLevel = new List<int>();
        passiveLevel = new List<int>();
        totalLevel = new List<int>();

        totalName = new List<string>();
        totalContent = new List<string>();
        totalSprites = new List<Sprite>();

        abilityOrder = new List<int>();

        for (int i = 0; i < abilities.Count; i++)
        {
            abilityLevel.Add(0);
            totalLevel.Add(0);
        }

        for(int i = 0; i < passives.Count; i++)
        {
            passiveLevel.Add(0);
            totalLevel.Add(0);
        }

        // 기본 공격
        abilityLevel[0] = 1;
        takenAbilityImage[takenAbility].sprite = abilities[0].abilitySprite;
        takenAbility++;
    }

    private void Start()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            totalName.Add(abilities[i].abilityName);
            totalContent.Add(abilities[i].abilityContent);
            totalSprites.Add(abilities[i].abilitySprite);
        }

        for (int i = 0; i < passives.Count; i++)
        {
            totalName.Add(passives[i].passiveName);
            totalContent.Add(passives[i].passiveContent);
            totalSprites.Add(passives[i].passiveSprite);
        }
    }

    public void Display()
    {
        SelectRandomAbility();

        for (int i = 0; i < abilitySpriteImage.Length; i++)
        {
            int randomAbility = abilityOrder[i];

            abilityNameText[i].text = totalName[randomAbility];
            abilityContentText[i].text = totalContent[randomAbility];
            abilitySpriteImage[i].sprite = totalSprites[randomAbility];
            abilityLevelText[i].text = "Level : " + totalLevel[randomAbility].ToString();
        }
    }
    
    private void DisplayAbility(int abilityNumber, bool active)
    {
        if(active)              // ability
        {
            takenAbilityImage[takenAbility].sprite = abilities[abilityNumber].abilitySprite;
            takenAbility++;
        }
        else                    // passive
        {
            takenPassiveAbilityImage[takenPassiveAbility].sprite = passives[abilityNumber].passiveSprite;
            takenPassiveAbility++;
        }
    }

    private void SelectRandomAbility()
    {
        int currentAbility = Random.Range(0, totalContent.Count);

        abilityOrder.Clear();

        for (int i = 0; i < totalContent.Count;)
        {
            if(abilityOrder.Contains(currentAbility)) currentAbility = Random.Range(0, totalContent.Count);
            else { abilityOrder.Add(currentAbility); i++; }
        }
    }

    public void RankUp1()
    {
        string ability = abilityNameText[0].text;
        SwitchAbility(ability);
    }
    public void RankUp2()
    {
        string ability = abilityNameText[1].text;
        SwitchAbility(ability);
    }
    public void RankUp3()
    {
        string ability = abilityNameText[2].text;
        SwitchAbility(ability);
    }

    private void SwitchAbility(string ability)
    {
        switch (ability)
        {
            case "공격력 증가":
                if (passiveLevel[0] == 0) DisplayAbility(0, false);
                player.playerDamage *= 1.1f;
                passiveLevel[0]++;
                break;

            case "이동속도 증가":
                if (passiveLevel[1] == 0) DisplayAbility(1, false);
                player.speed *= 1.05f;
                passiveLevel[1]++;
                break;

            case "쿨타임 감소":
                if (passiveLevel[2] == 0) DisplayAbility(2, false);
                player.coolTime *= 0.97f;

                if (player.coolTime < 0.3f)
                {
                    player.coolTime = 0.3f;
                    DeletePassive(2);
                }
                else
                    passiveLevel[2]++;
                break;

            //----------------------------------------------------

            case "베기":
                LevelUpSelect(0, ObjectPool.Instance.BasicAttackPool.Count, ObjectPool.Instance.BasicAttackPool);
                break;

            case "마법 탄":
                LevelUpSelect(1, ObjectPool.Instance.BigBulletPool.Count, ObjectPool.Instance.BigBulletPool);
                break;

            case "에너지 발사":
                LevelUpSelect(2, ObjectPool.Instance.RoundPool.Count, ObjectPool.Instance.RoundPool);

                if (abilityLevel[2] > 10)
                    DeleteAbility(2);
                break;
        }

        UpdateLevel();
        GameManager.inst.Resume();
    }

    private void LevelUpSelect(int listIndex, int poolCount, List<GameObject> abilities)
    {
        abilityLevel[listIndex]++;
        if (!player.abilities[listIndex].hasAbility)
        {
            player.abilities[listIndex].OnHasAbility();
            DisplayAbility(listIndex, true);
        }
        else
        {
            for (int i = 0; i < poolCount; i++)
            {
                Ability ability = abilities[i].GetComponent<Ability>();

                ability.AbilityLevelUp(abilityLevel[listIndex]);
                ability.AddCount();
            }
        }
    }

    private void UpdateLevel()
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            totalLevel[i] = abilityLevel[i];
        }

        for (int i = 0; i < passives.Count; i++)
        {
            totalLevel[i + abilities.Count] = passiveLevel[i];
        }
    }

    private void DeletePassive(int index)
    {
        totalName.Remove(passives[index].passiveName);
        totalContent.Remove(passives[index].passiveContent);
        totalSprites.Remove(passives[index].passiveSprite);

        passives.RemoveAt(index);
    }

    private void DeleteAbility(int index)
    {
        totalName.Remove(abilities[index].abilityName);
        totalContent.Remove(abilities[index].abilityContent);
        totalSprites.Remove(abilities[index].abilitySprite);

        abilities.RemoveAt(index);
    }
}
