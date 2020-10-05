using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBob : MonoBehaviour,IDialogEventHandler
{
    public Printer printer;
    public bool moveLock;
    public void FinishedHandler()
    {
        new Inventory().RemoveItem<BobsDocumentsItem>();
        StartQuest();
    }

    private void StartQuest()
    {
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.BobGivePrinterQuest,()=> 
        {
            new Inventory().AddItem<TipItem>();
            printer.ActiveQuest = true;
        },12);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }

}
