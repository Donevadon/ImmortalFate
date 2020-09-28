using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencePanel : MonoBehaviour
{
    public SpriteRenderer door;
    public Sprite OpenDoor;
    public Panel panel;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        panel.Corrected += Open;
        panel.Corrected += ClosePanel;
        panel.Corrected += () =>
        {
            IShowDialogs dialogs = new DialogManager(DialogManager.Scenes.FirstDayStreetMorning, DialogManager.Places.SolveDoorPuzzle,false);
            StartCoroutine(dialogs.OpenDialogCoroutine());
        };
    }

    private void Open()
    {
        boxCollider.isTrigger = true;
        door.sprite = OpenDoor;
    }

    private void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        panel.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        panel.gameObject.SetActive(false);
    }
}
