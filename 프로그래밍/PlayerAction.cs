using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameManager manager;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(manager.qeustPanel.activeSelf == false)
                manager.Action();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // C1 - Q2 : Door
        if (other.gameObject.tag.Equals("answer"))
        {
            manager.qeustTwoCheck = true;
        }
        else if (other.gameObject.tag.Equals("wrong"))
        {
            manager.qeustTwoCheck = false;
        }
    }
}
