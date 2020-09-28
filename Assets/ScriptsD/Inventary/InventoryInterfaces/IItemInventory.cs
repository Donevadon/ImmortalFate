using UnityEngine;
/// <summary>
/// Предмет который можно положить в инвентарь
/// </summary>
public interface IItemInventory
{
    /// <summary>
    /// Обработчик события нажатия на ячейку в инвентаре
    /// </summary>
    void ClickHandler();
    /// <summary>
    /// Спрайт отображающий предмет в инвентаре
    /// </summary>
    Sprite GetCellSprite { get; }
}

public interface IItemTarget : IItemInventory
{
    GameObject GameObject { get; }
}
