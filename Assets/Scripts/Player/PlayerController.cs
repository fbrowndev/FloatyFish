using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player variables
    [Header("Player Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xBounds = 2;


    [Header("Abilities")]
    [SerializeField] Color32[] _playerColors;

    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
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
    }


    #region Button Controls
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
    }

    #endregion

    #region Collision Handlers
    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    /// <summary>
    /// Changing the color on exit
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ColorStrip")
        {
            ColorSwitch();
        }
    }

    #endregion
}
