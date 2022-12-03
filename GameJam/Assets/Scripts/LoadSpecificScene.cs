using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) StartCoroutine(loadNextScene());
    }

    public IEnumerator loadNextScene()
    {
        LoadAndSaveData.instance.SaveData();
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(sceneName);
    }
}
