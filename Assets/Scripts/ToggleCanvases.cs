using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvases : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCanvas;
    [SerializeField]
    private GameObject _avatarCanvas;
    [SerializeField]
    private GameObject _coinCanvas;



    public void ToChangeAvatar()
    {
        _avatarCanvas.SetActive(true);
        _mainCanvas.SetActive(false);
    }

    public void ConfirmAvatar()
    {
        ChangeAvatar._Instance.SaveAvatar();
        _mainCanvas.SetActive(true);
        _avatarCanvas.SetActive(false);
    }

    public void ToChangeCoins()
    {
        _coinCanvas.SetActive(true);
        _mainCanvas.SetActive(false);
    }

    public void ConfirmCoins()
    {
        _mainCanvas.SetActive(true);
        _coinCanvas.SetActive(false);
    }

}
