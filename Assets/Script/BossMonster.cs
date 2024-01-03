using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : MonoBehaviour
{
    public int index;

    public float HP;
    public float damage;
    public float moveSpeed;
    public string Name;

    public Player Player;

    public void SetPlayer()
    {
        Player = GameManager.inst.player;
    }

    public void SetState(int _index, float _hp, float _damage, float _moveSpeed, string _name)
    {
        index = _index;
        HP = _hp;
        damage = _damage;
        moveSpeed = _moveSpeed;
        Name = _name;
    }

    virtual public void Attack() { }
    virtual public void Hit() { }
    virtual public void Logic() { }
    virtual public IEnumerator CorLogic() { yield break; }
}
