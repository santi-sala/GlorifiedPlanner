using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image _timerFill;
    [SerializeField]
    private TMP_Text _countdown;
    [SerializeField]
    private SO_Timers _timers;
    [SerializeField]
    private Image _pausePlay;
    [SerializeField]
    private Sprite[] _playSprites;
    [SerializeField]
    private string _taskType;
    [SerializeField]
    private GameObject[] _panels;
    [SerializeField]
    private TMP_Text _initialCountdown;

    private int _initialTimer = 3;
    private int _taskTimer;
    private int _remainingTime;
    private bool _pause = false;

    private void Start()
    {
        CheckTaskType(_taskType);
        StartTimer(_taskTimer);
    }

    private void StartTimer(int seconds)
    {
        _remainingTime = seconds;
        StartCoroutine(InitialTimer(_initialTimer));
        
    }

    private IEnumerator InitialTimer(int seconds)
    {
        int secondsLeft = seconds;
        while (secondsLeft >= 0)
        {           
            _initialCountdown.text = $"{secondsLeft}";
            _timerFill.fillAmount = Mathf.InverseLerp(0, seconds, secondsLeft);
            secondsLeft--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd(true, "Go!!");

        yield return new WaitForSeconds(2f);

        _panels[1].SetActive(false);

        StartCoroutine(UpdateTimer(_taskTimer));
    }

    private IEnumerator UpdateTimer(int seconds)
    {
        while(_remainingTime >= 0)
        {
            if (!_pause)
            {
                _countdown.text = $"{_remainingTime / 60:00} : {_remainingTime % 60:00}";
                _timerFill.fillAmount = Mathf.InverseLerp(0, seconds, _remainingTime);
                _remainingTime--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd(false, "Finish!!");
    }

    private void OnEnd(bool placeToDisplay, string message)
    {
        if (placeToDisplay)
        {
            _initialCountdown.text = message;
        }
        else
        {
            _countdown.text = message;
        }
    }

    public void PausePlay()
    {
        _pause = !_pause;

        if(_pause)
        {
            _pausePlay.sprite = _playSprites[0];
            _panels[0].SetActive(true);
        } 
        else
        {
            _pausePlay.sprite = _playSprites[1];
            _panels[0].SetActive(false);
        }

    }

    private void CheckTaskType(string task)
    {
        switch (task)
        {
            case "Brush":
                _taskTimer = _timers.BrushingTeeth;
                break;
            case "Breakfast":
                _taskTimer = _timers.Breakfast;
                break;
            case "Clothes":
                _taskTimer = _timers.ChangeCLothes;
                break;
            
        }
    }
}
