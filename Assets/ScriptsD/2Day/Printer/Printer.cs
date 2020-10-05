using Assets.DialogModule;
using System.Collections;
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
    public GameObject Items;
    private AudioSource _audio;
    private Coroutine Hint;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void UpdateGear()
    {
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/InstallGear");
        _audio.Play();
        foreach (var place in places)
        {
            if (place.gear?.Meud != place.Meud) return;
        }
        Win();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ActiveQuest)
        {
            Items.SetActive(true);
            if (activeDialog) 
            {
                IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.OpenPrinterPanel);
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
                IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClosePrinterPanel);
                StartCoroutine(dialog.OpenDialogCoroutine());
                activeDialog = false;
            }
            panel.SetActive(false);
        }
    }

    public void StartHind()
    {
       Hint = StartCoroutine(Hind());
    }

    IEnumerator Hind()
    {
        yield return new WaitForSeconds(60);
        IShowDialogs dialog1 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintFirst);
        yield return StartCoroutine(dialog1.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog2 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintSecond);
        yield return StartCoroutine(dialog2.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog3 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintThird);
        yield return StartCoroutine(dialog3.OpenDialogCoroutine());
        yield return new WaitForSeconds(60);
        IShowDialogs dialog4 = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.GearsHintFourth);
        yield return StartCoroutine(dialog4.OpenDialogCoroutine());

    }

    private void Win()
    {
        StopCoroutine(Hint);
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/PrinterLaunch");
        _audio.Play();
        ActiveQuest = false;
        panel.SetActive(false);
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.SolveGears, () => QuestDavid.Active = true, 5);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }
}
