using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIText : MonoBehaviour
{
    public GameObject Player;
    public Text HP;
    public Text Ruby;
    public Text Emerald;
    public Text Sapphire;

    // Update is called once per frame
    void Update()
    {
        HP.GetComponent<Text>().text = Player.GetComponent<Player>().HP.ToString();
        Ruby.GetComponent<Text>().text = Player.GetComponent<Player>().Ruby.ToString();
        Emerald.GetComponent<Text>().text = Player.GetComponent<Player>().Emerald.ToString();
        Sapphire.GetComponent<Text>().text = Player.GetComponent<Player>().Sapphire.ToString();
    }
}
