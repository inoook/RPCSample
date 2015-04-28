# RPCSample
unity3dでのrpcサンプル。

RPCを若干使いやすくしたもの。
RPCSender.instance.SendFunctionWithInt(gameObjectName, methodName, id);
のように内部でゲームオブジェクトと関数を指定して、関数をコールする。

基本的には、メインマシンからサブマシンへの関数呼び出しのみを想定。

unity5.0.1f1
