using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour,ILamp,ICheckLamp
{
    public enum Color
    {
        Green,
        Red
    }

    [SerializeField]private Color _color;
    [SerializeField] private Color winnerColor;

    public Color ColorLamp => _color;
    public Color WinningColor => winnerColor;

    public void ClickHandler()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        switch (_color)
        {
            case Color.Green:
                _color = Color.Red;
                break;
            case Color.Red:
                _color = Color.Green;
                break;
        }
        ChangeSprite();
    }
    private void Awake()
    {
        ChangeSprite();
    }
    private void ChangeSprite()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Servernaya/1/{_color.ToString()}");
    }
}
