using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float FirstTimePause;
    public float SecondTimePause;
    public bool[] moveLocks = new bool[3];

    public GameObject Door;
    void Start()
    {
        StartCoroutine(DoWalk());
    }

    void Update()
    {
        
    }

    IEnumerator DoWalk()
    {
        IShowDialogs dialog1 = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.EdWalkUpAriFirst,moveLocks[0]);
        yield return StartCoroutine(dialog1.OpenDialogCoroutine());
        yield return new WaitForSeconds(FirstTimePause);
        IShowDialogs dialog2 = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.EdWalkUpAriSecond,moveLocks[1]);
        yield return StartCoroutine(dialog2.OpenDialogCoroutine());
        yield return new WaitForSeconds(SecondTimePause);
        IShowDialogs dialog3 = new DialogManager(DialogManager.Scenes.SecondDayStreetEvening, DialogManager.Places.EdWalkUpAriThird,moveLocks[2],() => Door.SetActive(true),16);
        yield return StartCoroutine(dialog3.OpenDialogCoroutine());

    }
}
