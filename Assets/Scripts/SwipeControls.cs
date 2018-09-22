using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour {
    /*
    public void swipePosition()
    {
        rechargeON = true;
           swipeRecharge = 0;


            if (swipeControls.SwipeLeft)
            {
                desiredPosition += Vector3.left;
                Debug.Log("left");
            }
           else if (swipeControls.SwipeRight)
            {
                desiredPosition += Vector3.right;
                Debug.Log("right");
            }

             if (swipeControls.SwipeUp)
            {
                desiredPosition += Vector3.up;
                Debug.Log("up");
            }

            else if (swipeControls.SwipeDown)
            {
                desiredPosition += Vector3.down;
                Debug.Log("down");
            }
            desiredPosition.Normalize();
            desiredPosition *= swipeSpeed;
            acceleration += desiredPosition;

    }
    */


    /*
     *
     *swipeTimer = 0;
            swipeRecharge = 0;
            rechargeON = false;


     * 
     *   touchPlayer = false;
            swipeRecharge++;
            if (swipeRecharge >= rechargeFloat && rechargeON)
            {
                swipeRecharge = rechargeFloat;
                acceleration = Vector3.zero;
                desiredPosition = Vector3.zero;
                velocity = Vector3.zero;
                rechargeON = false;
                swipeTimer = 2;
            }

            swipeTimer -= 1 * Time.deltaTime;
            if (swipeTimer <= 0)
            {

                swipeTimer = 0;
            }


         private Vector3 desiredPosition;
        public Swipe swipeControls;


        public float swipeTimer;
       public float swipeRecharge;
        public float rechargeFloat;
        public bool rechargeON;

        public bool touchPlayer;

         private void OnMouseDrag()
        {
           // touchPlayer = true;
           // if (swipeTimer <= 1)
           // swipePosition();
        }
     */
}
