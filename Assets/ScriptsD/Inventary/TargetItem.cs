using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour,ITargetItem
{
    private static IItemTarget item;
    public IItemTarget Item 
    {
        get
        {
            return item;
        } 
        set 
        {
            RemoveTarget();
            item = value;
            UpdateTarget();
        } 
    }

    private void UpdateTarget()
    {
        item.GameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void RemoveTarget()
    {
        try
        {
            item?.GameObject?.transform.GetChild(0).gameObject.SetActive(false);
        }
        catch
        {
            item = null;
        }
    }

    public void ZeroingTarget()
    {
        item = null;
    }
}
