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

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //Gaining access to the sprite render to change color

        ColorSwitch(); //Switching color at the start of the game


        //Null checks below
        if(_spriteRenderer == null)
        {
            Debug.LogError("_spriteRenderer is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PCMovement();
    }


    #region Button Controls
    public void LeftButton()
    {
        if(transform.position.x > -_xBounds)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
    }

    public void RightButton()
    {
        if(transform.position.x < _xBounds)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }


    //This method is for testing purposes on pc
    /// <summary>
    /// Method is made only for testing purposes on PC
    /// </summary>
    void PCMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontalMovement * _speed * Time.deltaTime);
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ColorStrip")
        {
            ColorSwitch();
        }
    }

    #endregion
}
