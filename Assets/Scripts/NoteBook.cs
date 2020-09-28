using UnityEngine;
using UnityEngine.UI;

public class NoteBook : MonoBehaviour
{

    [SerializeField] private Text one;
    [SerializeField] private Text two;
    [SerializeField] private Text three;
    [SerializeField] private Text four;
    [SerializeField] private Text five;



    void Update()
    {
        one.text = PlayerPrefs.GetString("stringOne");
        two.text = PlayerPrefs.GetString("stringTwo");
        three.text = PlayerPrefs.GetString("stringThree");
        four.text = PlayerPrefs.GetString("stringFour");
        five.text = PlayerPrefs.GetString("stringFive");
    }
}
