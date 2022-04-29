using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP;
    public int Ruby;
    public int Emerald;
    public int Sapphire;


    private void Update()
    {
        if (HP <= 0)
        {
            Application.Quit();
            Debug.Break();
        }
    }
}
