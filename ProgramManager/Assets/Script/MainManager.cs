using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class MainManager : MonoBehaviour
{
    public GameObject video;
    public static MainManager _instance;

    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this) {
            Destroy(gameObject);
            return;
        }
    }
        public void Start()
    {
        //Debug.Log(StartCoroutine(GetData_Courotine()));
        //GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);

        //read JSON file;

        StreamReader sr = new StreamReader("config.json");
        string jsonString = sr.ReadToEnd();
        OptionsPlayer options = JsonUtility.FromJson<OptionsPlayer>(jsonString);
        Debug.LogFormat("x:{0} w:{1} h:{2} y:{3} fullScreen:{4}", options.x, options.w, options.h, options.y, options.fullScreen);
        
    }
private void Update()
    {
        if (Input.GetKeyDown("space")) { 
            SceneManager.LoadScene("Player1");
        }else if (Input.GetKeyDown("a"))
        {
           Debug.Log(StartCoroutine(GetData_Courotine()));
        }
        else if (Input.GetKeyDown("b"))
        {
            Debug.Log(StartCoroutine(PostData_Courotine()));
        }
    }
    //void GetData() => StartCoroutine(GetData_Courotine());
    IEnumerator GetData_Courotine()
    {
        string uri = "C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Script/StreamingAssets/fileJSON.json";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if(request.isNetworkError || request.isHttpError)
            { Debug.Log(request.error); }
            else { Debug.Log(request.downloadHandler.text); }
        }
    }
    IEnumerator PostData_Courotine()
    {
        string uri = "C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Script/StreamingAssets/fileJSON.json";
        WWWForm form = new WWWForm();
        form.AddField("title", "test data");
        using (UnityWebRequest request = UnityWebRequest.Post(uri,form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            { Debug.Log(request.error); }
            else { Debug.Log(request.downloadHandler.text); }
        }
    }
}