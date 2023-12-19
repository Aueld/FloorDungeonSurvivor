using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected static WaitForSeconds wait = new(0.1f);

    public int count;
    public int abilityLV;
    public float totalDamage;
    public float damage;
    public float coolTime;
    public string abilityName;
    public string abilityContent;
    public Sprite abilitySprite;
    public bool infinity;
    
    public Transform player; // 플레이어의 위치

    public void Awake()
    {
        totalDamage = damage;
    }

    public void SetState(Ability ability)
    {
        count = ability.count;
        abilityLV = ability.abilityLV;
        totalDamage = ability.totalDamage;
        damage = ability.damage;
    }

    public void SetPlayer(Transform _player)
    {
        player = _player;
    }

    virtual public void Logic() { }
    virtual public IEnumerator CorLogic() { yield break; }
    virtual public void AddCount() { }
    virtual public void AbilityLevelUp(int lvl) { }
}
