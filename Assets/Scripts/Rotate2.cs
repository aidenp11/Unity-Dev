using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float rate;
    float speed = 5;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rate * Time.deltaTime, Vector3.up);
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
    }
}
