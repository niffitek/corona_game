using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prjectile : MonoBehaviour
{
    public GameObject player;
    
    public bool isClone = false;
    // Start is called before the first frame update
    public Vector3 startPos;
    public Vector3 direction;
    private float speed = 0.1f;
    private float next_move = 0f;
    private Vector3 dir = new Vector3(0, 0, 0);
    void Start()
    {
        float radian = transform.rotation.z;
        Debug.Log(transform.rotation.z);
        dir = -transform.position;
        Debug.Log(dir);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClone == true) {
            if (Time.time > next_move) {
                next_move = Time.time + 0.05f;
                transform.position += dir * speed;
            }
            if (!((-10 < transform.position.x  && transform.position.x < 10) && (-10 < transform.position.y && transform.position.y  < 10))) {
                Destroy(gameObject);
            }
        }
    }
    public void set_my_pos()
    {
        transform.position = player.GetComponent<defender_controller>().transform.position;
        transform.rotation = player.GetComponent<defender_controller>().transform.rotation;
    }
}
