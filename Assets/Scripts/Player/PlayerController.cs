using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player variables
    [Header("Player Settings")]
    [SerializeField] private int _points = 5;
    [SerializeField] private int _playerLives = 3;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xBounds = 2;


    [Header("Abilities")]
    [SerializeField] Color32[] _playerColors;

    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    private string _currentColor;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _playerLives = 3;

        _spriteRenderer = GetComponent<SpriteRenderer>(); //Gaining access to the sprite render to change color
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //access the game manager script by first finding game object

        ColorSwitch(); //Switching color at the start of the game


        //Null checks below
        if(_spriteRenderer == null)
        {
            Debug.LogError("_spriteRenderer is null!");
        }

        if( _gameManager == null)
        {
            Debug.LogError("_gameManager is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        GameOverCheck();
    }

    /// <summary>
    /// Checking for the loss of the game
    /// </summary>
    void GameOverCheck()
    {
        if(_playerLives < 1)
        {
            _gameManager.GameOver();
        }
    }

    #region Movement
    void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenWidth = Screen.width;

            // Check if the touch position is on the left half of the screen
            if (touch.position.x < screenWidth / 2f && transform.position.x > -_xBounds)
            {
                // Move the player to the left
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            // Check if the touch position is on the right half of the screen
            else if (touch.position.x >= screenWidth / 2f && transform.position.x < _xBounds)
            {
                // Move the player to the right
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }
    }

    #endregion

    #region Abilities
    void ColorSwitch()
    {
        int _randColor = Random.Range(0, _playerColors.Length);
        _spriteRenderer.material.color = _playerColors[_randColor];

        switch(_randColor)
        {
            case 0:
                _currentColor = "Red";
                break;
            case 1:
                _currentColor = "Blue";
                break;
            case 2:
                _currentColor = "Green";
                break;
            case 3:
                _currentColor = "Yellow";
                break;
            case 4:
                _currentColor = "Purple";
                break;
            default:
                Debug.LogError("No color choosen");
                break;
        }
    }

    #endregion

    #region Collision Handlers
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _currentColor)
        {
            _gameManager.AddPoints(_points);
        }
    }


    /// <summary>
    /// Changing the color on exit
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag != _currentColor)
        {
            _playerLives--;
            _gameManager.UpdateLives(_playerLives);
            ColorSwitch();
        }
        else if(collision.tag == _currentColor)
        {
            ColorSwitch();
        }
    }

    #endregion
}
