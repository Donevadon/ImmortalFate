using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGearItem : MonoBehaviour, IItemTarget,IGears
{
    private ITargetItem target = new TargetItem();
    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/Little");

    public Meud Meud => Meud.Little;

    public void ClickHandler()
    {
        target.Item = this;
    }
}
