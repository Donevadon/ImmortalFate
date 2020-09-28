using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPanel : MonoBehaviour, IButton,IPointerDownHandler
{
    public ButtonList button;
    public ButtonList Button => button;

    public GameObject GameObject => gameObject;

    public event ClickPanelButton ClickedButton;

    private void Awake()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>($"DB/Dropbox/Mortal Fate/PanelCode/{(int)button}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickedButton(this);
    }
}
