using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO_Timers", menuName = "ScriptableObjects/Timers")]
public class SO_Timers : ScriptableObject
{
    [SerializeField]
    public int BrushingTeeth =  2 * 60;
    [SerializeField]
    public int Breakfast = 20 * 60;
    [SerializeField]
    public int ChangeCLothes = 15 * 60;
    
}
