using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffact : MonoBehaviour
{
    public GameObject Player;
    public float CameraZ = -40;

    private Camera main;

    private void Start()
    {
        main = Camera.main;
    }

    private void LateUpdate()
    {
        if (!Player)
            return;

        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 TargetPos = new Vector3(Player.transform.position.x, Player.transform.position.y, CameraZ);
        main.transform.position = Vector3.Lerp(main.transform.position, TargetPos, Time.deltaTime * 2f);

    }
}