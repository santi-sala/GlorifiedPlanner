using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{

    CurrentTime _sup;

    private void Start()
    {
        _sup = GetComponent<CurrentTime>();
    }
    public void DropdownLanguage(int index)
    {
        switch (index)
        {
            case 0:
                ChangeLocale(0);
                break;
            case 1:
                ChangeLocale(1);
                break;
            case 2:
                ChangeLocale(2);
                break;
        }
    }


    public void ChangeLocale(int localeId)
    {
        StartCoroutine(SetLocale(localeId));
    }

    IEnumerator SetLocale(int localeID)
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        
        _sup.LocalizeDay(LocalizationSettings.SelectedLocale);
    }
}
