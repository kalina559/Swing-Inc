using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "intro.mp4");
        //videoPlayer.Prepare();
        //videoPlayer.Play();
    }
    //Update is called once per frame
    void Update()
    {
        videoPlayer.Play();
        if ((ulong)videoPlayer.frame == (videoPlayer.frameCount - 1) && videoPlayer.frame != -1)
        {
            SceneManager.LoadScene(1);
        }
    }

    
}
