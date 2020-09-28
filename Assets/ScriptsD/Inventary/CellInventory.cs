using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Ячейка инвентаря
/// </summary>
public class CellInventory : MonoBehaviour, ICellInventory,IPointerClickHandler
{
    public IItemInventory Item { get; private set; }
    public GameObject GameObject => gameObject;

    private CellInventory() { }
    public void Fill<T>() where T : IItemInventory
    {
        Item = gameObject.AddComponent(typeof(T)).GetComponent<IItemInventory>();
        GetComponent<Image>().sprite = Item.GetCellSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Item.ClickHandler();
    }
}
