using UnityEngine;
using UnityEngine.SceneManagement;

public class Saver : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name );
    }
}
