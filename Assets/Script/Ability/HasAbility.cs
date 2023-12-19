using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability Data", menuName = "Scriptable Object/Ability/Ability Data", order = int.MaxValue)]
public class HasAbility : ScriptableObject
{
    /// <summary>
    /// 능력
    /// </summary>

    // 능력 획득 유무
    // 능력 유지 시간
    // 능력 이름
    // 능력 프리팹

    [SerializeField] public bool hasAbility;
    [SerializeField] public string abilityName;
    [SerializeField] public Ability ability;

    public void OnHasAbility()
    {
        hasAbility = true;
    }

    public void OffHasAbility()
    {
        hasAbility = false;
    }
}
