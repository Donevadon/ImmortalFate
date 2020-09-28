using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IButton 
{
    ButtonList Button { get; }
    GameObject GameObject { get; }
    event ClickPanelButton ClickedButton;
}
public delegate void ClickPanelButton(IButton button);
public enum ButtonList
{
    Heart = 1,
    BirdСage,
    QuestionMark,
    Monitor,
    Sun,
    Skull,
    Candy,
    Scythe,
    Bird,
    Bank = 0,
}

public class Panel : MonoBehaviour
{
    public GameObject error;
    public Image[] fields;
    private List<IButton> button;
    private Sprite nullSprite;
    private string correctCode = "091";
    private string enterCode;
    private bool work = true;
    public event Action Corrected;

    private void Start()
    {
        InitButton();
    }
    private void InitButton()
    {
        button = new List<IButton>();
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<IButton>() is null) continue;
            IButton _button = transform.GetChild(i).GetComponent<IButton>();
            _button.ClickedButton += EnterCode;
            button.Add(_button); 
        }
        nullSprite = fields[0].sprite;
    }

    private void Awake()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/PanelCode/panel");
    }

    private void EnterCode(IButton button)
    {
        if (!work) return;
        enterCode += (int)button.Button;
        fields[enterCode.Length - 1].sprite = Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/PanelCode/DisplayIcons/{(int)button.Button}");
        if (enterCode.Length == 3) CheckCode();
    }

    private void CheckCode()
    {
        if (correctCode == enterCode) Corrected();
        else StartCoroutine(Error());
    }

    private IEnumerator Error()
    {
        PlayerControl.MoveLock = true;
        work = false;
        ResetCode();
        error.SetActive(true);
        yield return new WaitForSeconds(2f);
        error.SetActive(false);
        work = true;
        PlayerControl.MoveLock = false;
        yield break;
    }



    private void ResetCode()
    {
        foreach (var field in fields)
        {
            field.sprite = nullSprite;
        }
        enterCode = "";
    }
}
