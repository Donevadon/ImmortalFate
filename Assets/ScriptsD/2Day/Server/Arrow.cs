using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ILamp
{
    void ClickHandler();
}
public class Arrow : MonoBehaviour,IPointerDownHandler,ICheckTrue
{
    public Lamp[] lamps;

    public event Action CheckTrue;

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickHandler();
        CheckTrue.Invoke();
    }

    private void ClickHandler()
    {
        foreach (ILamp lamp in lamps)
        {
            lamp.ClickHandler();
        }
    }
}
