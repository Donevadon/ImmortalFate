using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<RodItem>();
        Destroy(gameObject);
    }
}
