using System.Collections;
/// <summary>
/// Отображение речи говорящего
/// </summary>
public interface IShowText
{
    /// <summary>
    /// Показать речь говорящего
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowText(float timeBetweenSymbol, float PauseTime);
    void Skip(bool skip);
}
