using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {        
        if ((ulong)transform.GetComponent<VideoPlayer>().frame == transform.GetComponent<VideoPlayer>().frameCount - 1)
        {            
            SceneManager.LoadScene(1);
        }
    }

    
}
