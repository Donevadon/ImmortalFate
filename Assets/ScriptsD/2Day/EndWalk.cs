using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using Assets.DialogModule.EventSystem.Interactive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndWalk : MonoBehaviour, IDialogEventHandler
{
    public bool moveLock;
    private Inventory inventory = new Inventory();
    public void FinishedHandler()
    {
        if (inventory.FindObject<BookItem>())
        {
            new Inventory().RemoveItem<BookItem>();
            IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.GiveBookAri, GetComponent<TransitionsScenes>().FinishedHandler, 6);
            StartCoroutine(dialog.OpenDialogCoroutine());
        }
        else
        {
            IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.DontGiveBookAri, GetComponent<TransitionsScenes>().FinishedHandler, 7);
            StartCoroutine(dialog.OpenDialogCoroutine());
        }

    }
}
