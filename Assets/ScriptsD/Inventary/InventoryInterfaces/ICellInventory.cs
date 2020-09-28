using UnityEngine;

/// <summary>
/// Ячейка используемая в инвентаре
/// </summary>
public interface ICellInventory
{
    /// <summary>
    /// Заполнить ячейку предметов инвентаря
    /// </summary>
    /// <param name="typeObj"></param>
    void Fill<T>() where T : IItemInventory;
    /// <summary>
    /// Объект ячейки в инвентаре
    /// </summary>
    GameObject GameObject { get; }
    /// <summary>
    /// Предмет находящйся в ячейке
    /// </summary>
    IItemInventory Item { get; }
}
