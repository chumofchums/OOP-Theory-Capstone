using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;

    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}
