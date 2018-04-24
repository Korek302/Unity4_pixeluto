using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBevaviour : MonoBehaviour
{
    [SerializeField]
    private float newLocX;
    [SerializeField]
    private float newLocY;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(newLocX, newLocY, 0);
        }
    }
}
