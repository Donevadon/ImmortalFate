using Assets.DialogModule.DataBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLang : MonoBehaviour
{
    public Language language;

    public void Select()
    {
        Localization.language = language;
        SceneManager.LoadScene("Intro");
    }
}
