using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] blockSpawnPoints;
    [SerializeField]
    private GameObject[] blockPrefabs;
    [SerializeField]
    private Vector3 spawnGapAmount = new Vector3(10, 0, 0);
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("OnSpawnBlocks");
    }

    // Update is called once per frame
    private IEnumerator OnSpawnBlocks()
    {
        for(int i=0; i < blockSpawnPoints.Length; ++i)
        {
            yield return new WaitForSeconds(0.1f);
            int index = Random.Range(0, blockPrefabs.Length);
            Vector3 spawnPosition = blockSpawnPoints[i].position + spawnGapAmount;
            GameObject clone = Instantiate(blockPrefabs[index], blockSpawnPoints[i].position, Quaternion.identity, blockSpawnPoints[i]);
            clone.GetComponent<DragBlock>().Setup(blockSpawnPoints[i].position);
        }
    }
    void Update()
    {
        
    }
}
