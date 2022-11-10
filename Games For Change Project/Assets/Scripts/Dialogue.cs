using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is to parse through each block of dialogue

public class Dialogue : MonoBehaviour
{
    public GameObject[] fullList = new GameObject[2]; //need to know how many dialogue blocks there will be; 2 is just a placeholder number
    public GameObject dialogueBox;
    public GameObject SceneManager;
    public bool textBlockDone = true;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i < fullList.Length)
        {
            if (!fullList[i].gameObject.GetComponent<FullText>().coroutineStarted && textBlockDone)
            {
                fullList[i].SetActive(true);
                textBlockDone = false;
                fullList[i].gameObject.GetComponent<FullText>().StartShowText();
            }
            if (!textBlockDone && Input.GetKeyDown(KeyCode.Return))
            {
                fullList[i].SetActive(false);
                i++;
                textBlockDone = true;
            }
        }
        else
        {
            dialogueBox.SetActive(false);
            SceneManager.GetComponent<SceneManagerScript>().dialogueIterate++;
            SceneManager.GetComponent<SceneManagerScript>().dialogueEnded = true;
            SceneManager.GetComponent<SceneManagerScript>().dialogueStarted = false;
            gameObject.SetActive(false);
        }
    }

    public void dialogueController()
    {
        dialogueBox.SetActive(true);
    }

    /*
     * there is an array of fullTexts that contain each box of dialogue for a character.
     * have a while loop go through the fullTexts[]; while iteration i that you define 
     * before is not greater than fullTexts[].length.
     * do the type writer effect as used in the tutorial https://youtu.be/1qbjmb_1hV4
     * if(user clicks a certain key AND letters are done loading) then iteration i ++ for the while loop to
     * load in the next full text set
     * after the while loop, dialogue box should close and spirit should disintegrate (animation) - this can
     * be done in the scene manager
     */
}
