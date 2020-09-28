using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliersItem : MonoBehaviour, IItemTarget
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/pliers");

    public void ClickHandler()
    {
        switch (target.Item)
        {
            case TipItem tip:
                inventory.RemoveItem<TipItem>();
                inventory.RemoveItem<PliersItem>();
                inventory.AddItem<PliersWithTipItem>();
                break;
            case RodItem rod:
                inventory.RemoveItem<RodItem>();
                inventory.AddItem<RodAfterPliers>();
                break;
            default:
                target.Item = this;
                break;
        }

    }
}
