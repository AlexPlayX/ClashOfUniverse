using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlRecordsMenu : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(() => ButtonClicked());
    }

    // Update is called once per frame
    void ButtonClicked()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
