using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this is for each block of dialogue

public class FullText : MonoBehaviour
{
    public float delay = 0.03f;
    public string fullTextTM;
    private string currentText = "";
    public TextMeshProUGUI textDisplay;
    public bool coroutineStarted;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowText() //shows each letter one by one in the dialogue block
    {
        coroutineStarted = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < fullTextTM.Length; i++)
        {
            currentText = fullTextTM.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        coroutineStarted = false;
    }

    public void StartShowText()
    {
        StartCoroutine(ShowText());
    }
}
