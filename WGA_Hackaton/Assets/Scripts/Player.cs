using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Collider2D _playerCollider;
    private UIManager _uIManager;

    [SerializeField]
    private float _jumpForce = 5f;
    private float _cooldownTime = 0.7f;
    private float _nextJump = 0.0f;

    [SerializeField]
    private float _topBound = 4.5f;
    [SerializeField]
    private float _bottomBound = -6f;
    [SerializeField]
    private float _invincibilityTime = 2f;
    private bool _isShieldActive = false;
    private int _score = 0;

	public GameObject Shield;

    public Light _light;
    private float _timeToLight = 0.0f;
    private bool _isLightOnn = false;
    private bool _isLightOff = false;
    private bool _isLight = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.isGameOver)
        {
            Jump();
        }

        LightOnnOff();

        if (transform.position.y <= _bottomBound)
        {
            _uIManager.CalculateHighScore();
            GameManager.isGameOver = true;
            Destroy(_rb);
        }
    }

    private void Jump()
    {
        if (Time.time > _nextJump)
        {
            _nextJump = Time.time + _cooldownTime;

            _rb.velocity = new Vector2(0, 0);

            if (transform.position.y <= _topBound)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            }

            _isLightOnn = true;
        }
    }

    private void LightOnnOff()
    {
        if (_isLightOnn)
        {
            _timeToLight += Time.deltaTime / 0.3f;
            _light.range = Mathf.Lerp(3f, 10f, _timeToLight);

            if (_timeToLight >= 1f)
            {
                _isLightOnn = false;
                _isLightOff = true;
                _timeToLight = 0;
            }
        }

        if (_isLightOff)
        {
            _timeToLight += Time.deltaTime / 0.3f;
            _light.range = Mathf.Lerp(10f, 3f, _timeToLight);

            if (_timeToLight >= 1f)
            {
                _isLightOff = false;
                _timeToLight = 0;
            }
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
                _uIManager.CalculateHighScore();
                GameManager.isGameOver = true;
                Destroy(_rb);
            }
        }
		
        if (collision.gameObject.tag == "Shield")
        {
			Shield.gameObject.SetActive(true);
            _isShieldActive = true;
            Destroy(collision.gameObject);
            _playerCollider.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoalScore"))
        {
            _score++;
            _uIManager.UpdateScore(_score);
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        yield return new WaitForSeconds(_invincibilityTime);
        _playerCollider.enabled = true;
    }

    IEnumerator LightCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _isLightOnn = false;
        _isLight = true;
    }

}
