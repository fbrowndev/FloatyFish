using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Handling all methods for the main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    #region Main Menu Variables
    [Header("Menus")]
    [SerializeField] private GameObject mainMenuButtons;
    [SerializeField] private GameObject levelButtons;

    #endregion

    public void StartGame()
    {
        mainMenuButtons.SetActive(false);
        levelButtons.SetActive(true);
    }

    public void BackButton()
    {
        levelButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }


    public void StartLevel(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
