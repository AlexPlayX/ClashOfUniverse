using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlPauseMenu : MonoBehaviour
{

   
    public Button backButton, exitButton;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(() => ButtonClicked(1));
        exitButton.onClick.AddListener(() => ButtonClicked(2));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ButtonClicked(1);
        }
    }
    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
        switch (buttonNo)
        {
            case 1:
                {
                    Cursor.visible = false;
                    //MusicManager.Instance.PlayMusic();
                    pause.SetActive(false);
                    Time.timeScale = 1;
                    Objects.isPaused = false;
                    
                }; break;
            case 2:
                {
                    Objects.isPaused = false;
                    Time.timeScale = 1;
                   
                    //MusicManager.Instance.PlayMenuMusic();
                    SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                }; break;
        }
    }




}
