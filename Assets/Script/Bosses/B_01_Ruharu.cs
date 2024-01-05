using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_01_Ruharu : BossMonster
{
    void Start()
    {
        SetState(0, 10000, 1, 5, "ruharu");
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Hit()
    {
        base.Hit();
    }

    public override void Logic()
    {
        base.Logic();
    }

    public override IEnumerator CorLogic()
    {
        return base.CorLogic();
    }
}

