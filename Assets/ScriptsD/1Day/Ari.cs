using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ari : MonoBehaviour, IDialogEventHandler
{
    public Image Display;

    public void FinishedHandler()
    {
        StartCoroutine(Darken());
    }

    IEnumerator Darken()
    {
        Display.color = new Color(0, 0, 0, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);
    }

}
