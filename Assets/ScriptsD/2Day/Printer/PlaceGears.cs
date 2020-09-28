using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceGears : MonoBehaviour, IPlaceGears,IPointerDownHandler
{
    public Printer printer;
    private ITargetItem target = new TargetItem();
    public GameObject[] objects;
    public IGears gear { get;private set; }

    [SerializeField]private Meud meud;
    public Meud Meud => meud;

    void UpdateGear(IGears gears)
    {
        gear = gears;
        switch (gears.Meud)
        {
            case Meud.Little:
                objects[0].SetActive(true);
                break;
            case Meud.Cuibheasach:
                objects[1].SetActive(true);
                break;
            case Meud.Big:
                objects[2].SetActive(true);
                break;

        }
        printer.UpdateGear();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gear is null)
        {
            switch (target.Item)
            {
                case IGears gears:
                    new Inventory().RemoveItem(gears);
                    UpdateGear(gears);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (gear.Meud)
            {
                case Meud.Little:
                    new Inventory().AddItem<LittleGearItem>();
                    break;
                case Meud.Cuibheasach:
                    new Inventory().AddItem<CuibheasachGearItem>();
                    break;
                case Meud.Big:
                    new Inventory().AddItem<BigGearItem>();
                    break;
            }
            foreach(var i in objects)
            {
                i.SetActive(false);
            }
            gear = null;
        }
    }
}
