using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<TipItem>();
        Destroy(gameObject);
    }
}
