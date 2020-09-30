using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Work : MonoBehaviour, IDialogEventHandler
{
    [Header("Занавес")]
    public Image Display;
    [Header("Скорость затемнения")]
    public float speedDarken;
    [Header("Время затемнения экрана")]
    public int TimePause;
    public GameObject Player;
    [Header("Место появления после работы")]
    public Vector2 UnworkPoint;
    [Header("Сцена диалога после работы")]
    public DialogManager.Scenes sceneHandler;
    [Header("Место диалога после работы")]
    public DialogManager.Places placeHandler;
    public bool moveLock;
    public Fin ari;
    private AudioSource _audio;

    public QuestMark mark;
    public void FinishedHandler()
    {
        Working();
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Working()
    {
        StartCoroutine(Darken());
    }

    IEnumerator Darken()
    {
        float value = 0;
        while(Display.color.a < 1)
        {
            Display.color = new Color(0,0,0, value);
            value += speedDarken;
            yield return new WaitForSeconds(0);
        }
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/SoundWork");
        _audio.Play();
        yield return new WaitForEndOfFrame();
        Player.transform.position = new Vector3(UnworkPoint.x,UnworkPoint.y,Player.transform.position.z);
        Camera.main.transform.position = new Vector3(UnworkPoint.x, UnworkPoint.y, Camera.main.transform.position.z);
        yield return new WaitForSeconds(TimePause);
        _audio.Stop();
        while (Display.color.a > 0)
        {
            Display.color = new Color(0, 0, 0, value);
            value -= speedDarken;
            yield return new WaitForSeconds(0);
        }
        if (mark is null && ari is null)
        {
            IShowDialogs dialogs = new DialogManager(sceneHandler, placeHandler, moveLock);
            yield return StartCoroutine(dialogs.OpenDialogCoroutine());
        }
        else if (ari is null)
        {
            mark.FinishedHandler();
        }
        else ari.FinishedHandler();
    }
}
