using UnityEngine;
using UnityEngine.Video;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    //#region Soccket variabili
    //Socket connection;
    
    //int array_size =0;
    //#endregion
    public GameObject video;
    public static MainManager _instance;
    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            //non distruggere game object
            DontDestroyOnLoad(gameObject);  
            //video = GetComponent<GameObject>();
            video = GetComponent<GameObject>();
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    private void Start()
    {
        Play(video);

        //Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        //IPEndPoint connecting = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 52844);

        //listen.Bind(connecting);
        //listen.Listen(10);
        //connection = listen.Accept();
        //String data = "";


        //byte[] ricevi_info = new byte[100];
        //array_size = connection.Receive(ricevi_info, 0, ricevi_info.Length, 0);
        //Array.Resize(ref ricevi_info, array_size);
        //data = Encoding.Default.GetString(ricevi_info);
        //Debug.Log("La informazione ricevuta è : {0}");
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Player1");
        }
    }
    public void Play(GameObject  video)
    {
        // Collegherà un VideoPlayer alla fotocamera principale.
        video = GameObject.Find("Main Camera");
        // VideoPlayer prende automaticamente di mira il backplane della telecamera quando viene aggiunto
        // in un oggetto fotocamera, non è necessario modificare videoPlayer.targetCamera.
        var videoPlayer = video.AddComponent<VideoPlayer>();
        // Riproduci su sveglio il valore predefinito è true. Impostalo su false per evitare l'URL impostato
        // sotto per avviare automaticamente la riproduzione poiché siamo in Start ().
        videoPlayer.playOnAwake = false;
        // Per impostazione predefinita, i VideoPlayer aggiunti a una telecamera utilizzeranno il piano lontano.
        // Miriamo invece all'aereo vicino.
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        // Questo renderà la nostra scena visibile attraverso il video riprodotto.
        videoPlayer.targetCameraAlpha = 0.5F;
        // Imposta la riproduzione del video. L'URL supporta percorsi locali assoluti o relativi.
        // Qui, usando assoluto.
        videoPlayer.url = "C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Video/LA BELLEZZA DELLA NATURA.mp4";
        // Salta i primi 100 fotogrammi.
        videoPlayer.frame = 100;
        // Riavvia dall'inizio al termine.
        videoPlayer.isLooping = true;
        // Ogni volta che raggiungiamo la fine, rallentiamo la riproduzione di un fattore 10.
        videoPlayer.loopPointReached += EndReached;
        // Avvia la riproduzione. Ciò significa che VideoPlayer potrebbe dover preparare (riserva
        // risorse, precarica alcuni frame, ecc.). Per controllare meglio i ritardi
        // associato a questa preparazione si può usare videoPlayer.Prepare () insieme a
        // il suo evento prepareCompleted. 
        videoPlayer.Play();
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0f;
    }
    public void CambioScena()
    {
       SceneManager.LoadScene("Player1");
    }
    public void SetVideo(GameObject v)
    {
        v = video;
    }
    public GameObject GetVideo(GameObject video)
    {
        return video;
    }
}