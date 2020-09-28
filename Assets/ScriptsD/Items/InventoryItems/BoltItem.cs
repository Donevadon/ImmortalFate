using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltItem : MonoBehaviour,IItemTarget
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();
    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/bolt");

    public void ClickHandler()
    {
        switch (target.Item)
        {
            case NutItem nut:
                inventory.RemoveItem<BoltItem>();
                inventory.RemoveItem<NutItem>();
                inventory.AddItem<BoltWithNutItem>();
                break;
            default:
                target.Item = this;
                break;
        }
    }
}
