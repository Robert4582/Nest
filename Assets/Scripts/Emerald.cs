using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emerald : MonoBehaviour
{
    public int Amount;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().Emerald += Amount;
        Destroy(gameObject);
    }
}
