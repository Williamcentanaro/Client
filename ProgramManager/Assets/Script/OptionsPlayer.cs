using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionsPlayer : MonoBehaviour
{
    public int x { get; set; }
    public int w { get; set; }
    public int h { get; set; }
    public int y { get; set; }
    public string fullScreen { get; set; }

    public static OptionsPlayer CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<OptionsPlayer>(jsonString);
    }

}
