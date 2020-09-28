using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkAboutBook : MonoBehaviour,IDialogEventHandler
{
    public float TimeFirstPause;
    public float TimeSecondPause;
    public bool moveLock;

    public void FinishedHandler()
    {
        StartCoroutine(Think());
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(TimeFirstPause);
        IShowDialogs dialogs3 = new DialogManager(DialogManager.Scenes.SecondDayStreetMorning, DialogManager.Places.ThouhtsAfterTakeBookThird,moveLock);
        yield return StartCoroutine(dialogs3.OpenDialogCoroutine());
        yield return new WaitForSeconds(TimeSecondPause);
        IShowDialogs dialogs4 = new DialogManager(DialogManager.Scenes.SecondDayStreetMorning, DialogManager.Places.ThouhtsAfterTakeBookFourth,moveLock);
        yield return StartCoroutine(dialogs4.OpenDialogCoroutine());
    }

}
