using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : MonoBehaviour,IItemInventory
{
    public Sprite GetCellSprite => Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/Items/ItemsInventory/book");

    public void ClickHandler()
    {
        
    }
}
