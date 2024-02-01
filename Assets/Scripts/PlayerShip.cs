using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private Inventory i;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            i.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            i.OnStopUse();
        }
    }
}
