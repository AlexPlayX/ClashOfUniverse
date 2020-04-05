using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
    }
    // Update is called once per frame
    public void SetScore(int value)
    {
        score.text = value.ToString();
    }

    public int GetScore()
    {
        int s = int.Parse(score.text);
        return s;
    }
}
