using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defender_controller : MonoBehaviour
{
    private float RotateSpeed = 3f;
    public float Rad = 3f;
 
    private Vector3 _centre;
    private float _angle;
 
    // Start is called before the first frame update
    private void Start()
    {
        _centre = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle), 0) * Rad;
        transform.position = _centre + offset;
        Vector3 dir = _centre - transform.position;
        float angel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);    
    }
}
