using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

[System.Serializable]
public class Avatars
{
    [SerializeField]
    private SpriteResolver[] _resolvers;
    public SpriteResolver[] SpriteResolver { get => _resolvers; }

    
}
