using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour, IDialogEventHandler
{
    public AudioSource Office;
    public void FinishedHandler()
    {
        Office.Stop();
        IShowDialogs dialogs = new DialogManager(DialogManager.Scenes.FourthDayOffice, DialogManager.Places.SolveDreamPuzzle,() => SceneManager.LoadScene("Fin"), 62);
        StartCoroutine(dialogs.OpenDialogCoroutine());        
    }
}
