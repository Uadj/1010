using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefabs;
    [SerializeField]
    private int orderInLayer;
    // Start is called before the first frame update

    private Vector2Int blockCount = new Vector2Int(10, 10);
    private Vector2 blockHalf = new Vector2(0.5f, 0.5f);

    void Awake()
    {
        for(int y=0; y<blockCount.y; ++y)
        {
            for(int x=0; x<blockCount.x; ++x)
            {
                float px = -blockCount.x * 0.5f + blockHalf.x + x;
                float py = blockCount.y * 0.5f - blockHalf.y - y;
                Vector3 position = new Vector3(px, py, 0);

                GameObject clone = Instantiate(blockPrefabs, position, Quaternion.identity, transform);

                clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
