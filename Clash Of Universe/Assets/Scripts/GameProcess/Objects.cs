using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Objects : MonoBehaviour
{
    public GameObject pause;
    public static bool isPaused;

    public GameObject gameOver;

    public static int scoreValue;
    public Score score;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = GameManager.playerName;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = true;
            Time.timeScale = 0;
            //MusicManager.Instance.PauseMusic();
            Cursor.visible = true;
            pause.SetActive(true);
            
        }


       

    }
    

    

}
