using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _topBound = 4.5f;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.isGameOver)
        {
            _rb.velocity = new Vector2(0, 0);
            if (transform.position.y <= _topBound)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.isGameOver = true;
        Destroy(_rb);
        //_rb.gravityScale = 0;
    }
}
