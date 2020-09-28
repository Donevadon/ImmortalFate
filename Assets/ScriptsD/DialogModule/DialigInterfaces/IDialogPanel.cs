using System.Collections;
/// <summary>
/// Панель диалога с текстом
/// </summary>
public interface IDialogPanel
{
    /// <summary>
    /// Запустить отображение диалога
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowDialog();
}
