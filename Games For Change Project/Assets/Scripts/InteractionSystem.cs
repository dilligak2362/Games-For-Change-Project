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

    //SceneManager
    public GameObject SceneManager;
    public GameObject Player;
    public GameObject Wall;

    void Update()
    {
        if (DetectObject() && !SceneManager.GetComponent<SceneManagerScript>().dialogueStarted && !SceneManager.GetComponent<SceneManagerScript>().dialogueEnded)
        {
            StartCoroutine(delay());
        }

        if (SceneManager.GetComponent<SceneManagerScript>().dialogueEnded == true)
        {
            Destroy(detectedObject);
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Player.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Wall.SetActive(false);
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
        SceneManager.gameObject.GetComponent<SceneManagerScript>().ActivateMicInstructions();
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

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
    */
}