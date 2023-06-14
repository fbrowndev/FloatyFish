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
    void AddPoints(int points)
    {
        _score += points;
        _scoreText.text = "Score: " + _score.ToString();
    }


    #endregion
}
