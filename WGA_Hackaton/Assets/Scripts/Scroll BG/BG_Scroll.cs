using UnityEngine;

public class BG_Scroll : MonoBehaviour 
{
    float scrollSpeed = 5f;

    void FixedUpdate()
    {
        if (!GameManager.isGameOver)
        {
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
}
