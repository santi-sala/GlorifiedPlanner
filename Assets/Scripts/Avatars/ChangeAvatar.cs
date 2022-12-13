using System.Collections.Generic;
using UnityEngine;

public class ChangeAvatar : MonoBehaviour
{
    public static ChangeAvatar _Instance { get { return instance; } }
    private static ChangeAvatar instance;

    [SerializeField] 
    private Avatars _avatars;
    [SerializeField]
    private string[] _labels;
    [SerializeField]
    private SO_Avatar _currentAvatar;

    private int _id;
    private List<string> _mlabels;
    

    private void Awake()
    {
        instance = this;
        _mlabels = new List<string>();
        _mlabels.AddRange(_labels);
        _id = _currentAvatar.AvatarID;

        foreach (var item in _avatars.SpriteResolver)
        {
            item.SetCategoryAndLabel(item.GetCategory(), _mlabels[_id]);
        }
    }

    public void RightAvatar()
    {
        _id++;
        _id %= _mlabels.Count;

        foreach (var item in _avatars.SpriteResolver)
        {
            item.SetCategoryAndLabel(item.GetCategory(), _mlabels[_id]);
        }
        //Debug.Log("Current ID is: " + _id);

    }

    public void LeftAvatar()
    {
        _id--;
        if (_id < 0)
        {
            _id = _mlabels.Count - 1;
        }

        foreach (var item in _avatars.SpriteResolver)
        {
            item.SetCategoryAndLabel(item.GetCategory(), _mlabels[_id]);
        }
    }

    public void SaveAvatar()
    {
        _currentAvatar.AvatarID = _id;
        _currentAvatar.AvatarLabel = _mlabels[_id];
        _currentAvatar.AvatarThumbnailLabel = _mlabels[_id];
    }


}
