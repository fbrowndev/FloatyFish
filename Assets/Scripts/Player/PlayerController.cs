using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player variables
    [Header("Player Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _xBounds = 2;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


    #endregion
}
