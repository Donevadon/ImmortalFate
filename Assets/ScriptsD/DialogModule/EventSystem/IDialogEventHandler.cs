namespace Assets.DialogModule.EventSystem
{
    /// <summary>
    /// Обработчик события после окончания диалога
    /// </summary>
    public interface IDialogEventHandler
    {
        /// <summary>
        /// Обработать событие окончания диалога
        /// </summary>
        void FinishedHandler();
    }
}