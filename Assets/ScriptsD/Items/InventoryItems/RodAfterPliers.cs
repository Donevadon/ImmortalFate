using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodAfterPliers : MonoBehaviour, IItemTarget,ITriangular
{
    private ITargetItem target = new TargetItem();
    private Inventory inventory = new Inventory();

    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/rod after pliers");

    public void ClickHandler()
    {
        target.Item = this;
    }
}
