using UnityEngine;
namespace Assets.DialogModule.EventSystem.Interactive
{
    public class InteractiveDialog : MonoBehaviour,IDialogEventHandler
    {
        [SerializeField] private int Frequency;
        [SerializeField] private int NumberCallEvent;
        [SerializeField] private string nameObjectHandler;
        [SerializeField] private Using _using;
        [SerializeField] private DialogManager.Scenes scene;
        [SerializeField] private DialogManager.Places place;
        [SerializeField] private bool FinishedDialogs;

        private IShowDialogs dialogs;
        private int scoreClick;
        private IDialogEventHandler eventHandler;

        private void Awake()
        {
            if (nameObjectHandler != "")
                eventHandler = GameObject.Find(nameObjectHandler).gameObject.GetComponent<IDialogEventHandler>();
            dialogs = new DialogManager(scene, place, eventHandler, NumberCallEvent);
        }

        private void Start()
        {
            if (_using == Using.Start) Launch();
        }

        private void OnMouseDown()
        {
            if (_using == Using.Click) Launch();
        }

        private void OnMouseEnter()
        {
            //TODO:Смена курсора при наведении на объект взаимодействия
        }

        private void OnMouseExit()
        {
            //TODO:Возврат курсора в стандарный вариант
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_using == Using.ExitTrigger) Launch();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_using == Using.Enter) Launch();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_using == Using.EnterTrigger) Launch();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (_using == Using.Exit) Launch();
        }
        private void Launch()
        {
            if (FinishedDialogs && !dialogs.Lock || !FinishedDialogs && (scoreClick < Frequency || Frequency == 0))
            {
                StartCoroutine(dialogs.OpenDialogCoroutine());
                scoreClick++;
            }
        }

        public void FinishedHandler()
        {
            throw new System.NotImplementedException();
        }
    }
}