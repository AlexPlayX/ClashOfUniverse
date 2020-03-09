using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    public Button
        startGame,
        records,
        settings,
        exit;
    void Start()
    {
        startGame.onClick.AddListener(() => ButtonClicked(1));
        
        settings.onClick.AddListener(() => ButtonClicked(2));
        exit.onClick.AddListener(() => ButtonClicked(3));
        records.onClick.AddListener(() => ButtonClicked(4));
    }
    void ButtonClicked(int button)
    {
        Debug.Log("ButtonChoose" + button);
        switch (button)
        {
            case 1:
                {
                    SceneManager.LoadScene("ChooseShip", LoadSceneMode.Single);
                }; break;
           
            case 2:
                {
                    SceneManager.LoadScene("Settings", LoadSceneMode.Single);
                }; break;
            case 3:
                {
                    GameObject.Find("EventSystem").SetActive(false);
                    SceneManager.LoadScene("Exit", LoadSceneMode.Additive);
                }; break;
           case 4:
                {
                    SceneManager.LoadScene("Records", LoadSceneMode.Single);
                }; break;
        }
    }
}
