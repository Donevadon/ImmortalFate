using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour 
{   
    public Texture2D cursorTexture_interact;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    public Text mn_txt;
    [SerializeField] private Text name_txt;
    public GameObject txPan;
    public int clicks;
    public bool mouseControl;
    public bool tap_tr = true;
    public string[] Mtexts = new string[25];
    public int TextNum = 0;
    public int numbersTexts;
    public GameObject invent;
    public bool invBool;

    public GameObject noteBook;
    public bool noteBool;


    private void Start() {
        mn_txt.text = Mtexts[0];
    }

    public void Click_Pan () 
    {
        if (!mouseControl){
            if (TextNum < numbersTexts && Mtexts[0] != "" ) {
                txPan.SetActive(true);
                mn_txt.text = Mtexts[TextNum];
                TextNum ++;
            } else {
                mn_txt.text = "";
                tap_tr = true;
                txPan.SetActive(false);
            }
        }  
    }

    public void InvOpen () {
        invBool = !invBool;
        if (!invBool) {
            noteBook.SetActive(false);
        }
        invent.SetActive(invBool);
        
    }
    public void NoteOpen () {
        noteBool = !noteBool;
        noteBook.SetActive(noteBool);
        
    }
}
