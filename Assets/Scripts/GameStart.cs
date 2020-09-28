
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{


    void Start()
    {
        if (PlayerPrefs.HasKey("Slot1")) {
            PlayerPrefs.SetInt("SLot1",0);
            PlayerPrefs.SetInt("SLot2",0);
            PlayerPrefs.SetInt("SLot3",0);
            PlayerPrefs.SetInt("SLot4",0);
            PlayerPrefs.SetInt("SLot5",0);
            PlayerPrefs.SetInt("SLot6",0);
            PlayerPrefs.SetInt("SLot7",0);
            PlayerPrefs.SetInt("SLot8",0);
            PlayerPrefs.SetInt("SLot9",0);
            PlayerPrefs.SetInt("SLot10",0);

            PlayerPrefs.SetString("stringOne", ".");
            PlayerPrefs.SetString("stringTwo", ".");
            PlayerPrefs.SetString("stringThree", ".");
            PlayerPrefs.SetString("stringFour", ".");
            PlayerPrefs.SetString("stringFive", ".");

            PlayerPrefs.SetString("level", "Intro");
        }
        if (PlayerPrefs.GetString("level") != "Intro") {
            //SceneManager.LoadScene(PlayerPrefs.GetString("level"));
        }
    }


}
