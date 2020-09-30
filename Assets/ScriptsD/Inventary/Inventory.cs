using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
/// <summary>
/// Добавляет объекты и предоставляет к ним доступ
/// </summary>
public class Inventory : MonoBehaviour
{
    private static Transform conteiner;
    private static AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/AddItem");
        conteiner = transform;
        DontDestroyOnLoad(transform.parent);
    }

    /// <summary>
    /// Добавить предмет инвентарь
    /// </summary>
    /// <param name="item"></param>
    public void AddItem<T>() where T : IItemInventory
    {
        _audio.Play();
        ICellInventory cell = (ICellInventory)Resources.Load($"Prefabs/{typeof(CellInventory).Name}",typeof(ICellInventory));
        cell = Instantiate(cell.GameObject, conteiner).GetComponent<ICellInventory>();
        cell.Fill<T>();
    }
    /// <summary>
    /// Удалить предмет из инвентаря
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem<T>() where T : IItemInventory
    {
        for(int i = 0; i < conteiner.transform.childCount; i++)
        {
            if (conteiner.transform.GetChild(i).GetComponent<T>() == null) continue;
            Destroy(conteiner.transform.GetChild(i).gameObject);
            break;
        }
    }

    public bool FindObject<T>() where T : IItemInventory
    {
        for (int i = 0; i < conteiner.transform.childCount; i++)
        {
            if (conteiner.transform.GetChild(i).GetComponent<T>() != null) return true;
        }
        return false;

    }

    public void RemoveItem(IGears Item)
    {
        for (int i = 0; i < conteiner.transform.childCount; i++)
        {
            if (conteiner.transform.GetChild(i).GetComponent<IGears>()?.Meud != Item.Meud) continue;
            Destroy(conteiner.transform.GetChild(i).gameObject);
            break;
        }
    }

}
