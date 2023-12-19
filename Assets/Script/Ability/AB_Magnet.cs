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

    override public void Logic()
    {
        
        StartCoroutine(CorLogic());
    }

    override public IEnumerator CorLogic()
    {
        yield return wait;
        ObjectPool.Instance.ReturnObject(gameObject);
    }
}
