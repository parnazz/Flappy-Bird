using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField]
    private float _speedOfObstacle = 5f;
    [SerializeField]
    private float _xDestroyBound = -15f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver)
        {
            transform.Translate(Vector3.left * _speedOfObstacle * Time.deltaTime);
        }

        if (transform.position.x < _xDestroyBound)
        {
            Destroy(this.gameObject);
        }
    }
}
