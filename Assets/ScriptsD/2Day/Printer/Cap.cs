using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour, ICap
{
    public Printer printer;
    public void RemoveHolder()
    {
        if (transform.childCount == 1)
        {
            printer.StartHind();
            Destroy(gameObject); 
        }
    }
}
