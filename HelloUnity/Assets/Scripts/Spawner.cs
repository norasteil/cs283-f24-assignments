using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float range = 10f;
    public float maxSpawn = 10;

    private List<GameObject> spawned = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxSpawn; i++) {
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawned.Count; i++) {
            if (!spawned[i].activeInHierarchy) {
                RespawnObject(spawned[i]);
            }
        }
    }

    private void SpawnObject() {
        Vector3 spawnPos = GetRandomPosition();
        GameObject newObj = Instantiate(prefab, spawnPos, Quaternion.identity);
        spawned.Add(newObj);
    }

    private void RespawnObject(GameObject obj) {
        obj.transform.position = GetRandomPosition();
        obj.SetActive(true);
    }

    private Vector3 GetRandomPosition() {
        Vector3 randomOffset = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
        randomOffset.y = 0;
        Vector3 spawnPos = transform.position + randomOffset;

        Collider collider = prefab.GetComponent<Collider>();
        if (collider != null) {
            float terrainHeight = Terrain.activeTerrain.SampleHeight(spawnPos);
            spawnPos.y = (terrainHeight + collider.bounds.extents.y + 1.2f) * 2;
        }

        return spawnPos;
    }
}
