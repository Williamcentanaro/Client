using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;



public class JsonReader : MonoBehaviour
{
  
    public TextAsset textJSON;
    [System.Serializable]
    public class Player
    {
        public int widget;
        public int x;
        public int y;
        public int h;
        public int w;
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }
    public PlayerList myPlayerList = new PlayerList();
    public void Start()
    {
        //Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPEndPoint connecting = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 52844);
        //listen.Connect(connecting);
        string json = JsonUtility.ToJson(myPlayerList);
        //myPlayerList = JsonUtility.FromJson<PlayerList>(json);
        Debug.Log(json);
    }
}
