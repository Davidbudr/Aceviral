using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public MasterController Master;
    public bool Reset;
    public float MoveSpeed;

    private Vector3 v_originPoint;
    private Rigidbody r_body;

    
    void Awake()
    {
        //set references
        r_body = this.GetComponent<Rigidbody>();
        v_originPoint = this.transform.position;
        
        //make sure it works on both android and pc
        Input.simulateMouseWithTouches = true;

    }

    void Update()
    {
        if (Master.PlayState)
        {
            //re-enable the gravity if it is disabled, this only gets called once each run.
            if (!r_body.useGravity)
            {
                r_body.useGravity = true;
            }
            //add force to the rigidbody so the player rises up when the screen is tapped/mouse is pressed
            if (Input.GetMouseButtonDown(0))
            {
                Master.Effects.PlayFlap();
                r_body.AddForce(Vector3.up * 200);
            }

            //if the player goes too far out of the screen automatically lose the game
            if (this.transform.position.y -1 > Camera.main.orthographicSize || this.transform.position.y +1 < -Camera.main.orthographicSize)
            {
                Master.PlayState = false;
                Master.Effects.PlayLoss();
            }
        }
        else
        {
            //the start screen is not in "play mode" so disable gravity so the player can see their character
            r_body.useGravity = false;
        }
    }

    //when resetting set velocity to zero so the previous run doesnt cause the players character to start of by falling quickly
    public void Restart()
    {
        this.transform.position = v_originPoint;
        r_body.velocity = Vector3.zero;
    }

    //hitting an obsticle also ends the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obsticles"))
        {
            Master.PlayState = false;
            Master.Effects.PlayLoss();
        }
    }
}
