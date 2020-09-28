using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsScenes : MonoBehaviour,IDialogEventHandler
{
    public string nameScene;
    public Using @using;
    public bool FinishedDialogs;


    public void OnMouseDown()
    {
        if(@using == Using.Click)
            Load();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(@using == Using.EnterTrigger) Load();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(@using == Using.ExitTrigger) Load();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (@using == Using.Enter) Load();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (@using == Using.Exit) Load();
    }

    public void FinishedHandler()
    {
        if (@using == Using.DialogEvent) Load();
    }

    private void Load()
    {
        if ((FinishedDialogs && !DialogManager.Lock) || !FinishedDialogs)
            SceneManager.LoadScene(nameScene);
    }
}
