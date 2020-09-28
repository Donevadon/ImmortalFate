using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobsDocumentsItem : MonoBehaviour,IItemInventory
{
    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Items/ItemsInventory/{GetType().Name}");

    public void ClickHandler()
    {
    }

}
