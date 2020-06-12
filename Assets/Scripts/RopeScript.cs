using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//used to move the hook
public class RopeScript : MonoBehaviour
{
    private enum swingDirection {none, left, right };
    private swingDirection lastSwing = swingDirection.none;
    public Vector3 destiny;
    public float speed;
    public float swingSpeed = 50;

    public float distance = 2;
    public GameObject player;
    public GameObject lastNode;
    public GameObject nodePrefab;
    private int count = 0;
    public Joystick joystick;

    public static List<GameObject> nodeList;
    private bool wait = false;
    public LineRenderer line;
    private void Start()
    {
        nodeList = new List<GameObject>();
        lastNode = transform.gameObject;
        line = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        drawRope();
        if (ThrowHook.isHooked == false && PlayerAim.isDeleting == false )
        {                     
            while (Input.GetKey(KeyCode.Space) && Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)  //nodes are in a certain distance between each other
            {
                createNode();
                ++count;
            }
            transform.position = Vector2.MoveTowards(transform.position, destiny, speed);  //hook moving forward/backwards depending on situation

            if(!lastNode)   //is lastNode empty check
            {
                lastNode = transform.gameObject;
            }
            
        }
        else if(ThrowHook.isHooked == true)
        {
            if (joystick.Vertical > 0.95f && nodeList.Count > 2 && wait == false)
            {
                StartCoroutine(DeleteNodeCoroutine());
            }
            //swinging left/right
            if (joystick.Horizontal > 0.95f && (lastSwing == swingDirection.none || lastSwing == swingDirection.left))
            {
                player.GetComponent<Rigidbody2D>().AddForce(player.transform.right * swingSpeed);
                lastSwing = swingDirection.right;
                Debug.Log("right");
            }
            if (joystick.Horizontal < -0.95f && (lastSwing == swingDirection.none || lastSwing == swingDirection.right))
            {
                player.GetComponent<Rigidbody2D>().AddForce(-player.transform.right * swingSpeed);
                lastSwing = swingDirection.left;
                Debug.Log("left");
            }
        }
        if (!Input.GetKey(KeyCode.Space))  //when player lets go of the space key, the hook returns to the character
        {
            speed = 1;
            ThrowHook.isHooked = false;
            lastSwing = swingDirection.none;
            line.positionCount = 0;
        }      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform" && Input.GetKey(KeyCode.Space))
        {
            ThrowHook.isHooked = true;
            speed = 0;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }
    }

    void createNode() //creating nodes between the hook and player
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);        

        go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

        lastNode = go;

        nodeList.Add(lastNode);
    }

    IEnumerator DeleteNodeCoroutine()
    {
        wait = true;

        //adding momentum
        var forceDirection = nodeList[0].transform.position - player.transform.position;
        player.GetComponent<Rigidbody2D>().AddForce(forceDirection * 10);

        Destroy(nodeList[0]);
        nodeList.RemoveAt(0);
        nodeList[0].GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x, transform.position.y - distance);
        nodeList[0].transform.SetParent(transform);
        transform.GetComponent<HingeJoint2D>().connectedBody = nodeList[0].GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(0.00000001f);
        wait = false;
    }

    void drawRope()
    {

        line.positionCount = nodeList.Count + 1;
        
        line.SetPosition(0, transform.position);   // connected to hook

        for(int i = 0; i < nodeList.Count; ++i)
        {
            line.SetPosition(i + 1, nodeList[i].transform.position);
        }
        line.SetPosition(line.positionCount - 1, player.transform.position);
    }
}
