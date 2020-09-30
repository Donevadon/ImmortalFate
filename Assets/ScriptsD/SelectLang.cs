using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLang : MonoBehaviour
{
    public Localization.Language language;

    public void Select()
    {
        Localization.language = language;
        SceneManager.LoadScene("Intro");
    }
}
