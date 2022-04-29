using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapphire : MonoBehaviour
{
    public int Amount;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().Sapphire += Amount;
        Destroy(gameObject);
    }
}
