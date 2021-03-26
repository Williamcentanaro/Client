using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;

namespace Assets.Script
{


    public class Player : MainManager<Player>
    {
        private readonly string mybasePath = "http://shpcvm-b3c74.serverlet.com/api/videos/KJ1270002E192800067A?key=swevendo605c833467237";
        GameObject video;
        private List<string> videoList;
        private int nVideo = 0;

        void Start()
        {
            videoList = new List<string>();
            Players();
        }


        public void Players()
        {

            RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";


            RestClient.GetArray<Videos>(mybasePath).Then(res => {
                //Debug.Log(JsonHelper.ArrayToJsonString<Videos>(res, true));

                foreach (Videos cv in res)
                {
                    if (cv.videos.Count > 0)
                    {
                        Debug.Log(cv.videos[0].video);
                        videoList.Add(cv.videos[0].video);
                    }
                    else
                    {
                        videoList.Add("null");
                    }
                    nVideo++;
                    if (nVideo >= 10)
                        downloadVideo();
                }
            }).Catch(err => Debug.Log(err.Message));

        }

        public void downloadVideo()
        {
            Debug.Log("downloadVideo\n");
            Debug.Log("nVideo = " + nVideo);

            foreach(string cv in videoList)
            {
                if (cv != "null") {
                    StartVideo(cv);
                    //Debug.Log("downloadVideo -> cv -> " + cv);
                    //WebClient client = new WebClient();
                    //client.DownloadFile(cv, @"C:\pippo.mp4");
                }
            }


            Debug.Log("FINE");



            /*
            JsonReader screen = readJSON();
            JsonMessage message = new JsonMessage(screen, idMacchina);
            //StartCoroutine(Get("http://localhost:3000/url", (UnityWebRequest req)
            Debug.Log("MESSAGE : -> " + message);
            StartCoroutine(Post("http://localhost:3000/url",message,  (UnityWebRequest req) =>
            {
                if ((req.result == UnityWebRequest.Result.ConnectionError) || (req.result == UnityWebRequest.Result.ProtocolError))
                {
                    Debug.Log($"{req.error}: {req.downloadHandler.text}");
                }
                else
                {
                    VideoJson videoFile = JsonConvert.DeserializeObject<VideoJson>(req.downloadHandler.text);
                    Debug.Log(videoFile.url);
                    StartVideo(videoFile.url);
                }
            }));
            */
        }


        void StartVideo(string videoUrl)
        {
            // Collegherà un VideoPlayer alla fotocamera principale.
            video = GameObject.Find("Main Camera");
            // VideoPlayer prende automaticamente di mira il backplane della telecamera quando viene aggiunto
            // in un oggetto fotocamera, non è necessario modificare videoPlayer.targetCamera.
            var videoPlayer = video.AddComponent<VideoPlayer>();
            //Associo l'url dello streaming al VideoPlayer
            videoPlayer.url = videoUrl;
            //  valore predefinito 
            // avviare automaticamente 
            videoPlayer.playOnAwake = false;
            //piano lontano.
            // Miriamo invece all'aereo vicino.
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            // Questo renderà la nostra scena visibile attraverso il video riprodotto.
            videoPlayer.targetCameraAlpha = 0.5F;
            // Riavvia dall'inizio al termine.   
            videoPlayer.isLooping = false;
            //  rallentiamo la riproduzione
            videoPlayer.loopPointReached += EndReached;
            // Avvia la riproduzione.
            videoPlayer.Play();
        }
        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            vp.playbackSpeed = vp.playbackSpeed / 10.0f;
        }
    }
}