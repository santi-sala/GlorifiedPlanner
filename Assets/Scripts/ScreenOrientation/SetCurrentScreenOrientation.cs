using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentScreenOrientation : MonoBehaviour
{
    [SerializeField]
    private bool _ScreenOrientationSetToHorizontal;

    private void Awake()
    {
        if (_ScreenOrientationSetToHorizontal)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
