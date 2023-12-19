using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AB_RoundCursor : Ability
{
    private SpriteRenderer spriteRenderer;
 
    public Transform target;

    private bool isFilp;

    private new void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private Vector2 FireVec()
    {
        if (player == null)
            SetPlayer(GameManager.inst.player.transform);

        // 플레이어 주변 가장 가까운 적으로의 방향 반환 

        RaycastHit2D[] rayHit = Physics2D.CircleCastAll(player.position, 20f, Vector2.zero, 0f, LayerMask.GetMask("Monster"));
        if (rayHit != null)
        {
            Vector3 curVec = player.position;
            float distance = Mathf.Infinity;
            Vector2 vec = Vector2.zero;
            foreach (var obj in rayHit)
            {
                if (distance > (obj.collider.transform.position - curVec).magnitude)
                {
                    distance = (obj.collider.transform.position - curVec).magnitude;
                    vec = obj.collider.transform.position - player.position + (Vector3) (Random.insideUnitCircle + new Vector2(Random.Range(1f, 1f), Random.Range(1f, 1f)));
                }
            }
            return vec.normalized;
        }
        return Vector2.zero;
    }

    override public void Logic()
    {
        if (totalDamage == 0)
            totalDamage = damage;

        Vector2 vec = FireVec();

        if (vec == Vector2.zero)
        {
            ObjectPool.Instance.ReturnObject(gameObject);
            return;
        }  // 주위의 적이 없으면 그냥 없어짐

        transform.position = player.position;

        if (vec.x < 0)
        {
            isFilp = true;
            spriteRenderer.flipX = false;
        }

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(vec * 30, ForceMode2D.Impulse);

        StartCoroutine(CorLogic());
    }

    public override IEnumerator CorLogic()
    {
        yield return new WaitForSeconds(3.0f);

        if (isFilp)
        {
            isFilp = false;
            spriteRenderer.flipX = true;
        }

        ObjectPool.Instance.ReturnObject(gameObject);
    }

    public override void AbilityLevelUp(int lvl)
    {
        abilityLV = lvl;

        totalDamage = damage + (abilityLV * (damage));
    }

    public override void AddCount()
    {
        count = abilityLV;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            ObjectPool.Instance.ReturnObject(gameObject);
        }
    }
}
