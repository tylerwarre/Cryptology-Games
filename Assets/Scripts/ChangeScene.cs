using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Portal1Info", LoadSceneMode.Single);
        }

        if (other.gameObject.CompareTag("Portal 2"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Portal2Info", LoadSceneMode.Single);
        }

        if (other.gameObject.CompareTag("Portal 3"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Portal3Game", LoadSceneMode.Single);
        }

        if (other.gameObject.CompareTag("Portal 4"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("GameSelect", LoadSceneMode.Single);
        }
    }
}
