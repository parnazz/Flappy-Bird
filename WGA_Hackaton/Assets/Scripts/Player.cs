using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _playerCollider;

    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private float _topBound = 4.5f;
    [SerializeField]
    private float _bottomBound = -6f;
    [SerializeField]
    private float _invincibilityTime = 2f;
    private bool _isShieldActive = false;

	public GameObject Shield;
	[HideInInspector]
	public GameObject Buff;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
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

       if (transform.position.y <= _bottomBound)
       {
           GameManager.isGameOver = true;
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Enemy")
        {
            if (_isShieldActive)
            {
                _isShieldActive = false;
                Shield.gameObject.SetActive(false);
                StartCoroutine(InvincibilityCoroutine());
            }
            else
            {
                GameManager.isGameOver = true;
                Destroy(_rb);
            }
        }
		
        if (collision.gameObject.tag == "Shield")
        {
			Shield.gameObject.SetActive(true);
            _isShieldActive = true;
            Destroy(collision.gameObject);
		}
		
        if (collision.gameObject.tag == "Buff")
        {
			//Buff.gameObject.SetActive;
		}
    }

    IEnumerator InvincibilityCoroutine()
    {
        _playerCollider.enabled = false;
        yield return new WaitForSeconds(_invincibilityTime);
        _playerCollider.enabled = true;
    }

}
