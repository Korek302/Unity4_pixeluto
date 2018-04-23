using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRestarter : MonoBehaviour
{
    public GameObject Character;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Character.transform.position = new Vector3(0,0,0);
        }
    }
}
