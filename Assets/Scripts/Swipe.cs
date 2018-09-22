using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
   public Vector2 startTouch, swipeDelta;
    private bool isDragin = false;


    private void Update()
    {
        tap = swipeLeft = swipeDown = swipeRight = swipeUp = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            isDragin = true;
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        #endregion


        #region mobile inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDragin = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragin = false;
                Reset();
            }
        }
        #endregion

        //calculate distance
        swipeDelta = Vector2.zero;

       
        if (isDragin)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
           else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

    

        //did we cross the deadzone?
        if(swipeDelta.magnitude > 200)
        {
            //which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > 10)
            {
                //left or right
                if (x < 10)
                    swipeLeft = true;
                if (x > 10)
                    swipeRight = true;
            }
            if (Mathf.Abs(y) > 10)
            {
                //up or down
                if (y < 10)
                    swipeDown = true;
                if (y > 10)
                    swipeUp = true;
            }

            Reset();
        }
     
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragin = false;
    }


    public bool Tap { get { return Tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight{ get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }


}
