using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{


    public Transform bul;
    public float NextFire = 2.0f;
    private float nextfire;


    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time + 2.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextfire)
        {
            if (bul != null)
            {
                nextfire = Time.time + NextFire;
                Transform bullet = Instantiate(bul, new Vector3(transform.position.x, transform.position.y - 0.85f, transform.position.z), new Quaternion(transform.rotation.x, transform.rotation.y, -180.0f, 1));
                if (bul.gameObject.name == "Bul1")
                    bullet.tag = "Bullet11";

                if (bul.gameObject.name == "Bul2")
                    bullet.tag = "Bullet22";

                if (bul.gameObject.name == "Bul3")
                {
                    bullet.SetParent(this.transform);
                    //bullet.tag = "Bullet3e";
                }
                if (bul.gameObject.name == "Bul4")
                    bullet.tag = "Bullet44";

                bullet.gameObject.SetActive(true);
            }
        }
    }
}
