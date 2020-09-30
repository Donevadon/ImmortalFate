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
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        panel.Corrected += Open;
        panel.Corrected += ClosePanel;
        panel.Corrected += () =>
        {
            _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/Correct");
            _audio.Play();
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
