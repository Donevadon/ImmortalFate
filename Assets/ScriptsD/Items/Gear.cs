using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gear : MonoBehaviour,IPointerDownHandler
{
    public Meud meud;

    public void OnPointerDown(PointerEventData eventData)
    {
        Take();
    }

    private void OnMouseDown()
    {
        Take();
    }

    private void Take()
    {
        switch (meud)
        {
            case Meud.Big:
                new Inventory().AddItem<BigGearItem>();
                break;
            case Meud.Cuibheasach:
                new Inventory().AddItem<CuibheasachGearItem>();
                break;
            case Meud.Little:
                new Inventory().AddItem<LittleGearItem>();
                break;
        }
        Destroy(gameObject);
    }
}
