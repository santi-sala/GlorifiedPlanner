using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrushAnim : MonoBehaviour
{
    [SerializeField]
    private Animator _toothBrushAnimator;

    private void Start()
    {
        _toothBrushAnimator = GetComponent<Animator>(); ;
    }

    public void StartBrushing()
    {
        _toothBrushAnimator.SetBool("startBrushing", true);
    }

    public void StopBrushing()
    {
        _toothBrushAnimator.SetBool("startBrushing", false);
    }
}
