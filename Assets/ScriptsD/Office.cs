using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    public enum Time
    {
        Morning,
        Evening
    }
    public enum Floor
    {
        First,
        Second,
    }
    public Time time;
    public Floor floor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (time == Time.Morning && floor == Floor.First) collision.transform.position = new Vector3(115f, 0);
        else if (time == Time.Morning && floor == Floor.Second) collision.transform.position = new Vector3(115f, 33);
    }
}
