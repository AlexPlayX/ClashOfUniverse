using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float Speed;
    public float Size;

    private Vector3 startPosition;
    public GameObject secBackground;

    public List<Sprite> sprites;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, sprites.Count);
        GetComponent<SpriteRenderer>().sprite = sprites[i];
        secBackground.GetComponent<SpriteRenderer>().sprite = sprites[i];
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * Speed, Size);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}
