using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BallItem : MonoBehaviour, IItemInventory
{
    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Items/ItemsInventory/{GetType().Name}");

    public void ClickHandler()
    {
        IShowDialogs dialog = new DialogManager(DialogManager.Scenes.FirstDayStreetMorning, DialogManager.Places.ClickOnBall,false);
        StartCoroutine(dialog.OpenDialogCoroutine());
    }
}
