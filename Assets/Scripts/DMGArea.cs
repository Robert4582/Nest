using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGArea : MonoBehaviour
{
    private bool giveDMG = true;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (giveDMG)
            {
                StartCoroutine(Coroutine());
                other.gameObject.GetComponent<Player>().HP -= 10;
            }
        }
    }

    IEnumerator Coroutine()
    {
        giveDMG = false;
        yield return new WaitForSecondsRealtime(1);
        giveDMG = true;
    }
}
