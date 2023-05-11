using UnityEngine;

public class Spawner : MonoBehaviour{

    public GameObject[] prefabs;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    public float minDistance = 1f;

    private Vector3 lastSpawnPosition;

    private void OnEnable(){
        lastSpawnPosition = transform.position;
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable(){
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn(){
        int randomIndex = Random.Range(0, prefabs.Length);
        Vector3 spawnPosition = GetSpawnPosition();
        bool overlap = CheckOverlap(spawnPosition);
        if (!overlap) {
            GameObject pipes = Instantiate(prefabs[randomIndex], spawnPosition, Quaternion.identity);
            lastSpawnPosition = pipes.transform.position;
        }
    }

    private Vector3 GetSpawnPosition() {
        float x = lastSpawnPosition.x + Random.Range(minDistance, minDistance * 2f);
        float y = Random.Range(minHeight, maxHeight);
        float z = lastSpawnPosition.z;
        return new Vector3(x, y, z);
    }

    private bool CheckOverlap(Vector3 position) {
        Collider[] hits = Physics.OverlapSphere(position, minDistance);
        foreach (Collider hit in hits) {
            if (hit.CompareTag("Pipe")) {
                return true;
            }
        }
        return false;
    }
}