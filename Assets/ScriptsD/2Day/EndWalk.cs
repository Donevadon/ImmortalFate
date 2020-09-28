using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWalk : MonoBehaviour, IDialogEventHandler
{
    public bool moveLock;
    public void FinishedHandler()
    {
        new Inventory().RemoveItem<BookItem>();
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.GiveBookAri,moveLock,()=> SceneManager.LoadScene("3DayHomeMorning"),6);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }
}
