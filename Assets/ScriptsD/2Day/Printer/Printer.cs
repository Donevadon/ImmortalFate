﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IGears
{
    Meud Meud { get; }
}

public enum Meud
{
    Little,
    Cuibheasach,
    Big

}

public interface IPlaceGears
{
    IGears gear { get; }
    Meud Meud { get; }
}

public interface IPrinter
{
    void UpdateGear();
}


public class Printer : MonoBehaviour,IPrinter
{
    public PlaceGears[] places = new PlaceGears[4];
    public GameObject panel;
    public bool ActiveQuest = true;
    private bool activeDialog = true;

    public void UpdateGear()
    {
        foreach(var place in places)
        {
            if (place.gear?.Meud != place.Meud) return;
        }
        Win();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ActiveQuest)
        {
            if (activeDialog) 
            {
                IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.OpenPrinterPanel, false);
                StartCoroutine(dialog.OpenDialogCoroutine());
            }
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ActiveQuest)
        {
            if (activeDialog) 
            {
                IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClosePrinterPanel, false);
                StartCoroutine(dialog.OpenDialogCoroutine());
                activeDialog = false;
            }
            panel.SetActive(false);
        }
    }

    public void StartHind()
    {
        StartCoroutine(Hind());
    }

    IEnumerator Hind()
    {
        yield return new WaitForSeconds(60);
        IShowDialogs dialog1 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintFirst,false);
        yield return StartCoroutine(dialog1.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog2 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintSecond, false);
        yield return StartCoroutine(dialog2.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog3 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintThird, false);
        yield return StartCoroutine(dialog3.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog4 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintFourth, false);
        yield return StartCoroutine(dialog4.OpenDialogCoroutine());

    }

    private void Win()
    {
        StopCoroutine(Hind());
        ActiveQuest = false;
        panel.SetActive(false);
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.SolveGears, true, () => QuestDavid.Active = true, 5);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }
}
