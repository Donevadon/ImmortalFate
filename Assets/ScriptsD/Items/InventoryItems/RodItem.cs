using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodItem : MonoBehaviour, IItemTarget
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/rod");

    public void ClickHandler()
    {
        switch (target.Item)
        {
            case PliersItem tip:
                inventory.RemoveItem<RodItem>();
                inventory.AddItem<RodAfterPliers>();
                break;
            default:
                target.Item = this;
                break;
        }

    }
}
