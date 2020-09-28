using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Security : MonoBehaviour, IDialogEventHandler
{
    public int scene;
    public void FinishedHandler()
    {
        SceneManager.LoadScene(scene);
    }
}
