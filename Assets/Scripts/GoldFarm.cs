using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFarm : MonoBehaviour
{
    private bool giveGold = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (giveGold)
            {
                StartCoroutine(Coroutine());
                //other.gameObject.GetComponent<Player>().Gold += 1;
            }
        }
    }

    IEnumerator Coroutine()
    {
        giveGold = false;
        yield return new WaitForSecondsRealtime(1);
        giveGold = true;
    }
}
