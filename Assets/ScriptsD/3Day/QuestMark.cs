using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMark : MonoBehaviour, IDialogEventHandler
{
    public GameObject work;
    public bool _break = false;

    [Header("Занавес")]
    public Image Display;
    [Header("Скорость затемнения")]
    public float speedDarken;
    [Header("Время затемнения экрана")]
    public int TimePause;
    [Header("Сцена диалога после работы")]
    public DialogManager.Scenes sceneHandler;
    [Header("Место диалога после работы")]
    public DialogManager.Places placeHandler;
    public bool moveLock;
    public AudioSource OfficeSound;
    public AudioSource _audio;

    public void FinishedHandler()
    {
        OfficeSound.Stop();
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/3DayOffice/Tragedy");
        _audio.Play();
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.ThirdDayOffice, DialogManager.Places.SolveWorkPuzzle, () => StartCoroutine(Break()), 19); ;
        StartCoroutine(dialog.OpenDialogCoroutine());
    }

    private IEnumerator Break()
    {
        float value = 0;
        while (Display.color.a < 1)
        {
            Display.color = new Color(0, 0, 0, value);
            value += speedDarken;
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(TimePause);
        while (Display.color.a > 0)
        {
            Display.color = new Color(0, 0, 0, value);
            value -= speedDarken;
            yield return new WaitForSeconds(0);
        }
        IShowDialogs dialogs = new DialogManager(sceneHandler, placeHandler);
        yield return StartCoroutine(dialogs.OpenDialogCoroutine());


    }
}
