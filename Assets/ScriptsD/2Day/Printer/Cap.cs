using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour, ICap
{
    public Printer printer;
    public GameObject Gears;
    public void RemoveHolder()
    {
        if (transform.childCount == 1)
        {
            printer.StartHind();
            Gears.SetActive(true);
            Destroy(gameObject); 
        }
    }
}
