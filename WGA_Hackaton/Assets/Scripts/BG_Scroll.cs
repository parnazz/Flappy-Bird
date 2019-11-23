using UnityEngine;

public class BG_Scroll : MonoBehaviour 
{
    float scrollSpeed = 5f;

    void Update()
    {
        if (!GameManager.isGameOver)
        {
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
}
