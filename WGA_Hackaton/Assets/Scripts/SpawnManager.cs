using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _objToAvoid;
    [SerializeField]
    private float _spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles(_objToAvoid));
    }

    IEnumerator SpawnObstacles(GameObject obstacle)
    {
        while (!GameManager.isGameOver)
        {
            float randomYPos = transform.position.y + Random.Range(-2f, 2f);
            Vector3 randomObstaclePos = new Vector3(transform.position.x, randomYPos, transform.position.z);

            Instantiate(obstacle, randomObstaclePos, Quaternion.identity);

            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
