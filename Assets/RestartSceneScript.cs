using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour {

	public void restartScene () {
		SceneManager.LoadScene("multitexture-test");
	}
}
