using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnMouseDown()
    {
        new Inventory().AddItem<CoinItem>();
        Destroy(gameObject);
    }
}
