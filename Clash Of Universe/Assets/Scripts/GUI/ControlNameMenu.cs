using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ControlNameMenu : MonoBehaviour
{
    public Button back, submit;
    public InputField nameField;
    private EventSystem eventSystem;
    void Start()
    {
        eventSystem = EventSystem.current;
        back.onClick.AddListener(() => ButtonClicked(1));
        submit.onClick.AddListener(() => ButtonClicked(2));
    }
    void Update()
    {
        if (nameField.isFocused && Input.GetKey(KeyCode.Return))
        {
            eventSystem.SetSelectedGameObject(submit.gameObject);
        }
    }
    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
        switch (buttonNo)
        {
            case 1:
                {
                    SceneManager.LoadScene("ShipSelect", LoadSceneMode.Single);
                }; break;
            case 2:
                {
                    if (nameField.text != "")
                    {
                        Cursor.visible = false;
                        GameManager.Instance.SetPlayerName(nameField.text);
                        //MusicManager.Instance.PlayGameplayMusic();
                        SceneManager.LoadScene("GameProcess", LoadSceneMode.Single);
                    }
                    else
                        eventSystem.SetSelectedGameObject(nameField.gameObject);
                }; break;
        }
    }
}
