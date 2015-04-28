using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NetworkView))]
public class NetworkViewConnector : MonoBehaviour {
	
	public string connectToIP = "127.0.0.1";
	public int connectPort = 25001;
	public int sendRate = 15;
	
	public bool isServer;
	
	public bool autoConnect = false;
	
	void Start()
	{
		if(autoConnect){
			if(isServer){
				connectAsServer();
			}else{
				connectAsClient();
			}
		}
	}
	
	//
	public void connectAsServer()
	{
		Network.InitializeServer(5, connectPort, false);
		
		isServer = true;
	}
	
	public void connectAsClient()
	{
		Debug.Log("connectAsClient");
		isServer = false;

		NetworkConnectionError error = Network.Connect(connectToIP, connectPort);
		Debug.Log("connectAsClient: "+ error);
	}

	private void autoReconnect()
	{
		if(!isServer){
			Invoke("connectAsClient", 4);
		}
	}
	
	// NONE of the functions below is of any use in this demo, the code below is only used for demonstration.
	// First ensure you understand the code in the OnGUI() function above.
	
	//Client functions called by Unity
	void OnConnectedToServer() {
		Debug.Log("This CLIENT has connected to a server");	
	}
	
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		Debug.Log("This SERVER OR CLIENT has disconnected from a server: " + info);
		
		autoReconnect();
	}
	
	void OnFailedToConnect(NetworkConnectionError error){
		Debug.Log("Could not connect to server: "+ error);
		
		autoReconnect();
	}
	
	
	//Server functions called by Unity
	void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Player connected from: " + player.ipAddress +":" + player.port);
	}
	
	void OnServerInitialized() {
		Debug.Log("Server initialized and ready");
	}
	
	void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Player disconnected from: " + player.ipAddress+":" + player.port);
	}
	
	
	// OTHERS:
	// To have a full overview of all network functions called by unity
	// the next four have been added here too, but they can be ignored for now
	
	void OnFailedToConnectToMasterServer(NetworkConnectionError info){
		Debug.Log("Could not connect to master server: "+ info);
	}
	
	void OnNetworkInstantiate (NetworkMessageInfo info ) {
		Debug.Log("New object instantiated by " + info.sender);
	}
	
	void OnSerializeNetworkView(BitStream stream , NetworkMessageInfo info )
	{
		//Custom code here (your code!)
	}
	
	/* 
	 The last networking functions that unity calls are the RPC functions.
	 As we've added "OnSerializeNetworkView", you can't forget the RPC functions 
	 that unity calls..however; those are up to you to implement.
	 
	 @RPC
	 function MyRPCKillMessage(){
		//Looks like I have been killed!
		//Someone send an RPC resulting in this function call
	 }
	*/
}
