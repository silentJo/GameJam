using UnityEngine;
using UnityEngine.UI;

public class ManageItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    [SerializeField] private Item item;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.E) && */isInRange)
        {
            TakeItem();
        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        /*
         * Apply effect ?
         */
        Inventory.instance.UpdateInventoryUI();
        interactUI.enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
