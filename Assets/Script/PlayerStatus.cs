using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
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

    // 플레이어 레벨
    public int level = 1;
    public float experience;
    public float maxExperience;

    protected bool isMove;

    protected Animator anim;
    protected Vector2 movement;

    // 어빌리티 모음
    public List<HasAbility> abilities;
    protected List<float> times;
}
