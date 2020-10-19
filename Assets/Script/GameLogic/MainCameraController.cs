using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 tempPos;
    void Start()
    {
        tempPos = transform.position;
    }

    void Update () {
        tempPos = player.transform.position;
        tempPos.y = tempPos.y / 1.5f ;
        tempPos.z = tempPos.z - 1;
        transform.position = tempPos;
    }
}
