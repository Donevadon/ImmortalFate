using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutItem : MonoBehaviour, IItemTarget
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/nut");

    public void ClickHandler()
    {
        switch (target.Item)
        {
            case BoltItem nut:
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
