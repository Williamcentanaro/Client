using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class JsonReader : MonoBehaviour
{
    public TextAsset textJSON;


    [System.Serializable]
    public class Player
    {
        public int widget { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int h { get; set; }
        public int w { get; set; }
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }
    public PlayerList myPlayerList = new PlayerList();
    public void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
    }
}
