using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionSystem : MonoBehaviour
{
    //Detection Point
    public Transform detectionPoint;
    //Detection Radius
    private const float detectionRadius = 0.2f;
    //Detection Layer
    public LayerMask detectionLayer;
    //Cached Trigger Object
    public GameObject detectedObject;

<<<<<<< Updated upstream
=======
    //SceneManager
    public GameObject SceneManager;
    public GameObject Player;
    public GameObject Wall;


>>>>>>> Stashed changes
    void Update()
    {
        if (DetectObject())
        {
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
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);

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