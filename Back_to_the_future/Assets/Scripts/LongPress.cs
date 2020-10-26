using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isDown;

    public UnityEvent onPointerDown;


    public void OnPointerDown(PointerEventData eventData) 
    {
        this.isDown = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        this.isDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
            onPointerDown.Invoke();
    }
}
