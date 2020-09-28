using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class NamePane : MonoBehaviour,IShowName
{
    private static Text _text;
    private string _name;

    /// <summary>
    /// Запись имени для дальнейшего отображения
    /// </summary>
    /// <param name="name"></param>
    public NamePane(string name)
    {
        _name = name;
    }

    public void ShowName()
    {
        _text.text = _name;
    }
    private void Awake()
    {
        _text = GetComponent<Text>();
    }
}
