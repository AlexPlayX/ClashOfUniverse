using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSettingsMenu : MonoBehaviour
{
    public Slider Music,
                  Weapon,
                  Explosion;

    public Button Accept, Back;
    void Start()
    {
        Back.onClick.AddListener(() => ButtonClicked(0));
        Accept.onClick.AddListener(() => ButtonClicked(1));
    }
    private void ButtonClicked(int button)
    {
        switch (button)
        {
            case 0:
                {
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }; break;
            case 1:
                {
                    
                }; break;
        }
    }
}
