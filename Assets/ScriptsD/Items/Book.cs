using Assets.DialogModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private void OnMouseDown()
    {
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.SecondDayStreetMorning, DialogManager.Places.ThouhtsAfterTakeBookSecond, FindObjectOfType<ThinkAboutBook>(), 1);
        dialog.OpenDialog();
        new Inventory().AddItem<BookItem>();
        Destroy(gameObject);
    }
}
