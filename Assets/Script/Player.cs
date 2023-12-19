using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    public float playerDamage = 5.0f;
    public float speed = 10.0f;
    public float coolTime = 1f;
    public float maxHp = 100;
    public float curHp;

    public GameObject gameOverPanel;
    public Controller controller;
    public SpriteRenderer sprite;
    public Image hpImage;

    private bool isMove;

    private Animator anim;
    private Vector2 movement;

    /// <summary>
    /// 능력
    /// </summary>

    // 어빌리티 모음
    public List<HasAbility> abilities;
    private List<float> times;

    private void Start()
    {
        curHp = maxHp;
        anim = GetComponentInChildren<Animator>();

        times = new List<float>();

        for(int i = 0; i < abilities.Count; i++)
        {
            abilities[i].OffHasAbility();
            times.Add(abilities[i].ability.coolTime);
        }

        abilities[0].OnHasAbility();
    }

    private void Update()
    {
        Move();
        Attack();
    }
    
    public bool IsFlip()
    {
        return sprite.flipX;
    }

    private void Move()
    {
        Vector2 dir;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)   // 하드웨어 조작 입력시
        {
            // 하드웨어 조작
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            dir = movement.normalized;
        }
        else
        {
            //  터치스크린 조작
            movement = controller.vecJoystickValue;
            dir = movement;//.normalized;

            if (dir.magnitude < -1 || dir.magnitude > 1)
                dir = movement.normalized;

        }

        isMove = (movement.magnitude != 0);

        if (isMove)
        {
            if (movement.x > 0)         // 우로 회전
            {
                sprite.flipX = false;
            }
            else if(movement.x < 0)     // 좌로 회전
            {
                sprite.flipX = true;
            }

            transform.Translate(dir * Time.deltaTime * speed);  // 방향으로 이동
            
            anim.SetBool("isRun", true);                        // Run 애니메이션
        }
        else {
            anim.SetBool("isRun", false);                       // Idle 애니메이션
        }
    }

    private void Attack()
    {
        for(int i = 0; i < abilities.Count; i++)
        {
            if (abilities[i].hasAbility)
            {
                times[i] -= Time.deltaTime;

                if (times[i] <= 0)
                {
                    times[i] = abilities[i].ability.coolTime * coolTime;

                    abilities[i].ability.SetPlayer(transform);

                    int count = 0;

                    for (int j = -1; j < count; j++)
                    {
                        GameObject ago = ObjectPool.Instance.GetObject(abilities[i].abilityName);
                        Ability ability = ago.GetComponent<Ability>();
                        
                        if (ability.count != 0)
                            count = ability.count;

                        ago.SetActive(true);

                        ability.Logic();
                    }
                }
            }
        }
    }

    // 레벨업
    public void LevelUp(float soulAmount)
    {
        GameManager.inst.LevelUp(soulAmount);
    }

    // 플레이어 현재 HP 표시
    public void PrintPlayerHp(float damage)
    {
        // 플레이어 체력이 30퍼 이하 일때 받는 피해 절반으로
        if(curHp < maxHp * 0.3)
            curHp -= damage / 2;
        else
            curHp -= damage;

        hpImage.fillAmount = curHp / maxHp;

        if(curHp <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
