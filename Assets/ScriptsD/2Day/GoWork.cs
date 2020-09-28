using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoWork : MonoBehaviour,IDialogEventHandler
{
    public Image Display;
    public float speedDarken;
    public int timePause;
    public string nameScene;

    public void FinishedHandler()
    {
        Go();
    }

    private void Go()
    {
        StartCoroutine(Darken());
    }

    IEnumerator Darken()
    {
        float value = 0;
        while (Display.color.a < 1)
        {
            Display.color = new Color(0, 0, 0, value);
            value += speedDarken;
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(timePause);
        SceneManager.LoadScene(nameScene);
        yield break;
    }

}
