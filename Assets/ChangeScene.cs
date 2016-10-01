using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Portal1Game", LoadSceneMode.Single);
        }

        if (other.gameObject.CompareTag("Portal 2"))
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("Portal2Game", LoadSceneMode.Single);
        }
    }
}
