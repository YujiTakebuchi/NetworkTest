using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TurnController : NetworkBehaviour {
	public int id;
//	public bool isMyTurn;
	public int currentId;
	ServerController sc = new ServerController();
	// Use this for initialization
	void Start () {
		generateId ();
	}
	
	// Update is called once per frame
	[ClientCallback]
	void Update () {
		currentId = ServerController.currentPlayerId;
		// 自分のクライアント以外の操作を受け付けない
		if (!isLocalPlayer) {
			return;
		}

		// 自分のターンの場合
		if (confirmMyTurn()) {
			CmdDoInMyTurn ();
		}
	}

	[ServerCallback]
	private void generateId () {
		id = ServerController.id++;
		ServerController.ids.Add (id);
	}

	[ClientCallback]
	private bool confirmMyTurn() {
		return ServerController.currentPlayerId == id;
	}

	[ClientCallback]
	private void CmdDoInMyTurn () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("俺" + id + ": 俺のターン！ドロー！");
			sc.next ();
		}
	}
}
