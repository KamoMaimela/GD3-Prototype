using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;

    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Slider slider;
    public float decreasePerMinute;


     void Start()
    {
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();
    }


    void Update()
    {
        //GROUNDCHECK
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //FPS MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z ;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //STAMINA CHECK
        if (this.velocity.magnitude > 1 && Input.GetKey("w"))
        {
            slider.value -= Time.deltaTime * decreasePerMinute / 5f;
        }
        else
        {
            slider.value += Time.deltaTime * decreasePerMinute / 5f;
        }

        //STAMINA AFFECTING SPEED
        if (slider.value <= 0)
        {
            speed = 1;
        }
        else if (slider.value > 0 )
        {
            speed = 4;
        }
    }
}
