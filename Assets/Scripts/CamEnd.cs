using UnityEngine;
using System.Collections;

public class CamEnd : MonoBehaviour {

	public void OnAnimationEnd() {
		AnimationCam.instance.DestroyCamera(gameObject);
	}
}
