using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltWithNutItem : MonoBehaviour,IItemTarget,IHex
{
    private ITargetItem target = new TargetItem();
    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/bolt with nut");

    public void ClickHandler()
    {
        target.Item = this;
    }
}
