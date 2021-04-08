using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	
	// Update is called once per frame
	public void SceneLoad (string nameScene)
    {
        SceneManager.LoadScene(nameScene);
	
	}
}
