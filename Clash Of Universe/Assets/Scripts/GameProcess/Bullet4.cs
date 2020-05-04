using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : MonoBehaviour
{

    public GameObject child;
    public CircleCollider2D cc;
    public GameObject explodePrefab;
    public static bool Enable = true;
    // Start is called before the first frame update
    void Start()
    {
        cc.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enable)
        {
            if (this.gameObject != null)
            {
                if (transform.childCount == 0)
                {
                    cc.isTrigger = false;
                    transform.position = this.transform.position;
                }
                else
                {
                    transform.position = child.transform.position;
                }
            }

            if ((this.transform.position.y > 5.0f || this.transform.position.y <= -7) && this.gameObject != null)
                Destroy(this.gameObject);
        }
       
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "bul1") || (collision.gameObject.tag == "bul2") || (collision.gameObject.tag == "Player") || (collision.gameObject.tag == "Boss"))
        {
            if (this.gameObject != null && child == null)
            {
                Instantiate(explodePrefab, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

   

}
