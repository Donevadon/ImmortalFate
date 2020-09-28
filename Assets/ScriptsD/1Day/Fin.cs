using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour, IDialogEventHandler
{
    public void FinishedHandler()
    {
        IShowDialogs dialogs = new DialogManager(DialogManager.Scenes.FourthDayOffice, DialogManager.Places.SolveDreamPuzzle,true,() => SceneManager.LoadScene(14), 62);
        StartCoroutine(dialogs.OpenDialogCoroutine());        
    }
}
