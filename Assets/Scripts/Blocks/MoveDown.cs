using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveDown : MonoBehaviour
{
    #region Move Variables
    [Header("General Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _outOfBounds = -6;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DropBlock();
        OutOfBoundsCheck();
    }


    #region Movement
    void DropBlock()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    void OutOfBoundsCheck()
    {
        if(transform.position.y < _outOfBounds)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion
}
