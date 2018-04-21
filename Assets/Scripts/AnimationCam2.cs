using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AnimationCam2 : MonoBehaviour {

	public static AnimationCam2 instance = null;

	[SerializeField] private List<GameObject> cameras2 = new List<GameObject>();

	// Use this for initialization
	void Start () {

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void StartNextCamera() {
		cameras2[0].SetActive(true);
	}

	public void DestroyCamera(GameObject camera) {
		cameras2.RemoveAt(0);
		Destroy(camera);
		StartNextCamera();

	}
}
