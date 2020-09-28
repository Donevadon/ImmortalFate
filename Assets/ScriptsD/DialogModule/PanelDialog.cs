using System;
using System.Collections;
using UnityEngine;
public class PanelDialog : MonoBehaviour,IDialogPanel
{
    private static GameObject panel;
    private IShowName _name;
    private IShowText _text;
    private event Action dialogFinished;
    public delegate void SkipDelegate(bool skip);
    public static event SkipDelegate Skiped;
    public PanelDialog(string name, string text)
    {
        _name = new NamePane(name);
        _text = new SpeakerPanel(text);
    }

    public PanelDialog(string name, string text, Action finisherHandler)
    {
        _name = new NamePane(name);
        _text = new SpeakerPanel(text);
        dialogFinished += finisherHandler;
    }

    private void Update()
    {
        if (Input.anyKeyDown) Skiped?.Invoke(true);
    }

    public IEnumerator ShowDialog()
    {
        panel.SetActive(true);
        _name.ShowName();
        Skiped = new SkipDelegate(_text.Skip);
        yield return _text.ShowText(0.05f,0.5f);
        panel.SetActive(false);
        InvokeEventFinished();
        yield break;
    }

    private void Awake()
    {
        panel = gameObject;
        panel.SetActive(false);
    }

    private void InvokeEventFinished() 
    {
        dialogFinished?.Invoke();
    }
}
