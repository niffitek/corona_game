using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prjectile : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 direction;
    private float speed = 1f;
    private float next_move = 0f;
    private Vector3 dir = new Vector3(0, 0, 0);
    void Start()
    {
        transform.rotation = player.GetComponent<defender_controller>().transform.rotation;
        float radian = transform.rotation.z * (Mathf.PI / 180);
        dir = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_move) {
            next_move = Time.time + 0.5f;
            transform.position += dir * speed;
        }
    }
}
