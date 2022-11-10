using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public bool dialogueEnded;  //used for the interaction script to know when to unfreeze character, activate animation and deactivate the soul;
                               //that script should then set this bool to false
    public bool useFragments; //used for the interaction script to know when to drop the soul fragment count; that script should then set this bool to false
                              //also tells another script to change ghost to character
    public bool dialogueStarted;
    private bool micStarted;
    private bool volumeFirstReached;
    public TextMeshProUGUI micInstructions;
    public GameObject volumeBar;
    public TextMeshProUGUI micTimer;
    public GameObject[] dialogueControllerHolder = new GameObject[3];
    public int dialogueIterate = 0;

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if(micStarted == true)
        {
            if (volumeBar.transform.GetChild(0).gameObject.GetComponent<MicManipulateScale>().loudnessLerp.y >= 0.8f && !volumeFirstReached)
            {
                StartCoroutine(Timer());
            }
            else if (volumeBar.transform.GetChild(0).gameObject.GetComponent<MicManipulateScale>().loudnessLerp.y < 0.4f && volumeFirstReached)
            {
                StopCoroutine(Timer());
                micTimer.gameObject.SetActive(false);
                volumeFirstReached = false;
            }
        }
    }

    IEnumerator InitialInstructions()
    {
        micInstructions.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        micInstructions.gameObject.SetActive(false);
        volumeBar.gameObject.SetActive(true);
        micStarted = true;
    }

    IEnumerator Timer()
    {
        volumeFirstReached = true;
        micTimer.gameObject.SetActive(true);
        micTimer.text = "Hold for 3";
        yield return new WaitForSeconds(1);
        micTimer.text = "Hold for 2";
        yield return new WaitForSeconds(1);
        micTimer.text = "Hold for 1";
        yield return new WaitForSeconds(1);
        micStarted = false;
        micTimer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //initiate the soul fragment animation #1 here

        useFragments = true; //signal to drop fragment/coin count - also tells another script to change ghost to character
        volumeBar.SetActive(false);

        //activate dialogue box...
        dialogueControllerHolder[dialogueIterate].SetActive(true);
        dialogueControllerHolder[dialogueIterate].GetComponent<Dialogue>().dialogueController();
    }
    

    public void ActivateMicInstructions() //used for the interaction script to call
    {
        StartCoroutine(InitialInstructions());
        dialogueStarted = true;
    }



    /*
     * freezes character in place (or this can maybe be done when you interact in the interact script)
     * have interact script set dialogue ended bool as false; do the activate mic instructions and keep player frozen until dialogue ended bool is true
     * activates and deactivates text that will say "Sing into your mic to fill up the voice-to-soul meter!"
     * activates mic-manipulated object
     * using mic-manipulated object; if it's a certain size, trigger counter for 3 seconds on screen, then trigger soul fragment animation** (#1) 
     * and drop soul fragment count down to 0
     * ghost sprite becomes character sprite with idle animation - Kylen - is handling the ghosts i believe
     * deactivate mic-manipulated object
     * 
     * activate dialogue box and text with dialogue script that will start on its own and
     * continue with user input
     * after dialogue's while loop is done, it will change a boolean that the manager will keep
     * track of in update; this will allow us to close the dialogue box and trigger an animation
     * where the soul is disintegrated - animation** (#2)
     * deactivate the soul
     * tells the interact script to unfreeze the player's movements - dialogue ended bool is true now
     */
}
