using Assets.DialogModule;
using Assets.DialogModule.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AriMove : MonoBehaviour,IDialogEventHandler
{
    public float speed;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public AudioSource Office;
    public AudioSource _audio;
    public int move;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(move != 0)
            Move();
    }

    protected virtual void Move()
    {
        if (move != 0)
        {
            rigidbody2D.velocity = new Vector2(move * speed, 0);
            animator.SetBool("Move", true);
            if (move < 0 && transform.localScale.x > 0 || move > 0 && transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            animator.SetBool("Move", false);
        }
    }

    public void FinishedHandler()
    {
        Office.Stop();
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/4DayOffice/Office");
        _audio.Play();
        IShowDialogs dialogs = new DialogManager(DialogManager.Scenes.FourthDayOffice, DialogManager.Places.SolveDreamPuzzle, () => move = -1, 19);
        StartCoroutine(dialogs.OpenDialogCoroutine());
    }
}
