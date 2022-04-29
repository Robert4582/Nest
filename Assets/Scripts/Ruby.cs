using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public int Amount;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().Ruby += Amount;
        Destroy(gameObject);
    }
}
