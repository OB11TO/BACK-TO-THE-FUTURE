using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallenPlayer : MonoBehaviour
{

    public UnityEvent onPlayerFalling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Fallen!!");
            onPlayerFalling.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
