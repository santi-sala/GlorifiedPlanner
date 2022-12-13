using System;
using TMPro;
using UnityEngine;

public class ManageCoins : MonoBehaviour
{
    [SerializeField]
    private SO_Coins _currentCoins;
    [SerializeField]
    private TMP_Text[] _displayCoinsMain = new TMP_Text[2];
    [SerializeField]
    private TMP_InputField _resetInput;


    private int _numberOfCoins;
    private string coins = "0";

    private void Start()
    {
        foreach (var display in _displayCoinsMain)
        {
            display.text = Convert.ToString(_currentCoins.Coins);
        }
    }

    public void AddCoins()
    {
        _numberOfCoins = Convert.ToInt32(coins);
        _currentCoins.Coins += _numberOfCoins;

        foreach (var display in _displayCoinsMain)
        {
            display.text = Convert.ToString(_currentCoins.Coins);
        }

        _resetInput.text = "";

        //_displayCoinsMain.text = Convert.ToString(_currentCoins.Coins);
    }

    public void RemoveCoins() 
    {
        _numberOfCoins = Convert.ToInt32(coins);
        _currentCoins.Coins -= _numberOfCoins;

        foreach (var display in _displayCoinsMain)
        {
            display.text = Convert.ToString(_currentCoins.Coins);
        }

        _resetInput.text = "";

        //_displayCoinsMain.text = Convert.ToString(_currentCoins.Coins);
    }

    public void GetCoinInput(string coin)
    {
        coins = coin;
       
    }

}
