using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < Camera.main.transform.position.x - 28)
        {
            //+35
            //float x = UnityEngine.Random.Range(Camera.main.transform.position.x + 29f, Camera.main.transform.position.x + 30.0f);
            float x = Camera.main.transform.position.x + 30.0f;
            float y = UnityEngine.Random.Range(-15.5f, 17.6f);

            transform.position = new Vector2(x, y);
        }
    }
}
