using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAri : MonoBehaviour, IDialogEventHandler
{
    public static QuestAri[] Other;
    public GameObject Bob;
    private bool active;


    public enum People
    {
        Ari,
        Mark,
        Secur,
        Cris,
        Alice
    }

    public People people;

    public void FinishedHandler()
    {
        if(people == People.Ari) 
        {
            Other = FindObjectsOfType<QuestAri>();
            new Inventory().AddItem<BobsDocumentsItem>();
            for(int i = 0; i < Other.Length; i++)
            {
                if (Other[i].people == People.Ari) continue;
                Other[i].active = true;
            }
        }else 
        {
                active = false;
                foreach(var i in Other)
                {
                    if (i.active) return; 
                }
                Bob.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (active) 
        {
            active = false;
            IShowDialogs dialog;
            switch (people)
            {
                case People.Alice:
                    dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnAlice,this,2);
                    break;
                case People.Cris:
                    dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnChris,this,2);
                    break;
                case People.Mark:
                    dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnMark,this,4);
                    break;
                case People.Secur:
                    dialog = new DialogManager(DialogManager.Scenes.SecondDayOffice, DialogManager.Places.ClickOnSecurity,this,3);
                    break;
                default:
                    return;
            }
            StartCoroutine(dialog.OpenDialogCoroutine());
        }
    }
}
