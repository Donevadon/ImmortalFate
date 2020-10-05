namespace Assets.DialogModule
{
    /// <summary>
    /// Загрузка диалогов из базы данных
    /// </summary>
    public interface ILoadDialogs
    {
        /// <summary>
        /// Загрузить диалоги
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        string[][] LoadDialogs(DialogManager.Scenes scene, DialogManager.Places place);
    }
}