using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

namespace Assets.Script
{
    // 11/03/2021 23:43
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
            string idMacchina = "192.168.207.161";
            JsonReader screen = readJSON();
            JsonMessage message = new JsonMessage(screen, idMacchina);
            /* faccio la POST */
            StartCoroutine(Post("localhost", message));



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

        JsonReader readJSON()
        {
            string path = Application.streamingAssetsPath + "/fileJSON.json";
            JsonReader screen = JsonConvert.DeserializeObject<JsonReader>(File.ReadAllText(path));
            return screen;
        }

        IEnumerator Post(string url, JsonMessage message)
        {
            string output = JsonConvert.SerializeObject(message);
            Debug.Log("Url " + url);
            Debug.Log("JSON: " + output);
            Debug.Log("FINE POST");
        
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(output);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Status Code: " + request.responseCode);
        }


        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {
            vp.playbackSpeed = vp.playbackSpeed / 10.0f;
        }
    }

    internal class UnityWebRequest
    {
        internal UploadHandler uploadHandler;
        private string url;
        private string v;

        public UnityWebRequest(string url, string v)
        {
            this.url = url;
            this.v = v;
        }
    }
}