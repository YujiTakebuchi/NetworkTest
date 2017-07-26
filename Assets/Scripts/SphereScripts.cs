using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SphereScripts : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	[ClientCallback]
	void Update () {
		if (!isLocalPlayer) {
			return;
		}
		// カメラ位置調整
		Vector3 v = transform.position;
		v.z -= 5;
		v.x += 3;
		Camera.main.transform.position = v;
	}

	[ClientCallback]
	void FixedUpdate () {
		if (!isLocalPlayer) {
			return;
		}
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		CmdMoveSphere (x, z);
	}

	[Command]
	public void CmdMoveSphere (float x, float z) {
		Vector3 v = new Vector3 (x, 0, z) * 10f;
		GetComponent<Rigidbody> ().AddForce (v);
	}
}
