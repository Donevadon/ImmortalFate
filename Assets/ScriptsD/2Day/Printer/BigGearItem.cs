using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGearItem : MonoBehaviour, IItemTarget, IGears
{
    private ITargetItem target = new TargetItem();
    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/Big");

    public Meud Meud => Meud.Big;

    public void ClickHandler()
    {
        target.Item = this;
    }

}
