using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Player2 : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown("space"))
        SceneManager.LoadScene("ProgramManager");
    }
    //GameObject video;
    //private void Awake()
    //{
    //    //PassaDati();
    //    CargaDati();
    //    MainManager._instance.Play(video);
    //}
    //private void Start()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        MainManager._instance.Play(video);
    //    }
    //}
    //public void PassaDati() 
    //{
    //    MainManager._instance.video = video;
    //    video = GameObject.Find("Main Camara");
    //    MainManager._instance.SetVideo(video);
    //    var videoPlayer = video.AddComponent<VideoPlayer>();
    //    videoPlayer.url = "C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Video/LA BELLEZZA DELLA NATURA.mp4";
    //    videoPlayer.Play();
    //}
    //public void CargaDati()
    //{
    //    PassaDati();
    //    video = MainManager._instance.video;
    //}
}
