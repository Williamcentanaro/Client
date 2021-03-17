using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using NativeWebSocket;
namespace Assets.Script
{
    // 11/03/2021 23:43
    public class Player : MainManager<Player>
    {
        GameObject video;
        string idMacchina = "192.168.207.161";
        //private bool intentionalClose;
        WebSocket ws;
        // Use this for initialization
        private void SetupWebsocketCallbacks()
        {
            ws.OnOpen += () =>
            {
                JsonReader screen = readJSON();
                JsonMessage message = new JsonMessage(screen, idMacchina);
                StartCoroutine(Post("localhost", message));//Inserire IP SERVER al posto di localhost**/
                SendWebSocketMessage(JsonConvert.SerializeObject(message));
            };
            ws.OnError += (e) =>
            {
                Debug.Log("Error! " + e);
            };
            ws.OnClose += (e) =>
            {
                Debug.Log("Connection closed!");
            };
            ws.OnMessage += (bytes) =>
            {
                Debug.Log("OnMessage!");
                string message = System.Text.Encoding.UTF8.GetString(bytes);
                Debug.Log(message.ToString());
              
            };
        }
        // Connects to the websocket
        async public void FindMatch()
        {
            // waiting for messages
            await ws.Connect();
        }
        public async void SendWebSocketMessage(string message)
        {
            if (ws.State == WebSocketState.Open)
            {
                // Sending plain text
                await ws.SendText(message);
            }
        }
        private async void OnApplicationQuit()
        {
            await ws.Close();
        }
        void Start()
        {
            Debug.Log("Websocket start");
            //intentionalClose = false;
            ws= new WebSocket("ws://localhost:8080");
            Players();
            SetupWebsocketCallbacks();
            FindMatch();
        }
        void Update()
        {
       #if !UNITY_WEBGL || UNITY_EDITOR
            ws.DispatchMessageQueue();
       #endif
        }
        public void Players()
        {
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
            videoPlayer.url = "C:/Users/William/Documents/GitHub/Cliente/ProgramManager/Assets/Video/pippo.mp4";
            // Salta i primi 100 fotogrammi.
            videoPlayer.frame = 0;
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
}