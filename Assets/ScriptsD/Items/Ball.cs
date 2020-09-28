using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour, IDialogEventHandler
{
    public Vector2 stopPoint;
    public float Speed;
    private Animator _animation;
    private int scoreEvents;

    public void FinishedHandler()
    {
            scoreEvents++;
        if(scoreEvents == 4)
            StartCoroutine(Move());
        else if(scoreEvents == 5)
        {
            IShowDialogs dialogs = new DialogManager(DialogManager.Scenes.Intro,DialogManager.Places.ThouhtsAfterTakeBall ,false, () => SceneManager.LoadScene(1), 2);
            dialogs.OpenDialog();
            new Inventory().AddItem<BallItem>();
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _animation = GetComponent<Animator>();
    }

    private IEnumerator Move()
    {
        while(Vector2.Distance(transform.position,stopPoint) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, stopPoint, Speed * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
        AnimStop();
        yield break;
    }

    public void AnimStop()
    {
        _animation.SetInteger("mn", 2);
    }
}
