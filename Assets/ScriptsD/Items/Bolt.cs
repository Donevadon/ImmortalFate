using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<BoltItem>();
        Destroy(gameObject);
    }
}
