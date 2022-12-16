using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class SelectProperClothes : MonoBehaviour
{
    [SerializeField]
    private SO_WeatherParameters _weatherValues;
    [SerializeField]
    private TMP_Text _displayCurrentTemperature;
    [SerializeField]
    private GameObject _parent;
    [SerializeField]
    private GameObject[] _hats;
    [SerializeField]
    private Sprite[] _rightWrong = new Sprite[2];
    [SerializeField]
    private GameObject _finalPanel;
    [SerializeField]
    private TMP_Text[] _answers;
    [SerializeField]
    private GameObject _continueBTN;

    private int _numberOfQuestions = 1;
    private int _correctAnswer = 0;
    private int _wrongAnswer = 0;
    private Timer _remainingTimer;
    private bool _FireJustOnce = true;

    [SerializeField]
    private List<Vector3> _imagePositions = new List<Vector3>();
    private List<Vector3> _newImagePositions = new List<Vector3>();
    private System.Random _random = new System.Random();

    private void Start()
    {
        _displayCurrentTemperature.text = Convert.ToString(_weatherValues.Temperature) + "°C";
        RandomisePosition();
        _remainingTimer = gameObject.GetComponent<Timer>();
        foreach (var text in _answers)
        {
            text.enabled = false;
        }
        _continueBTN.SetActive(false);
        _remainingTimer.FinnishIt = false;
    }

    private void Update()
    {
        if (_numberOfQuestions == 0)
        {
            //_remainingTimer.RemainingTime = 0;
            //StartCoroutine(_remainingTimer.UpdateTimer(5));
            if (_FireJustOnce)
            {
                //StopCoroutine(_remainingTimer._timerCoroutine);
                //StartCoroutine(_remainingTimer.UpdateTimer(3));
                //StopAllCoroutines();

                //This works!
                _remainingTimer.FinnishIt = true;
                _answers[0].text = "Correct answers: " + _correctAnswer;
                _answers[1].text = "Wrong answers: " + _wrongAnswer;

                foreach (var text in _answers)
                {
                    text.enabled = true;
                }
                _continueBTN.SetActive(true);
                _finalPanel.SetActive(true);
            }
               
            _FireJustOnce = false;
            //_remainingTimer.FinnishIt = false;

        }
    }

    public void CheckClothing(int buttonPressed)
    {
        if (buttonPressed == 0)
        {
            if (_weatherValues.Temperature >= 0 && _weatherValues.Temperature < 10)
            {
                AssignMark(true, buttonPressed);
            }
            else
            {
                AssignMark(false, buttonPressed);
            }
        }

        if (buttonPressed == 1)
        {
            if (_weatherValues.Temperature >= 10)
            {
                AssignMark(true, buttonPressed);
            }
            else
            {
                AssignMark(false, buttonPressed);
            }
        }

        if (buttonPressed == 2)
        {
            if (_weatherValues.Temperature < 0)
            {
                AssignMark(true, buttonPressed);
            }
            else
            {
                AssignMark(false, buttonPressed);
            }
        }

        if (buttonPressed > 2)
        {
            Debug.Log("Insert new button here!!!");
        }
    }

    private void AssignMark(bool correctness, int gameObjectIndex)
    {
        Transform hat = _hats[gameObjectIndex].gameObject.transform.GetChild(1);
        
        if (correctness)
        {
            hat.GetComponent<Image>().sprite = _rightWrong[0];
            _correctAnswer++;
            _numberOfQuestions--;
        }
        else
        {
            hat.GetComponent<Image>().sprite = _rightWrong[1];
            _wrongAnswer--;
        }

        hat.GetComponent<Image>().enabled = true;
    }

    [ContextMenu("Randomise Position")]
    public void RandomisePosition()
    {
        foreach (var vector in _imagePositions)
        {
            _newImagePositions.Add(vector);
        }
        int _randomNum;
        int currentIndex = 0;

        while (_newImagePositions.Count > 0)
        {
            _randomNum = _random.Next(_newImagePositions.Count);
            _hats[currentIndex].transform.localPosition =  _newImagePositions[_randomNum];
            _newImagePositions.Remove(_newImagePositions[_randomNum]);

            currentIndex++;
        }
    }

}
