using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ControlNameMenu : MonoBehaviour
{
    public Button back, accept;
    public InputField input;
    private EventSystem eventSystem;
    void Start()
    {
        eventSystem = EventSystem.current;
        back.onClick.AddListener(() => ButtonClicked(1));
        accept.onClick.AddListener(() => ButtonClicked(2));
    }
    void Update()
    {
        if (input.isFocused && Input.GetKey(KeyCode.Return))
        {
            eventSystem.SetSelectedGameObject(accept.gameObject);
        }
    }
    void ButtonClicked(int button)
    {
        Debug.Log("Button clicked = " + button);
        switch (button)
        {
            case 1:
                {
                    SceneManager.LoadScene("ChooseShip", LoadSceneMode.Single);
                }; break;
            case 2:
                {
                    if (input.text != "")
                    {
                        Cursor.visible = false;
                        SceneManager.LoadScene("GameProcess", LoadSceneMode.Single);
                    }
                    else
                        eventSystem.SetSelectedGameObject(input.gameObject);
                }; break;
        }
    }
}
