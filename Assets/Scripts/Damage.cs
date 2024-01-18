using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Numerics;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.Damage(damage); 
        }
    }
}

