using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallyWalk : MonoBehaviour,IDialogEventHandler
{
    public GameObject door;
    public void FinishedHandler()
    {
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.FourthDayStreetEvening, DialogManager.Places.HeroesLeaveOfficeSecond, () => door.SetActive(true),26);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }

}
