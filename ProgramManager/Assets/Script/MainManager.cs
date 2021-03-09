using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;


public class MainManager : MonoBehaviour
{
    string path;
    public GameObject video;
    public static MainManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Start()
    {
        //read JSON file;
        path = Application.streamingAssetsPath + "/fileJSON.json";
        StreamReader file = File.OpenText(path);
        JsonSerializer serializer = new JsonSerializer();
        JsonReader.Root widget = (JsonReader.Root)serializer.Deserialize(file, typeof(JsonReader.Root));
        Debug.Log(widget.Screen);
        Console.ReadKey();
        //Debug.Log(StartCoroutine(GetData_Courotine()));
        //GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);

       

        
    }
private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Player1");
        }
        else if (Input.GetKeyDown("a"))
        {
        }
        else if (Input.GetKeyDown("b"))
        {
        }
    }

}