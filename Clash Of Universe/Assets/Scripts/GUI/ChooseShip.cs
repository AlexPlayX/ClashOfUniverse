using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChooseShip : MonoBehaviour
{
    public Button 
        back,
        accept;
    void Start()
    {
        back.onClick.AddListener(() => ButtonClicked(1));
        accept.onClick.AddListener(() => ButtonClicked(2));
    }
    void ButtonClicked(int button)
    {
        Debug.Log("Button clicked = " + button);
        switch (button)
        {
            case 1:
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }; break;
            case 2:
                {
                    GameObject.Find("EventSystem").SetActive(false);
                    SceneManager.LoadScene("NameInput", LoadSceneMode.Additive);
                }; break;
        }
    }
}
