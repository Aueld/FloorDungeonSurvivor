using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Magnet : Ability
{
    private void Start()
    {

    }

    private void OnEnable()
    {
    }

    public override void Logic()
    {
        
        StartCoroutine(CorLogic());
    }

    public override IEnumerator CorLogic()
    {
        yield return wait;
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
