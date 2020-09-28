using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pliers : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<PliersItem>();
        Destroy(gameObject);
    }
}
