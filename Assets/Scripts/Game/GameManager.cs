using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region GameManager Variables
    private int _score;

    //UI references
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _LivesText;

    [Header("Game Menus")]
    [SerializeField] private GameObject _GameOverScreen;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Methods used by other scripts

    /// <summary>
    /// Below two scripts handling the score display
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points)
    {
        _score += points;
        _scoreText.text = "SCORE: " + _score.ToString();
    }

    public void UpdateLives(int lives)
    {
        _LivesText.text = "LIVES: " + lives.ToString();
    }

    public void GameOver()
    {
        _GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }


    #endregion
}
