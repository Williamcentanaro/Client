using UnityEngine;
using UnityEngine.Video;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Assets.Script
{
    public class Player : MainManager<Player>
    {
        GameObject video;
        // Use this for initialization
        void Start()
        {
            Players();
        }
        // Update is called once per frame
        public void Players()
        {
            JsonReader.Root widgetList = readJSON();
            // Collegherà un VideoPlayer alla fotocamera principale.
            video = GameObject.Find("Main Camera");
            // VideoPlayer prende automaticamente di mira il backplane della telecamera quando viene aggiunto
            // in un oggetto fotocamera, non è necessario modificare videoPlayer.targetCamera.
            var videoPlayer = video.AddComponent<VideoPlayer>();
            //  valore predefinito 
            // avviare automaticamente 
            videoPlayer.playOnAwake = false;
            //piano lontano.
            // Miriamo invece all'aereo vicino.
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
            // Questo renderà la nostra scena visibile attraverso il video riprodotto.
            videoPlayer.targetCameraAlpha = 0.5F;
            //L'URL supporta percorsi locali assoluti o relativi.
            // Qui, usando assoluto.
            //videoPlayer.url = "C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Video/LA BELLEZZA DELLA NATURA.mp4";
            // Salta i primi 100 fotogrammi.
            videoPlayer.frame = 100;
            // Riavvia dall'inizio al termine.   
            videoPlayer.isLooping = true;
            //  rallentiamo la riproduzione
            videoPlayer.loopPointReached += EndReached;
            // Avvia la riproduzione.
            videoPlayer.Play();
        }

        JsonReader.Root readJSON()
        {
            string path = Application.streamingAssetsPath + "/fileJSON.json";
            StreamReader file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            JsonReader.Root widgetList = (JsonReader.Root)serializer.Deserialize(file, typeof(JsonReader.Root));
            Debug.Log(widgetList.Screen[0].widget);
            return widgetList;
        }


        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            vp.playbackSpeed = vp.playbackSpeed / 10.0f;
        }
    }
}