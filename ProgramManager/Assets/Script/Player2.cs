using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Player2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("space")) { SceneManager.LoadScene("ProgramManager"); }
    }
   
}
