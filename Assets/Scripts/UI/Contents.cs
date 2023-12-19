using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Contents : MonoBehaviour
{
    private void OnEnable()
    { UIController.inst.contents.Add(this); }

    private void OnDisable()
    { UIController.inst.contents.Remove(this); }

    public void SetOff()
    { gameObject.SetActive(false); }
}
