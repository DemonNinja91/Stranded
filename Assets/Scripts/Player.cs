using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{

    public Animator playerAnim;
    public Rigidbody playerRigid;

    //variables containing the walk speed, the back walking speed, sprint speed
    public float w_speed, wb_speed, olw_speed, sprnt_speed, ro_speed, side_speed, aim_speed;
    //States that if the player is is in the state of moving or not
    public bool walking;
    //Indicates that the arrow is drawn from the quiver
    public bool arrow_drawn;
    //Indicates that the player is moving sideways
    public bool side_walk;
    //The transform component for the rotation of the RigidBody
    public Transform playerTrans;

    public bool isAiming;
    



    void FixedUpdate()
    {
       /* if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigid.velocity = transform.right * side_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigid.velocity = -transform.right * side_speed * Time.deltaTime;
        }*/

    }
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("idle");
                walking = true;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.ResetTrigger("run");
                playerAnim.SetTrigger("idle");
                walking = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerAnim.SetTrigger("run back");
                playerAnim.ResetTrigger("idle");
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.ResetTrigger("run back");
                playerAnim.SetTrigger("idle");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerAnim.SetTrigger("run right");
                playerAnim.ResetTrigger("idle");

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.ResetTrigger("run right");
                playerAnim.SetTrigger("idle");

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnim.SetTrigger("run left");
                playerAnim.ResetTrigger("idle");

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.ResetTrigger("run left");
                playerAnim.SetTrigger("idle");

            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                playerAnim.SetTrigger("idle Examine");

                playerAnim.ResetTrigger("idle");
            }
            if (Input.GetKeyUp(KeyCode.N))
            {
                playerAnim.ResetTrigger("idle Examine");
                playerAnim.SetTrigger("idle");

            }
            if (Input.GetMouseButtonDown(1))
            {
                playerAnim.SetTrigger("arrow draw");
                playerAnim.ResetTrigger("idle");

                arrow_drawn = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerAnim.SetTrigger("idle melee");
                playerAnim.ResetTrigger("idle");
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                playerAnim.ResetTrigger("idle melee");
                playerAnim.SetTrigger("idle");
            }



            if (walking == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    w_speed = w_speed + sprnt_speed;
                    playerAnim.SetTrigger("sprint");
                    playerAnim.ResetTrigger("run");
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    w_speed = 130f;
                    playerAnim.ResetTrigger("sprint");
                    playerAnim.SetTrigger("run");
                }
            }

            //aiming animations for the player
            if (arrow_drawn == true)
            {
                playerAnim.SetTrigger("idle aim");
                //aim in idle position
                if (Input.GetMouseButtonUp(1))
                {
                    playerAnim.ResetTrigger("idle aim");
                    playerAnim.SetTrigger("idle");
                    isAiming = true;
                }

                if (isAiming == true)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        playerAnim.SetTrigger("aim move forward");
                        playerAnim.ResetTrigger("idle aim");
                        walking = true;
                    }
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        playerAnim.ResetTrigger("aim move forward");
                        playerAnim.SetTrigger("idle aim");
                        walking = false;
                    }
                }

            }

        }

    }
}

