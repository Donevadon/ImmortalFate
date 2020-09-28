using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDavid : MonoBehaviour
{
    public static bool Active;
    public Server server;
    public GameObject work;

    public void StartQuest()
    {
        Server._active = true;
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnDavid, true,()=>server.gameObject.SetActive(true),9 );
        StartCoroutine(dialog.OpenDialogCoroutine());
    }

    public void EndQuest()
    {
        work.SetActive(true);
        Active = false;
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnDavidAfterSolveServer, true, () => { print("работать"); }, 18);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Active)
        {
            if (!Server._active)
            {
                IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.EdWalkUpDavid, false);
                StartCoroutine(dialog.OpenDialogCoroutine());
            }
            else server.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        server.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Active)
        {
            if(!Server._active)
                StartQuest();
        }
    }
}
