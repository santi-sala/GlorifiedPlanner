using System;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class CurrentTime : MonoBehaviour
{
    
    private ILocalesProvider _availableLocales;
    [SerializeField] 
    private TMP_Text _currentTime;
    [SerializeField]
    private TMP_Text _currentDay;
    private string _day;

    private void Start()
    {
        _availableLocales = LocalizationSettings.AvailableLocales;
        _day = DateTime.Now.ToLocalTime().ToString("dddd");
        LocalizeDay(LocalizationSettings.SelectedLocale);
    }

    private void Update()
    {
        _currentTime.text = DateTime.Now.ToLocalTime().ToString("HH:mm");
    }

    public void LocalizeDay(Locale currentLocal)
    {       
        if (currentLocal == _availableLocales.GetLocale("fi"))
        {
            //Debug.Log("Joo");
            switch (_day)
            {
                case "Monday":
                    _currentDay.text = "Maanantai";
                    break;
                case "Tuesday":
                    _currentDay.text = "Tiistai";
                    break;
                case "Wednesday":
                    _currentDay.text = "Keskiviikko";
                    break;
                case "Thursday":
                    _currentDay.text = "Torstai";
                    break;
                case "Friday":
                    _currentDay.text = "Perjantai";
                    break;
                case "Saturday":
                    _currentDay.text = "Lauantai";
                    break;
                case "Sunday":
                    _currentDay.text = "Sunnuntai";
                    break;                
            }

        }
        else if (currentLocal == _availableLocales.GetLocale("es"))
        {
            //Debug.Log("Sii!!");
            switch (_day)
            {
                case "Monday":
                    _currentDay.text = "Lunes";
                    break;
                case "Tuesday":
                    _currentDay.text = "Tiistai";
                    break;
                case "Wednesday":
                    _currentDay.text = "Miercoles";
                    break;
                case "Thursday":
                    _currentDay.text = "Jueves";
                    break;
                case "Friday":
                    _currentDay.text = "Viernes";
                    break;
                case "Saturday":
                    _currentDay.text = "Sabado";
                    break;
                case "Sunday":
                    _currentDay.text = "Domingo";
                    break;
            }
        }
        else
        {
            //Debug.Log("Yes!!");
            switch (_day)
            {
                case "Monday":
                    _currentDay.text = "Monday";
                    break;
                case "Tuesday":
                    _currentDay.text = "Tuesday";
                    break;
                case "Wednesday":
                    _currentDay.text = "Wednesday";
                    break;
                case "Thursday":
                    _currentDay.text = "Thursday";
                    break;
                case "Friday":
                    _currentDay.text = "Friday";
                    break;
                case "Saturday":
                    _currentDay.text = "Saturday";
                    break;
                case "Sunday":
                    _currentDay.text = "Sunday";
                    break;
            }
        }
    }        
}
