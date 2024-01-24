using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] List<Animator> animator;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < animator.Count; i++)
        animator[i].SetTrigger("Start");

    }
}
