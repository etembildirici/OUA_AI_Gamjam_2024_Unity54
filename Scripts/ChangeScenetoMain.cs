using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenetoMain : MonoBehaviour
{
    public void GoToSceneThree()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

