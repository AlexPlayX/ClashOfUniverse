using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{

    public Transform p1, p2, p3;

    private float x2, y2, x3, y3;

    private bool enemy=false;

    private float p1ypos;
    // Start is called before the first frame update
    void Start()
    {
        x2 = p2.position.x;
        y2= p2.position.y;

        x3 = p3.position.x;
        y3 = p3.position.y;

        if (this.transform.parent != null)
            if (this.transform.parent.tag == "bul1" || this.transform.parent.tag == "bul2" || this.transform.parent.tag == "Boss")
            {
                enemy = true;
                p1.tag = "Bullet33";
                p2.tag = "Bullet33";
                p3.tag = "Bullet33";
            }
            

        this.transform.parent = null;

    }

    // Update is called once per frame
    void Update()
    {

        if (enemy)
        {
            if (p1 != null)
            {
                
                p1.transform.position += Vector3.down * Time.deltaTime * 9;
                 
            }


            if (p2 != null)
            {
                
                p2.position = Vector3.MoveTowards(p2.position, new Vector3(x2 - 0.85f, y2 - 12.0f, 0), Time.deltaTime * 7);
            }


            if (p3 != null)
            {
                
                p3.position = Vector3.MoveTowards(p3.position, new Vector3(x2 + 0.85f, y3 - 12.0f, 0), Time.deltaTime * 7);
            }
                
        }
        else
        {

            if (p1 != null && p1.tag == "Bullet3")
                p1.transform.position += Vector3.up * Time.deltaTime * 9;

            if (p2 != null && p2.tag == "Bullet3")
                p2.position = Vector3.MoveTowards(p2.position, new Vector3(x2 + 3.0f, y2 + 15.0f, 0), Time.deltaTime * 9);

            if (p3 != null && p3.tag == "Bullet3")
                p3.position = Vector3.MoveTowards(p3.position, new Vector3(x2 - 3.0f, y3 + 15.0f, 0), Time.deltaTime * 9);
        }
        
    }

    private void FixedUpdate()
    {
        if (transform.childCount == 0)
            Destroy(this.gameObject);
    }
}
