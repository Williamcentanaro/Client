using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject bottone;
    public GameObject video;
    public static MainManager _instance;
    //public static MainManager Instance { get; set; }


    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            //non distruggere game object
            DontDestroyOnLoad(gameObject);
            video = GetComponent<GameObject>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
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
        videoPlayer.url = "C:/Users/Alessandro/Desktop/Calcolatrice/ProgramManager/Assets/Video/LA BELLEZZA DELLA NATURA.mp4";

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
      
    
}