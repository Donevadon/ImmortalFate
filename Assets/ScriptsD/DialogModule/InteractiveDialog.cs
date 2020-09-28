using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Using
{
    Click,
    Start,
    EnterTrigger,
    ExitTrigger,
    Enter,
    Exit,
    DialogEvent

}
public class InteractiveDialog : MonoBehaviour
{
    public int Frequency;
    public int NumberCallEvent;
    public string nameObjectHandler;
    public Using _using;
    public DialogManager.Scenes scene;
    public DialogManager.Places place;
    private IShowDialogs dialogs;
    private int scoreClick;
    private IDialogEventHandler eventHandler;
    public bool moveLock;
    public bool FinishedDialogs;

    private void Awake()
    {
        if (nameObjectHandler == "") return;
        eventHandler = GameObject.Find(nameObjectHandler).gameObject.GetComponent<IDialogEventHandler>();
    }

    private void Start()
    {
        if (_using == Using.Start) Launch();
    }

    private void OnMouseDown()
    {
        if (_using == Using.Click && (scoreClick < Frequency || Frequency == 0)) 
        {
            if((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
                Launch(); 
        }
    }

    private void Launch()
    {
        dialogs = new DialogManager(scene, place,moveLock,eventHandler,NumberCallEvent);
        StartCoroutine(dialogs.OpenDialogCoroutine());
        scoreClick++;
    }
    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_using == Using.ExitTrigger && (scoreClick < Frequency || Frequency == 0))
        {
            if ((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
                Launch();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_using == Using.Enter && (scoreClick < Frequency || Frequency == 0))
        {
            if ((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
                Launch();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_using == Using.EnterTrigger && (scoreClick < Frequency || Frequency == 0))
        {
            if ((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
                Launch();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_using == Using.Exit && (scoreClick < Frequency || Frequency == 0))
        {
            if ((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
                Launch();
        }
    }
}
