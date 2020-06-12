using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        transform.position = new Vector3(10, 1, -30);
    }
        void Update()
    {
        if(player.transform.position.x > 10)
        transform.position = new Vector3(player.transform.position.x, 1, -30);
    }
}
