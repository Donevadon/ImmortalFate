using Assets.DialogModule.DataBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour,ILocalize
{
    public static Language language = Language.Rus;

    Language ILocalize.language => language;
}
