using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonReader : MonoBehaviour
{
    
    public TextAsset fileJSON;
    [System.Serializable]
    public class Player
    {
        [System.Serializable]
        public class PlayerList
        {
            public string widget;
            public int x;
            public int y;
            public int h;
            public int w;
        }
        public List<PlayerList> player;
    }
    public Player player;
    [ContextMenu("Read")]
    public void Read()
    {
            StartCoroutine(CorrutinRead());
        // fileJSON.text= JsonUtility.ToJson(myPlayerList);
    }
    private IEnumerator CorrutinRead()
    {
        UnityWebRequest web = UnityWebRequest.Get("file:///C:/Users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Script/StreamingAssets/fileJSON.json");
        yield return web.SendWebRequest();
        if(!web.isNetworkError && !web.isHttpError)
        {
          player = JsonUtility.FromJson<Player>(web.downloadHandler.text);
        }
        else { Debug.Log("404 not found"); }
     } //   
    [ContextMenu("write")]
    public void write()
    {
        StartCoroutine(CorrutinWrite());
        // fileJSON.text= JsonUtility.ToJson(myPlayerList);
    }
    private IEnumerator CorrutinWrite()
    {
        WWWForm form = new WWWForm();
        form.AddField("Player", "fileJSON.txt");
        form.AddField("texto", JsonUtility.ToJson(player));
        UnityWebRequest web = UnityWebRequest.Post("https://users/Alessandro/Documents/GitHub/PRJECT/ProgramManager/Assets/Script/StreamingAssets", form);
        yield return web.SendWebRequest();
        if (!web.isNetworkError && !web.isHttpError)
        {
            Debug.Log(web.downloadHandler.text);
        }
        else { Debug.LogWarning("404 not found"); }
    }
} 
