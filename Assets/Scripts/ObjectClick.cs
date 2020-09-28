using UnityEngine;

public class ObjectClick : MonoBehaviour
{    

    public TextControl control;
    public string[] tx = new string[1];
    public bool mous;
    public int number = 0;
    [SerializeField] private bool click = true;
    public int ItemID;

    
    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Mouse0) && mous && !control.invBool)
        {
            if (control.tap_tr && click) {
                control.txPan.SetActive(true);
                control.TextNum = 1;
                foreach (string i in tx) {
                    control.Mtexts[number] = i;
                    number++;
                }
                control.mn_txt.text = control.Mtexts[0];
                control.numbersTexts = tx.Length;
                click = false;
                if (ItemID != 0) {
                    if (PlayerPrefs.GetInt("SLot1") == 0) {
                        PlayerPrefs.SetInt("SLot1",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot2") == 0) {
                        PlayerPrefs.SetInt("SLot2",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot3") == 0) {
                        PlayerPrefs.SetInt("SLot3",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot4") == 0) {
                        PlayerPrefs.SetInt("SLot4",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot5") == 0) {
                        PlayerPrefs.SetInt("SLot5",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot6") == 0) {
                        PlayerPrefs.SetInt("SLot6",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot7") == 0) {
                        PlayerPrefs.SetInt("SLot7",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot8") == 0) {
                        PlayerPrefs.SetInt("SLot8",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot9") == 0) {
                        PlayerPrefs.SetInt("SLot9",ItemID);
                    } else if (PlayerPrefs.GetInt("SLot10") == 0) {
                        PlayerPrefs.SetInt("SLot10",ItemID);
                    } 
                }
                control.clicks++;
                control.tap_tr = false;
                Cursor.SetCursor(control.cursorTexture_interact,control.hotSpot,control.cursorMode);
            }

        }
  }
    //void OnMouseEnter()
    //{
    //    if (!control.invBool) {
    //        Cursor.SetCursor(control.cursorTexture_interact,control.hotSpot,control.cursorMode);
    //        control.mouseControl = false;
    //    }

    //    mous = true;
        
    //}
    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(control.cursorTexture,control.hotSpot,control.cursorMode);
    //    mous = false;
    //    Invoke("cn",0.05f);
    //}

    public void cn () {
        control.mouseControl = true;
    }

}
