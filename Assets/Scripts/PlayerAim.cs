using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class PlayerAim : MonoBehaviour   // responsible for aiming with joystick
{
    private Transform aimTransform;
    public Joystick joystick;
    public GameObject hook;
    static public Vector3 goal;
    static public bool isDeleting = false;
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            if (RopeScript.nodeList.Any())
            {
                isDeleting = true;
                Debug.Log("started deleting");
                for (int i = RopeScript.nodeList.Count - 1; i > -1 ; --i)
                {
                    Destroy(RopeScript.nodeList[i]);
                    RopeScript.nodeList.RemoveAt(i);                    
                }
                isDeleting = false;
                Debug.Log("finished deleting");
            }

            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            if (horizontal < 0)  
                horizontal = 0;
            //if (vertical < 0)
            //    vertical = 0;

            Vector3 aimDirection = new Vector3(horizontal, vertical);
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);

            float x = Mathf.Sin((90 - angle) * Mathf.Deg2Rad) * 2.5f;  //2f is an offset for the hook, so that it doesn't collide with the bow    
            float y = Mathf.Cos((90 - angle) * Mathf.Deg2Rad) * 2.5f;

            goal = new Vector3(aimTransform.position.x + x, aimTransform.position.y + y, 0);  //hook returning after letting go of space key 
            hook.transform.position = goal;

            //hook.GetComponent<Rigidbody2D>().MovePosition(goal);
            //hook.transform.position = Vector2.MoveTowards(hook.transform.position, goal, 0.4f);     //cant fire the rope after pulling it back
        }

        if (transform.position.y < - 50)
        {
            Score.ResetDistance();
            SceneManager.LoadScene(1);
        }

    }
}
