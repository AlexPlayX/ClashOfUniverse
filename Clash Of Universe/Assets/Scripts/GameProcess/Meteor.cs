using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{


    private float left, right;
    //private int stan;
    private int obrazenia = 0;

    public float Timer_down = 5.0f;
    public float Timer_up = 20.0f;
    private float Timer, czas;

    private GameObject scrO;
    private Score scr;

    public GameObject explodePrefab;


    public int HP = 150;
    // Start is called before the first frame update
    void Start()
    {
        left = -5.7f;
        right = 5.25f;

        float x = Random.Range(left, right);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        //stan = HP;

        scrO = GameObject.Find("Score");
        scr = scrO.GetComponent<Score>();


        Timer = Random.Range(Timer_down, Timer_up);
        czas = Time.time + Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= czas && this.gameObject != null)
        {
            transform.Rotate(Vector3.forward * 75 * Time.deltaTime, Space.Self);
            transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * 2.5f), 0.0f);
        }



        if ((transform.position.y <= -7 && this.gameObject != null))
        {
            Destroy(this.gameObject);
        }

        if (HP <= 0 || obrazenia >= 4)
        {
            int p = scr.GetScore();
            p += 75;
            scr.SetScore(p);



            Destroy(this.gameObject);
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Bullet1" || collision.gameObject.tag == "Bullet2" || collision.gameObject.tag == "Bullet3")
    //    {
    //        HP = HP - 20;
    //        obrazenia++;
    //        transform.localScale = new Vector3(transform.localScale.x * 0.85f, transform.localScale.y * 0.85f, 1.0f);
    //    }

    //    if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Bullet4")
    //    {
    //        if (collision.gameObject.tag == "Bullet4")
    //            Instantiate(explodePrefab, this.transform.position, this.transform.rotation);

    //        HP = 0;
    //    }

    //}


}
