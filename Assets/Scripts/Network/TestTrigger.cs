using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Test");
            other.gameObject.GetComponent<TCP>().TCPSend();
            Debug.Log("TCPSend");
        }
    }
}
