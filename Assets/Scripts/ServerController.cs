using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerController : MonoBehaviour {
	public static int id;
	public static List<int> ids = new List<int>();
	public static int currentPlayerId;
	// Use this for initialization
	void Start () {
		id = 0;
		currentPlayerId = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int first() {
		int[] arrayIds = ids.ToArray();
		return arrayIds [0];
	}

	public int last() {
		int[] arrayIds = ids.ToArray();
		return arrayIds [ids.Count - 1];
	}

	public void next() {
		if (currentPlayerId < last ()) {
			currentPlayerId++;
		} else if (currentPlayerId == last ()) {
			currentPlayerId = first ();
		} else {
			Debug.Log ("size over");
		}
	}
}
