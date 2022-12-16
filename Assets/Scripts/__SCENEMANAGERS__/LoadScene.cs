using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LaodScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("sup");
    }
}
