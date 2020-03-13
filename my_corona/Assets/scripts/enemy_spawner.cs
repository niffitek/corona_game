using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        GameObject go = (GameObject)Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        go.GetComponent<enemy_movement>().isClone = true;
    }
}
