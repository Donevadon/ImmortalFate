using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, IItemTarget,IMinus
{
    private ITargetItem target = new TargetItem();
    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/coin");

    public GameObject GameObject => gameObject;

    public void ClickHandler()
    {
        target.Item = this;
    }
}
