using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light discoLight;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        discoLight.color = Random.ColorHSV();
    }
}
