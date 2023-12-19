using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenScrollbarSet : MonoBehaviour
{
    public Scrollbar bar;
    private void OnEnable()
    {
        Invoke("GoLast", 0.1f);
    }

    public void GoLast()
    {
        bar.value = 0;
    }
}
