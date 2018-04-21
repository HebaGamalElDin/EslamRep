using UnityEngine;
using System.Collections;

public class CamEnd2 : MonoBehaviour {

	public void OnAnimationEnd() {
		AnimationCam2.instance.DestroyCamera(gameObject);
	}
}

