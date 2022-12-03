using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    public BoxCollider2D topCollider;

    private PlayerMovement playerMovement;
    private Text interactUI;

    private bool isInRange;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isInRange && (Input.GetKey("z") || Input.GetKey("s")))
        {
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
        } else if(!isInRange)
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
        }
    }
}