using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Monster : MonoBehaviour
{
    public Transform player;
    public int minNumberOfTouches = 50;
    public float secondsToTouch = 10f;
    int numberOfTouches;
    public UnityEvent onMonsterMet;
    public UnityEvent onMonsterFailed;
    public UnityEvent onMonsterSuccess;

    Vector2 beginTouchPosition;
    Vector2 endTouchPosition;

    bool isInstantiated = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator StartTimeCount ()
    {


        onMonsterMet.Invoke();
        yield return new WaitForSeconds(secondsToTouch);
        if (numberOfTouches < minNumberOfTouches)
            onMonsterFailed.Invoke();
        else onMonsterSuccess.Invoke();

        Destroy(gameObject);

    }


    void CheckMeeting ()
    {
        float distance = Vector3.Distance(transform.position, player.position);
       // Debug.Log(distance);
        if (distance < 3.0f)
        {
            Debug.Log("I'M HERE");
            isInstantiated = true;
            StartCoroutine(StartTimeCount());
        }
    }

    void CheckTouches ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);


            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beginTouchPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    endTouchPosition = touch.position;

                    if (beginTouchPosition == endTouchPosition)
                    {
                        numberOfTouches++;
                    }

                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isInstantiated)
        {
            CheckTouches();          
        }
        else
        {
            CheckMeeting();
        }
    }
}
