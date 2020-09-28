using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatch
{
    void Launch(Action WinningDelegate);
    GameObject GameObject { get; }
}
public class Server : MonoBehaviour
{
    private List<IMatch> Levels;
    private int launchedLevel = -1;
    public QuestDavid quest;
    public static bool _active = false;

    private void Awake()
    {
        Levels = new List<IMatch>();
        for(int i = 0; i < transform.childCount; i++)
        {
            Levels.Add(transform.GetChild(i).GetComponent<IMatch>()??throw new Exception("Не верный объект в дочерних"));
        }
    }
    void Start()
    {
        Play();
    }

    private void Play()
    {
        if (launchedLevel >= 0) OpenCloseLaunchedMatch(false);
        launchedLevel++;
        OpenCloseLaunchedMatch(true);
        if (launchedLevel < Levels.Count -1) Levels[launchedLevel].Launch(() => Play());
        else Levels[launchedLevel].Launch(() => 
        {
            quest.EndQuest();
            gameObject.SetActive(false);
        });
    }

    private void OpenCloseLaunchedMatch(bool action )
    {
        Levels[launchedLevel].GameObject.SetActive(action);
    }
}
