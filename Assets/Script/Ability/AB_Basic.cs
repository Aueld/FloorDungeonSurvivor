using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_Basic : Ability
{
    private SpriteRenderer spriteRenderer;
 
    private Vector2 posFix = Vector2.zero;
    private bool isFilp;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        //if(posFix == Vector2.zero)
        posFix = new Vector2(3f, 0.6f);

        if(spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    override public void Logic()
    {
        if (totalDamage == 0)
            totalDamage = damage;

        if (player == null)
            SetPlayer(GameManager.inst.player.transform);
        else
            isFilp = player.GetComponent<Player>().IsFlip();

        StartCoroutine(CorLogic());
    }

    override public IEnumerator CorLogic()
    {
        if (isFilp)
        {
            transform.position = player.position + Vector3.left * posFix.x + Vector3.down * posFix.y;
            spriteRenderer.flipY = false;

            yield return wait;

            transform.position = player.position + Vector3.right * posFix.x + Vector3.down * posFix.y;
            spriteRenderer.flipY = true;
        }
        else
        {
            transform.position = player.position + Vector3.right * posFix.x + Vector3.down * posFix.y;
            spriteRenderer.flipY = true;

            yield return wait;

            transform.position = player.position + Vector3.left * posFix.x + Vector3.down * posFix.y;
            spriteRenderer.flipY = false;
        }

        yield return wait;
        ObjectPool.Instance.ReturnObject(gameObject);
    }

    public override void AbilityLevelUp(int lvl)
    {
        abilityLV = lvl;

        totalDamage = damage + (abilityLV * (damage / 5));
    }
}
