using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;


public class fpsController : MonoBehaviour
{

    private CharacterController controller;

    public GameObject currentgun;
    
    private Vector3 moveDir = Vector3.zero;
     
    private float xRotation = 0;
    private float yRotation = 0;

    public float speed = 20;
    public Camera playerCamera;
    public float lookSpeed;
    public float lookXLimit;
    
    public float fallSpeed = 20;
    
    private float grav = 20f;
    public float runSpeedBonus = 10;

    public float jumpSpeed = 20f;

    public float jumpHeight = 5f;

    public bool jumpexaughsted = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveCharecter();
 
    }

    void moveCharecter()
    {

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float lv_speed = speed;

        if (isRunning)
        {
            lv_speed = runSpeedBonus+speed;
        }

        float moveheight = moveDir.y;
        
        moveDir = (lv_speed * transform.TransformDirection(Vector3.forward) 
                            * Input.GetAxis("Vertical") ) 
                  + (lv_speed *  transform.TransformDirection(Vector3.right) 
                              * Input.GetAxis("Horizontal"));
        
        
        
        Debug.Log("Height" + moveDir.y + "maxjumpHeight " + jumpHeight );
        
        if (Input.GetButton("Jump") &&   controller.isGrounded && jumpexaughsted)
        {
            moveDir.y +=  jumpSpeed;

        }else
        {
            moveDir.y = moveheight;
        }
        
        if (Input.GetButton("Jump") &&  jumpexaughsted == false)
        {
            moveDir.y +=  jumpSpeed;
        } 

        if( moveDir.y >= jumpHeight && jumpexaughsted == false)
        {
            jumpexaughsted = true;
        }

        if (!controller.isGrounded && jumpexaughsted)
        {
            moveDir.y -= fallSpeed * Time.deltaTime;
        }

        //able to jump to full height after hitting the ground
        if (controller.isGrounded)
        {
            jumpexaughsted = false;
        }

        controller.Move(moveDir * Time.deltaTime);
        xRotation += -Input.GetAxis("Mouse Y") * lookSpeed;
        xRotation =  Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);
        
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); 
        // currentgun.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); 
        
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
 
}
