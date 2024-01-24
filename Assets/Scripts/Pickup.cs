using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.AddPoint(1);
        }

        Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
