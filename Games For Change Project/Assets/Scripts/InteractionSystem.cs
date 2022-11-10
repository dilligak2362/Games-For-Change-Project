using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionSystem : MonoBehaviour
{
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 6.0f;
    //Detection Layer
    public LayerMask detectionLayer;
    //Cached Trigger Object
    public GameObject detectedObject;

<<<<<<< HEAD
    //SceneManager
    public GameObject SceneManager;
    public GameObject Player;

=======
<<<<<<< Updated upstream
=======
    //SceneManager
    public GameObject SceneManager;
    public GameObject Player;
    public GameObject Wall;


>>>>>>> Stashed changes
>>>>>>> Kylen---Platforming-Programmers-Branch-
    void Update()
    {
        if (DetectObject() && !SceneManager.GetComponent<SceneManager>().dialogueStarted && !SceneManager.GetComponent<SceneManager>().dialogueEnded)
        {
<<<<<<< HEAD
            StartCoroutine(delay());
        }

        if (SceneManager.GetComponent<SceneManager>().dialogueEnded == true)
        {
            Destroy(detectedObject);
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
=======
<<<<<<< Updated upstream
            if (InteractInput())
            {
                Debug.Log("INTERACT");
                detectedObject.GetComponent<Item>().Interact();
            }
=======
            Destroy(detectedObject);
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Wall.SetActive(false);
>>>>>>> Stashed changes
>>>>>>> Kylen---Platforming-Programmers-Branch-
        }
    }

    /*
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);

    }
    */

    IEnumerator delay()
    {
        yield return new WaitForSeconds(.5f);
        Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        SceneManager.gameObject.GetComponent<SceneManager>().ActivateMicInstructions();
    }

    bool DetectObject()
    {

        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}