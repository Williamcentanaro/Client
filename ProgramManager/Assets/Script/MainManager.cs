using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    public GameObject video;
    public static MainManager _instance;
    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(_instance != this) {
            Destroy(gameObject);
            return;
        }
    }
        public void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown("space")) { 
            SceneManager.LoadScene("Player1"); 
        }
    }
}