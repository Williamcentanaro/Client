using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


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
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        Player player = new Player();
        string json =JsonUtility.ToJson(player);
        player = JsonUtility.FromJson<Player>(json);
        player = JsonUtility.FromJson<Player>(json);
    }
}
