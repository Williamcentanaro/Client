using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using NativeWebSocket;
using System.Text;
using UnityEditor.PackageManager.Requests;
using System;

namespace Assets.Script
{
    // 11/03/2021 23:43
    public class Player : MainManager<Player>
    {
        GameObject video;
        string idMacchina = "192.168.207.161";
       void Start()
       {
            Players();
       }
        public void Players()
        {
            JsonReader screen = readJSON();
            JsonMessage message = new JsonMessage(screen, idMacchina);
            /* faccio la POST */
            StartCoroutine(Post("http://localhost:3000/url", message, (UnityWebRequest req) =>
            {
                if ((req.result == UnityWebRequest.Result.ConnectionError) || (req.result == UnityWebRequest.Result.ProtocolError))
                {
                    Debug.Log($"{req.error}: {req.downloadHandler.text}");
                }
                else
                {
                    GetUrl getUrl = JsonUtility.FromJson<GetUrl>(req.downloadHandler.text);
                    Debug.Log(getUrl.url);
                }
            })); //Inserire IP SERVER al posto di localhost
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
       IEnumerator Post(string url, JsonMessage message, Action<UnityWebRequest> callback)
        {
            string output = JsonConvert.SerializeObject(message);
        
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(output);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            callback(request);
        }
        void EndReached(UnityEngine.Video.VideoPlayer vp)
        {       
            vp.playbackSpeed = vp.playbackSpeed / 10.0f;
        }
    }
}