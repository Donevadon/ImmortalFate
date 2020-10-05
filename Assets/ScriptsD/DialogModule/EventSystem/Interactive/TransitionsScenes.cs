using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.DialogModule.EventSystem.Interactive
{
    public class TransitionsScenes : MonoBehaviour, IDialogEventHandler
    {
        public string nameScene;
        public Using @using;
        public bool FinishedDialogs;
        public Image Display;
        public float speedDarken;
        public int timePause;
        private AudioSource _audio;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
            _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/OpenDoor");
        }

        public void OnMouseDown()
        {
            if (@using == Using.Click)
                StartCoroutine(Load());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (@using == Using.EnterTrigger) StartCoroutine(Load());
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (@using == Using.ExitTrigger) StartCoroutine(Load());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (@using == Using.Enter) StartCoroutine(Load());
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (@using == Using.Exit) StartCoroutine(Load());
        }

        public void FinishedHandler()
        {
            if (@using == Using.DialogEvent) StartCoroutine(Load());
        }

        private IEnumerator Load()
        {
            if ((FinishedDialogs && !new DialogManager().Lock) || !FinishedDialogs)
            {
                float value = 0;
                while (Display.color.a < 1)
                {
                    Display.color = new Color(0, 0, 0, value);
                    value += speedDarken;
                    yield return new WaitForSeconds(0);
                }
                _audio.Play();
                yield return new WaitForSeconds(timePause);
                SceneManager.LoadScene(nameScene);
                yield break;

            }
        }
    }
}