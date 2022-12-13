using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ChosenAvatar", menuName = "ScriptableObjects/ChosenAvatar")]
public class SO_Avatar : ScriptableObject
{
    public string AvatarLabel = "cook";
    public string AvatarThumbnailLabel = "cook";
    public int AvatarID = 0;
}
