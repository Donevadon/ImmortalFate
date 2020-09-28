using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuibheasachGearItem : MonoBehaviour, IItemTarget, IGears
{
    private ITargetItem target = new TargetItem();
    public Meud meud = Meud.Cuibheasach;
    public GameObject GameObject => gameObject;

    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Puzzle/Gears/Cuibheasach");

    public Meud Meud => meud;

    public void ClickHandler()
    {
        target.Item = this;
    }

}
