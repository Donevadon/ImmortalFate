using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventar : MonoBehaviour
{

    [SerializeField] private Sprite slot;
    [SerializeField] private Sprite ball;


    [SerializeField] private Image slotOne;
    [SerializeField] private Image slotTwo;
    [SerializeField] private Image slotThree;
    [SerializeField] private Image slotFour;
    [SerializeField] private Image slotFive;
    [SerializeField] private Image slotSix;
    [SerializeField] private Image slotSeven;
    [SerializeField] private Image slotEight;
    [SerializeField] private Image slotNine;
    [SerializeField] private Image slotTen;


    
    [SerializeField] private TextControl TxCon;

    void Update()
    {
        if (PlayerPrefs.GetInt("SLot1") == 0) {
            slotOne.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot1") == 1) {
            slotOne.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot2") == 0) {
            slotTwo.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot2") == 1) {
            slotTwo.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot3") == 0) {
            slotThree.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot3") == 1) {
            slotThree.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot4") == 0) {
            slotFour.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot4") == 1) {
            slotFour.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot5") == 0) {
            slotFive.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot5") == 1) {
            slotFive.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot6") == 0) {
            slotSix.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot6") == 1) {
            slotSix.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot7") == 0) {
            slotSeven.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot7") == 1) {
            slotSeven.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot8") == 0) {
            slotEight.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot8") == 1) {
            slotEight.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot9") == 0) {
            slotNine.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot9") == 1) {
            slotNine.sprite = ball;
        }

        if (PlayerPrefs.GetInt("SLot10") == 0) {
            slotTen.sprite = slot;
        } else if (PlayerPrefs.GetInt("SLot10") == 1) {
            slotTen.sprite = ball;
        }
    }


    public void One () {
        if (PlayerPrefs.GetInt("SLot1") == 1 && TxCon.tap_tr) {
            TxCon.numbersTexts = 1;
            TxCon.TextNum = 0;
            TxCon.Mtexts[0] = "Привет, малыш";
            TxCon.invBool = false;
            TxCon.noteBook.SetActive(false);
            TxCon.invent.SetActive(false);
            TxCon.tap_tr = false;
            TxCon.Click_Pan();
        }
    } 
    public void Two () {
        
    } 
    public void Three () {
        
    } 
    public void Four () {
        
    } 
    public void Five () {
        
    } 
    public void Six () {
        
    } 
    public void Seven () {
        
    } 
    public void Eight () {
        
    } 
    public void Night () {
        
    } 
    public void Ten () {
        
    } 

}

