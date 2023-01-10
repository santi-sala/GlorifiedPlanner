using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrushAnim : MonoBehaviour
{
    public Animator _toothBrushAnimator;

    public void StartBrushing()
    {
        _toothBrushAnimator.SetBool("startBrushing", true);
    }

    public void StopBrushing()
    {
        _toothBrushAnimator.SetBool("startBrushing", false);
    }
}
