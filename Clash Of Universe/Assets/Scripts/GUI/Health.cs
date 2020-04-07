using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private RectTransform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("Panel").GetComponent<RectTransform>();
        bar.localScale = new Vector3(1f, 1f);
    }
    public void SetHP(float percentHP)
    {
        bar.localScale = new Vector3(1f, percentHP);
    }
}