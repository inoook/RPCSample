using UnityEngine;
using System.Collections;

public class ViewConnector : MonoBehaviour {

	public ViewB viewB;
	
	public void SelectContent(int id){
		viewB.SelectContent(id);

		if (Network.peerType == NetworkPeerType.Server) {
			RPCSender.instance.SendFunctionWithInt(this.name, "SelectContent", id);
		}
	}
}
