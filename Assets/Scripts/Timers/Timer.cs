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
    private GameObject  _continueNextTask;
    [SerializeField]
    private Sprite[] _playSprites;
    
    [SerializeField]
    private TimerType _timerType;

    [SerializeField]
    private GameObject[] _panels;
    [SerializeField]
    private TMP_Text _initialCountdown;


    private int _initialTimer = 3;
    private int _taskTimer;
    private int _remainingTime;

    
    private ToothBrushAnim _setToothBrushAnimation;

    public bool FinnishIt;

    private bool _pause = false;

    private void Start()
    {
        //FinnishIt = false;
        
        //_setToothBrushAnimation = new ToothBrushAnim();
        _panels[2].SetActive(false);
        CheckTaskType(_timerType);
        _continueNextTask.SetActive(false);
        StartTimer(_taskTimer);
    }

    private void StartTimer(int seconds)
    {
        _panels[2].SetActive(true);
        _remainingTime = seconds;
        FinnishIt = false;
        StartCoroutine(InitialTimer(_initialTimer));
        
    }

    private IEnumerator InitialTimer(int seconds)
    {
        _panels[1].SetActive(true);
        int secondsLeft = seconds;
        while (secondsLeft >= 0)
        {
            
            _initialCountdown.text = $"{secondsLeft}";
            _timerFill.fillAmount = Mathf.InverseLerp(0, seconds, secondsLeft);
            secondsLeft--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd(true, "Go!!", _timerType);

        yield return new WaitForSeconds(2f);

        _panels[1].SetActive(false);

        if (_timerType == TimerType.Brush)
        {
            _setToothBrushAnimation.StartBrushing();
        }

        StartCoroutine(UpdateTimer(_taskTimer));
    }

    private IEnumerator UpdateTimer(int seconds)
    {
        while(_remainingTime >= 0)
        {
            if (FinnishIt)
            {
                _countdown.text = ($"{(seconds - _remainingTime) / 60:00} : { (seconds - _remainingTime) % 60:00}");
                //_countdown.text = $"{_remainingTime / 60:00} : {_remainingTime % 60:00}";

                break;                
            }
            else
            {
                if (!_pause)
                {
                    _countdown.text = $"{_remainingTime / 60:00} : {_remainingTime % 60:00}";
                    _timerFill.fillAmount = Mathf.InverseLerp(0, seconds, _remainingTime);
                    _remainingTime--;

                    //HERE!!!
                    if (_remainingTime == 0)
                    {
                        _countdown.text = $"{seconds / 60:00} : {seconds % 60:00}";
                    }
                    yield return new WaitForSeconds(1f);

                    
                }
                yield return null;
            }
        }
        OnEnd(false, "Finish!!", _timerType);
        FinnishIt = false;
    }

    private void OnEnd(bool placeToDisplay, string message, TimerType taskType)
    {
        if (placeToDisplay)
        {
            _initialCountdown.text = message;
        }
        else
        {
            _initialCountdown.text = message;
            Debug.Log(taskType.ToString());
            //_countdown.text = message;

            if (_timerType == TimerType.Brush)
            {
                _setToothBrushAnimation.StopBrushing();
            }

            _continueNextTask.SetActive(true);
            _panels[2].SetActive(false);
            _panels[1].SetActive(true);
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

    private void CheckTaskType(TimerType task)
    {
        switch (task)
        {
            case TimerType.Brush:
                _taskTimer = _timers.BrushingTeeth;
                break;
            case TimerType.Breakfast:
                _taskTimer = _timers.Breakfast;
                break;
            case TimerType.Clothes:
                _taskTimer = _timers.ChangeCLothes;
                break;
            case TimerType.TESTING:
                _taskTimer = _timers.TESTING;
                break;
            
        }
    }


}
