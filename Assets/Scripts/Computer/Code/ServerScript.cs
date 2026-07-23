using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServerScript : MonoBehaviour
{
    [Header("THIS SCRIPT WAS MADE BY FLIMCYVR. IT IS NOT YOURS.")]
    [Header("Distributing This Script Will Lead To A Permanent Ban and MORE!")]
    [Header("If you make a video on this script")]
    [Header("credit me with my discord and youtube")]
    public JoinRoom joinRoom;
    public string Letter;
    public TextMeshPro ServerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "FC")
        {
            if (joinRoom.name.Length < 12) 
            {
                joinRoom.name += Letter;
                ServerText.text = joinRoom.name; 
            }
        }
    }

    private void FixedUpdate() 
    {
        ServerText.text = joinRoom.name;
    }
}