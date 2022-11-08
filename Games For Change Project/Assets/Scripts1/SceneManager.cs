using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * freezes character in place (or this can maybe be done when you interact in the interact script
     * activates and deactivates text that will say "Sing into your mic to fill up the voice-to-soul meter!"
     * activates mic-manipulated object
     * using mic-manipulated object; if it's a certain size, trigger soul fragment animation** (#1) 
     * and drop soul fragment count down to 0
     * reset mic-manipulated object to original parameters and deactivate it
     * activate dialogue box and text with dialogue script that will start on its own and
     * continue with user input
     * after dialogue's while loop is done, it will change a boolean that the manager will keep
     * track of in update; this will allow us to close the dialogue box and trigger an animation
     * where the soul is disintegrated - animation** (#2)
     * deactivate the soul
     * tells the interact script somehow to unfreeze the player's movements
     */
}
