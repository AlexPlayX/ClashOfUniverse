using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Second : MonoBehaviour
{

    public int HP;

    private Animation animation;

    private GameObject scrO;
    private ScoreHandler scr;

    public List<GameObject> bonus;
    private int k;

    public Transform bul;

    public Transform bul2;
    public float NextFire;
    private float fire;

    private bool BossDead = false;

    public GameObject ExplosionPrefab;

    private Color origColor;

    private bool stage_1 = true;

    public BossHB HB;

    // Start is called before the first frame update
    void Start()
    {
        origColor = gameObject.GetComponent<SpriteRenderer>().color;
        scrO = GameObject.Find("Score");
        scr = scrO.GetComponent<ScoreHandler>();

        animation = this.gameObject.GetComponent<Animation>();

        if (animation != null)
        {
            MusicManager.Instance.PlayBattleMusic();
            Debug.Log("bosswin");
            animation.Play("boss1fir");
        }

        k = Random.Range(0, bonus.Capacity);

        fire = Time.time + 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Boss HP: " + HP);
        if (!animation.IsPlaying("boss1fir"))
        {
            animation.Play("Boss2_move");
        }

        if (HP > 0)
            HB.SetHP((float)HP / (float)2200);
        else
            HB.SetHP(0f);

        if (stage_1)
        {
            if (Time.time >= fire && BossDead == false)
            {
                if (gameObject != null)
                {
                    fire = Time.time + 1.05f;

                    Transform bullet1 = Instantiate(bul, new Vector3(transform.position.x + 0.8f, transform.position.y - 2.3f, transform.position.z), transform.rotation);
                    Transform bullet3 = Instantiate(bul, new Vector3(transform.position.x - 0.8f, transform.position.y - 2.3f, transform.position.z), transform.rotation);

                    bullet1.tag = "Bullet22";
                    bullet3.tag = "Bullet22";

                    bullet1.gameObject.SetActive(true);
                    bullet3.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (Time.time >= fire && BossDead == false)
            {
                if (gameObject != null)
                {
                    fire = Time.time + 0.85f;

                    Transform bullet = Instantiate(bul2, new Vector3(transform.position.x + 0.8f, transform.position.y - 2.3f, transform.position.z), transform.rotation);
                    Transform bullet2 = Instantiate(bul2, new Vector3(transform.position.x - 0.8f, transform.position.y - 2.3f, transform.position.z), transform.rotation);

                    bullet.SetParent(this.transform);
                    bullet2.SetParent(this.transform);
                    bullet.gameObject.SetActive(true);
                    bullet2.gameObject.SetActive(true);
                }
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet1")
        {
            StartCoroutine(PlayHurt());
            HP = HP - 10 - Player.ExtraDamage;
        }

        if (collision.gameObject.tag == "Bullet2")
        {
            StartCoroutine(PlayHurt());
            HP = HP - 20 - Player.ExtraDamage;
        }

        if (collision.gameObject.tag == "Bullet3")
        {
            StartCoroutine(PlayHurt());
            HP = HP - 12 - Player.ExtraDamage;
        }

        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(PlayHurt());
        }

        if (collision.gameObject.tag == "Bullet444" || collision.gameObject.tag == "Bullet4")
        {
            StartCoroutine(PlayHurt());
            HP = HP - 50 - Player.ExtraDamage;
        }

        if (HP <= 0)
        {
            Death();
        }

        if (HP < 1100)
        {
            stage_1 = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(PlayHurt());
            HP -= 3 + (Player.ExtraDamage / 5);
        }

        if (HP <= 0)
        {
            Death();
        }

        if (HP < 1100)
        {
            stage_1 = false;
        }
    }
    

    private void Death()
    {
        MusicManager.Instance.PlayGameplayMusic();

        int p = scr.GetScore();

        p += 1200;

        scr.SetScore(p);

        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;

        BossDead = true;

        Transform b = Instantiate(bonus[k].transform, this.transform.position, new Quaternion(0,0,0,1));
        b.gameObject.SetActive(true);
        b.parent = null; 
        GameObject newObject = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation) as GameObject;
        newObject.transform.localScale = new Vector3(2, 2, 2);
        Destroy(gameObject);
    }

    
    private IEnumerator PlayHurt()
    {
        Color red = new Color(1, 0.5f, 0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = red;
        yield return new WaitForSeconds(0.07f);
        gameObject.GetComponent<SpriteRenderer>().color = origColor;
        yield return new WaitForSeconds(0.07f);
        gameObject.GetComponent<SpriteRenderer>().color = red;
        yield return new WaitForSeconds(0.07f);
        gameObject.GetComponent<SpriteRenderer>().color = origColor;
    }
}
