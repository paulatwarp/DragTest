using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menus : MonoBehaviour
{
    public void exitgame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("SampleScene");
    }

}   
