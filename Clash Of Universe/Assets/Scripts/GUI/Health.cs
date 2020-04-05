using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private RectTransform hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("hp").GetComponent<RectTransform>();
        hp.localScale = new Vector3(1f, 1f);
    }
    public void SetHP(float percentHP)
    {
        hp.localScale = new Vector3(1f, percentHP);
    }
}