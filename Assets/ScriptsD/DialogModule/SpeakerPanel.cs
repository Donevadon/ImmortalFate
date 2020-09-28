using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerPanel : MonoBehaviour,IShowText
{
    private static Text _textOut;
    private string _text;
    private bool skip;

    /// <summary>
    /// Запись текста для дальнейшего отображения
    /// </summary>
    /// <param name="text"></param>
    public SpeakerPanel(string text)
    {
        _text = text;
    }

    public IEnumerator ShowText(float printingSpeed, float pauseTime)
    {
        yield return new WaitForEndOfFrame();
        _textOut.text = "";
        skip = false;
        foreach(var c in _text)
        {
            if (skip)
            {
                _textOut.text = _text;
                break;
            }
            _textOut.text += c;
            yield return new WaitForSeconds(printingSpeed);
        }
        yield return new WaitForSeconds(pauseTime);
    }

    public void Skip(bool skip)
    {
        this.skip = skip;
    }

    private void Awake()
    {
        _textOut = GetComponent<Text>();
    }
}
