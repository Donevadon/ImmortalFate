using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipItem : MonoBehaviour, IItemTarget
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/tip");

    public void ClickHandler()
    {
        switch (target.Item)
        {
            case PliersItem tip:
                inventory.RemoveItem<TipItem>();
                inventory.RemoveItem<PliersItem>();
                inventory.AddItem<PliersWithTipItem>();
                break;
            default:
                target.Item = this;
                break;
        }

    }
}
