using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<NutItem>();
        Destroy(gameObject);
    }
}
