using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonReader : MonoBehaviour
{
    public string widget { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int w { get; set; }
    public int h { get; set; }
    [System.Serializable]
    public class Root
    {
        public List<JsonReader> Screen { get; set; }
    }
}
