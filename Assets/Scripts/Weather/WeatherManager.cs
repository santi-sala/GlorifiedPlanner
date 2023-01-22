using UnityEngine;
using System.Xml;
using TMPro;
using System;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService network;

    [SerializeField]
    private TMP_Text _currentTemperature;

    [SerializeField]
    private SO_WeatherParameters _weatherValues;

    
    public void Startup(NetworkService service)
    {
        network = service;
        StartCoroutine(network.GetWeatherXML(OnXMLDataLoaded));

        status = ManagerStatus.Initializing;
    }
    public void OnXMLDataLoaded(string data)
    {
        //Creating an empty xml documeny, put the data on the created document
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode nodeTemperature = root.SelectSingleNode("temperature");
        string temperatureValue = nodeTemperature.Attributes["value"].Value;
        double temperatureValueInt = Convert.ToDouble(temperatureValue);
        temperatureValueInt = Math.Round(temperatureValueInt, 1);

        //XmlNode nodeFeelsLike = root.SelectSingleNode("feels_like");
        //string feelsLikeValue = nodeFeelsLike.Attributes["value"].Value;
        //double feelsLikeValueInt = Convert.ToDouble(feelsLikeValue);
        //feelsLikeValueInt = Math.Round(feelsLikeValueInt, 1);
        //Debug.Log($"Feels like Value: {feelsLikeValue}");

        //Debug.Log($"Temperature Value: {temperatureValue}"); 
        //Debug.Log($"Temperature Value: {temperatureValueInt}");


        _currentTemperature.text = temperatureValueInt + "°C";
        _weatherValues.Temperature = temperatureValueInt;

        status = ManagerStatus.Started;
        
    }

    private void AssignWeatherParams(double temperature)
    {
        _weatherValues.Temperature = temperature;

    }
}

