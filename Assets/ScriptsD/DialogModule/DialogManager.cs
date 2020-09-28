using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadDialogs
{
    string[][] LoadDialogs(DialogManager.Scenes scene, DialogManager.Places place);
}

public interface IDialogEventHandler
{
    void FinishedHandler();
}

/// <summary>
/// Управление диалогами и отображение согласно очереди
/// </summary>
public partial class DialogManager : MonoBehaviour,IShowDialogs
{
    private static DialogManager speaker;
    private List<IDialogPanel> dialogs;
    private ILoadDialogs loadDialogs = new DialogDataBase();
    private int numberCallEvent;
    private Action finishedHandler;
    public static bool Lock;
    private bool moveLock;


    /// <summary>
    /// Показ диалогов с использованием объекта события и указанием на каком диалоге вызвать
    ///0 : На каждом диалоге
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="place"></param>
    /// <param name="eventHandler"></param>
    /// <param name="numberCallEvent"></param>
    public DialogManager(Scenes scene,Places place,bool moveLock,IDialogEventHandler eventHandler = null, int numberCallEvent = 0)
    {
        this.moveLock = moveLock;
        this.numberCallEvent = numberCallEvent;
        if (eventHandler == null) finishedHandler = null;
        else finishedHandler = eventHandler.FinishedHandler;
        WriteDialogs(scene, place);
    }

    /// <summary>
    /// Показ диалогов без использования событий
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="place"></param>
    public DialogManager(Scenes scene, Places place,bool moveLock)
    {
        this.moveLock = moveLock;
        WriteDialogs(scene, place);
    }

    /// <summary>
    /// Показ диалогов с использованием событий, но без объекта и с указанием на какой диалоге вызвать событие
    /// 0 : На каждом диалоге
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="place"></param>
    /// <param name="eventHandler"></param>
    /// <param name="numberCallEvent"></param>
    public DialogManager(Scenes scene, Places place,bool moveLock, Action eventHandler = null, int numberCallEvent = 0)
    {
        this.moveLock = moveLock;
        this.numberCallEvent = numberCallEvent;
        finishedHandler = eventHandler;
        WriteDialogs(scene, place);
    }
    
    private void Awake()
    {
        speaker = GetComponent<DialogManager>();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Записать диалоги для отображения
    /// </summary>
    private void WriteDialogs(Scenes scene, Places place)
    {
        dialogs = new List<IDialogPanel>();
        string[][] speeches = loadDialogs.LoadDialogs(scene, place);
        for(int i = 0; i < speeches.Length; i++)
        {
            if(finishedHandler != null && 
                (i + 1 == numberCallEvent || 
                numberCallEvent == 0))
                    dialogs.Add(new PanelDialog(speeches[i][0], speeches[i][1],finishedHandler));
            else
                dialogs.Add(new PanelDialog(speeches[i][0], speeches[i][1]));
        }
    }

    public IEnumerator OpenDialogCoroutine()
    {
        while (Lock)
        {
            yield return new WaitForEndOfFrame();
        }
        PlayerControl.MoveLock = moveLock;
        Lock = true;
        if (dialogs == null) throw new Exception("Не записаны диалоги");
        foreach(var dialog in dialogs)
        {
            yield return dialog.ShowDialog();
        }
        Lock = false;
        PlayerControl.MoveLock = false;
        yield break;
    }
    public void OpenDialog()
    {
        speaker.StartCoroutine(OpenDialogCoroutine());
    }
}
