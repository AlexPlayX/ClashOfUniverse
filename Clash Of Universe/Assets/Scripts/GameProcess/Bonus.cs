using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
 

    public float Timer_down = 15.0f;
    public float Timer_up = 20.0f;
    private float Timer;
    public int Type = 2;


    private float left, right;

    private float current_time;
    // Start is called before the first frame update
    void Start()
    {
        if (Type == 0)
            gameObject.tag = "BonusHP";

        if (Type == 1)
            gameObject.tag = "Bul1";

        if (Type == 2)
            gameObject.tag = "Bul2";

        if (Type == 3)
            gameObject.tag = "Bul3";

        if (Type == 4)
            gameObject.tag = "Bul4";

        if (Type == 5)
            gameObject.tag = "Bul5";

        if (Type == 6)
            gameObject.tag = "enem";

        if (Type == 7)
            gameObject.tag = "met";

        if (Type == 8)
            gameObject.tag = "atack";

        if (Type == 9)
            gameObject.tag = "HP";

        left = -5.7f;
        right = 5.25f;

        float x = Random.Range(left, right);


        Timer = Random.Range(Timer_down, Timer_up);

        if (Type == 7 || Type == 8 || Type == 9)
            current_time = Time.time;
        else
        {
            current_time = Time.time + Timer;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -7 && this.gameObject != null)
            Destroy(this.gameObject);

        
       if (Time.time >= current_time && this.gameObject != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * 3), 0.0f);
        }
    }
}
