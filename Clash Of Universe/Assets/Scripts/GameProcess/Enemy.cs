using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int HP = 40;
    private int hp;

    private GameObject scrO;
    private Score scr;

    public GameObject explodePrefab;

    private Color origColor;

    void Start()
    {
       // origColor = gameObject.GetComponent<SpriteRenderer>().color;
        scrO = GameObject.Find("Score");
        scr = scrO.GetComponent<Score>();
        hp = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            int p = scr.GetScore();

            if (this.gameObject.tag == "enemy1")
                p += 50;

            if (this.gameObject.tag == "enemy2")
                p += 100;

            scr.SetScore(p);

            //Instantiate(explodePrefab, this.transform.position, this.transform.rotation);
            //Destroy(gameObject);
        }
    }


   
}