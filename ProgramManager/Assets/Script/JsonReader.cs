using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;




public class JsonReader : MonoBehaviour
{
    public TextAsset fileJSON;
    [System.Serializable]
    public class Player
    {
        public string widget;
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
        myPlayerList = JsonUtility.FromJson<PlayerList>(fileJSON.text);
    }
}
