using UnityEngine;
using System.Collections;

// http://docs.unity3d.com/Documentation/ScriptReference/NetworkView.RPC.html

[RequireComponent (typeof (NetworkView))]
public class RPCSender : MonoBehaviour {
	
	public static RPCSender instance;
	
	void Awake ()
	{
		if(instance == null){
			instance = this;
		}else{
			Debug.LogWarning("RPCSender is Singleton");
		}
		
	    GetComponent<NetworkView>().group = 10;
	}
	
	// _refNameのついたGameObjectのmethodNameをコールする。受取り側ではSendMessageをつかっている。
	public void SendFunction(string _refName, string methodName, RPCMode rpcMode = RPCMode.Others)
	{
		if (Network.peerType != NetworkPeerType.Disconnected)
		{
			GetComponent<NetworkView>().RPC("RunFunction", rpcMode, _refName, methodName);
		}
	}
	
	[RPC]
	void RunFunction(string _refName, string name)
	{
		GameObject _refGObj = GameObject.Find(_refName);
		
		if(_refGObj != null){
			_refGObj.SendMessage(name);
		}else{
			Debug.LogWarning(_refName +" gameObject not found.");
		}
	
	}

	// string
	public void SendFunctionWithString(string _refName, string methodName, string str, RPCMode rpcMode = RPCMode.Others)
	{
		if(GetComponent<NetworkView>() == null){ return; }
		
		if (Network.peerType != NetworkPeerType.Disconnected)
		{
			GetComponent<NetworkView>().RPC("RunFunctionWithString", rpcMode, _refName, methodName, str);
		}
	}
	
	[RPC]
	void RunFunctionWithString(string _refName, string name, string str)
	{
		GameObject _refGObj = GameObject.Find(_refName);
		
		if(_refGObj != null){
			_refGObj.SendMessage(name, str);
		}else{
			Debug.LogWarning(_refName +" gameObject not found.");
		}
	}

	// int
	public void SendFunctionWithInt(string _refName, string methodName, int i, RPCMode rpcMode = RPCMode.Others)
	{
		if(GetComponent<NetworkView>() == null){ return; }
		
		if (Network.peerType != NetworkPeerType.Disconnected)
		{
			GetComponent<NetworkView>().RPC("RunFunctionWithInt", rpcMode, _refName, methodName, i);
		}
	}
	
	[RPC]
	void RunFunctionWithInt(string _refName, string name, int i)
	{
		GameObject _refGObj = GameObject.Find(_refName);
		
		if(_refGObj != null){
			_refGObj.SendMessage(name, i);
		}else{
			Debug.LogWarning(_refName +" gameObject not found.");
		}
	}

}
