using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICheckLamp 
{
    Lamp.Color ColorLamp { get; }
    Lamp.Color WinningColor { get; }
}

public interface ICheckTrue
{
    event Action CheckTrue;
}

public class Match : MonoBehaviour,IMatch
{
    private List<ICheckLamp> lampsRed;
    private List<ICheckLamp> lampGreen;

    private event Action matchIsOver;
    private AudioSource _audio;

    public GameObject GameObject => gameObject;

    private void Awake()
    {
        lampsRed = new List<ICheckLamp>();
        lampGreen = new List<ICheckLamp>();
        _audio = GetComponent<AudioSource>();
        AddLamp();
    }

    private void CheckLamp()
    {
        foreach (var lamp in lampGreen)
        {
            if (lamp.ColorLamp != Lamp.Color.Green)
                return;
        }
        foreach (var lamp in lampsRed)
        {
            if (lamp.ColorLamp != Lamp.Color.Red)
                return;
        }
        matchIsOver.Invoke();
    }

    private void AddLamp()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ICheckTrue>() != null) 
                transform.GetChild(i).GetComponent<ICheckTrue>().CheckTrue += () => 
                {
                    _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/ClickServer");
                    _audio.Play();
                    CheckLamp(); 
                };
            else
            {
                ICheckLamp lamp = transform.GetChild(i).GetComponent<ICheckLamp>();
                if (lamp.WinningColor == Lamp.Color.Green) lampGreen.Add(lamp);
                else lampsRed.Add(lamp);
            }
        }
    }

    public void Launch(Action WinningDelegate)
    {
        matchIsOver += WinningDelegate;
    }
}
