using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThrowHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject aim;
    static public bool isHooked;

    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && isHooked == false)
        {            
                //Debug.Log("line length: " + 
                //    Mathf.Sqrt((Mathf.Pow((hook.transform.position.x - transform.position.x), 2)) 
                //    + (Mathf.Pow((hook.transform.position.y - transform.position.y), 2)))
                //    );
                float angle = aim.transform.eulerAngles.z;

            var x = Mathf.Sin((90 - angle) * Mathf.Deg2Rad) * 30;    // 30 is an arbitrary number, big enough to let the hook leave the scene at every angle (if player misses)
            var y = Mathf.Cos((90 - angle) * Mathf.Deg2Rad) * 30;
            Vector3 newPosition = new Vector3();
            newPosition.x = aim.transform.position.x + x;
            newPosition.y = aim.transform.position.y + y;

            //hook.GetComponent<Rigidbody2D>().gravityScale = 0;

            hook.GetComponent<RopeScript>().destiny = newPosition;
            hook.GetComponent<RopeScript>().speed = 0.6f;
            

        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            //redundant
            //hook.GetComponent<RopeScript>().destiny = PlayerAim.goal;
            //hook.GetComponent<RopeScript>().speed = 1;
            //isHooked = false;
        }





        //if (hook.GetComponent<RopeScript>().finished == true && isHooked == false)
        //{
        //    //hook.GetComponent<RopeScript>().finished = true;

        //    //Vector2 gravity = new Vector2(hook.transform.position.x, hook.transform.position.y - 50);

        //    //hook.transform.position = Vector2.MoveTowards(hook.transform.position, gravity, 0.4f);
        //    Debug.Log("koniec");
        //    hook.GetComponent<RopeScript>().GetComponent<Rigidbody2D>().gravityScale = 1;
        //}
    }
}
