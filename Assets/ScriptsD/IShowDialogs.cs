using System;
using System.Collections;
/// <summary>
/// Отображение диалогов 
/// </summary>
public interface IShowDialogs
{
    /// <summary>
    /// Запустить отображение диалогов с привязкой к объекту на котором запускается
    /// </summary>
    /// <returns></returns>
    IEnumerator OpenDialogCoroutine();
    /// <summary>
    /// Запустить отображение диалогов без привязки с использованием объекта speaker
    /// </summary>
    void OpenDialog();
    /// <summary>
    /// Событие блокировки и разблокировки во время показа диалога 
    /// </summary>
    event Action<bool> Locked;
    /// <summary>
    /// Доступ к отображению диалогов в момент обращения
    /// </summary>
    bool Lock { get; }
}