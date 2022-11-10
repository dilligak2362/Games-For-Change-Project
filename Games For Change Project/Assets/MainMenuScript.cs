using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Image instructionsBg;

    public Button startButtonObject, InstructionsButtonObject, QuitButtonObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void InstructionsButton()
    {
        instructionsBg.gameObject.SetActive(true);

        startButtonObject.gameObject.SetActive(false);
        InstructionsButtonObject.gameObject.SetActive(false);
        QuitButtonObject.gameObject.SetActive(false);
    }

    public void CloseInstructionsButton()
    {
        startButtonObject.gameObject.SetActive(true);
        InstructionsButtonObject.gameObject.SetActive(true);
        QuitButtonObject.gameObject.SetActive(true);

        instructionsBg.gameObject.SetActive(false);
    }
}
