using System.Collections;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) StartCoroutine(ReplacePlayer(collision));
    }

    private IEnumerator ReplacePlayer(Collision2D collision)
    {
        yield return new WaitForSeconds(1f);
        collision.gameObject.transform.position = CurrentSceneManager.instance.respawnPoint;
    }
}
