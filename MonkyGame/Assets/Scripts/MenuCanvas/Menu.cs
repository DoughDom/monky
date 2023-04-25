using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject HowToMenu;

    void Start()
    {
        HowToMenu.SetActive(false);
    }
    
    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Test Course");
    }

    public void HowTo()
    {
        Debug.Log("How To Play");
        MainMenu.SetActive(false);
        HowToMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back()
    {
        Debug.Log("Back");
        MainMenu.SetActive(true);
        HowToMenu.SetActive(false);
    }
}
