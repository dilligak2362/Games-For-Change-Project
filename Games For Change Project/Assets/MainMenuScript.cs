using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Image instructionsBg;
    public Image Message;
    public Text YouNeedMic;
    public Text Quote;
    public float fadeSpeed = 1.5f;

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
        StartCoroutine("StartGame");
    }

    //m_Image.CrossFadeAlpha(0, 2.0f, false);

    IEnumerator StartGame()
    {
        Message.gameObject.SetActive(true);
        Quote.CrossFadeAlpha(1, 7.0f, false);
        YouNeedMic.CrossFadeAlpha(1, 7.0f, false);
        yield return new WaitForSeconds(7f);
        Quote.CrossFadeAlpha(0, 2.0f, false);
        YouNeedMic.CrossFadeAlpha(0, 2.0f, false);
        yield return new WaitForSeconds(2f);
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
