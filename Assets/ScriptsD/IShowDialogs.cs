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
}
