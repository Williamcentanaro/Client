using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Sockets;
using System.Net;
using System.Text;
public class MainManager : MonoBehaviour
{
    #region JsonReader
    string path;
   #endregion
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
        #region read JSON file
        //read JSON file;
        path = Application.streamingAssetsPath + "/fileJSON.json";
        StreamReader file = File.OpenText(path);
        JsonSerializer serializer = new JsonSerializer();
        JsonReader.Root widget = (JsonReader.Root)serializer.Deserialize(file, typeof(JsonReader.Root));
        Debug.Log(widget.Screen[0].widget);
        Console.ReadKey();
        #endregion
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Player1");
        }
    }
}