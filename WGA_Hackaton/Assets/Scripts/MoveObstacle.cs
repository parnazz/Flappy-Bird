using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField]
    private float _speedOfObstacle = 5f;
    [SerializeField]
    private float _xDestroyBound = -15f;

    [SerializeField]
    private GameObject[] _powerupPrefabs;

    [SerializeField]
    private Vector3[] _randomPosToSpawnPowerup;

    private void Start()
    {
        int randomIndexOfPrefab = Random.Range(0, 7); //Уменьшить шанс получить паверап
        int randomIndexOfPos = Random.Range(0, _randomPosToSpawnPowerup.Length);
        Vector3 posToSpawn;
        GameObject spawnedPowerup;

        switch (randomIndexOfPrefab)
        {
            case 5:
                posToSpawn = transform.position + _randomPosToSpawnPowerup[randomIndexOfPos];
                spawnedPowerup = Instantiate(_powerupPrefabs[0], posToSpawn, Quaternion.identity);
                spawnedPowerup.transform.parent = transform;
                break;
            case 6:
                posToSpawn = transform.position + _randomPosToSpawnPowerup[randomIndexOfPos];
                spawnedPowerup = Instantiate(_powerupPrefabs[1], posToSpawn, Quaternion.identity);
                spawnedPowerup.transform.parent = transform;
                break;
        }

    }

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
