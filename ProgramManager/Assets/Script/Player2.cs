using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("space")) { SceneManager.LoadScene("ProgramManager"); }
    }

}
