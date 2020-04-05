using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float velocity;
   

    private float right = 6.043244f;
    private float left = -6.030853f;
   

  

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetKey("left") || (Input.GetKey(KeyCode.A))) && transform.position.x > left)
        {
            if (!Objects.isPaused)
            {
                Turn('L');
                transform.position = new Vector3(transform.position.x + (Time.deltaTime * velocity * (-1)), transform.position.y, 0.0f);
            }
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right") || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (!Objects.isPaused)
                this.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.selectedShip;
        }
        if ((Input.GetKey("right") || (Input.GetKey(KeyCode.D))) && transform.position.x < right)
        {
            if (!Objects.isPaused)
            {
                Turn('R');
                transform.position = new Vector3(transform.position.x + (velocity * Time.deltaTime), transform.position.y, 0.0f);
            }
        }


       
    }

   
    private void Turn(char side)
    {
        if (side == 'L')
        {
            this.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (side == 'R')
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
       
    }
    
}