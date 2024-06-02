using UnityEngine;

public class EnemySpawnArea : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private float _delayBeforeSpawn = 1f;

    private float _timeToSpawn = 0f;

    void Update()
    {
        if(_timeToSpawn >= _delayBeforeSpawn) {
            GetSpawnPosition(transform.position, out Vector3 spawnPosition);
            GameObject spawnedEnemy = Instantiate(_enemyPrefab, transform, false);
            spawnedEnemy.transform.position = spawnPosition;
            spawnedEnemy.SetActive(true);
            _timeToSpawn = 0f;
        }
        _timeToSpawn += Time.deltaTime;
    }

    private void GetSpawnPosition(Vector3 parentPosition, out Vector3 spawnPosition) {
        spawnPosition = new Vector3(parentPosition.x ,Random.Range(-5, 5), parentPosition.z);
        Debug.Log(spawnPosition);
    }
}
