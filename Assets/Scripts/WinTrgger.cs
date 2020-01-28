using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrIGGER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(
            !(GameManager.instance.players[0].games[3]==null)|| !(GameManager.instance.players[1].games[3] == null)||!(GameManager.instance.players[2].games[3] == null) || !(GameManager.instance.players[3].games[3] == null)
            )
        {
           // GameManager.instance.win();
        }
    }
}
