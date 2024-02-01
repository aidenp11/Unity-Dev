using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KinematicController : MonoBehaviour, IDamagable
{
    [SerializeField, Range(0, 40)] float speed = 1;

    public float health = 100;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 force = direction * speed * Time.deltaTime;
        transform.localPosition += force;
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }
}
