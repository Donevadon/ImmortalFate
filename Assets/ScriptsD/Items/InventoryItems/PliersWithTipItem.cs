using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliersWithTipItem : MonoBehaviour,IItemTarget,ICross
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/pliers with tip");

    public void ClickHandler()
    {
        target.Item = this;
    }
}
