using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

namespace GDs
{
	[Serializable]
	public class C_Int : SerializableDictionaryBase<char, int> { }
	[Serializable]
	public class G_Int : SerializableDictionaryBase<Gradient, int> { }

	[Serializable]
	public class I_GO : SerializableDictionaryBase<int, GameObject> { }
	[Serializable]
	public class GO_I : SerializableDictionaryBase<GameObject, int> { }

	[Serializable]
	public class S_GO : SerializableDictionaryBase<string, GameObject> { }
	[Serializable]
	public class GO_S : SerializableDictionaryBase<GameObject, string> { }

	[Serializable]
	public class S_Mat : SerializableDictionaryBase<string, Material> { }
	[Serializable]
	public class Mat_S : SerializableDictionaryBase<Material, string> { }

	[Serializable]
	public class S_AC : SerializableDictionaryBase<string, AudioClip> { }
	[Serializable]
	public class AC_S : SerializableDictionaryBase<AudioClip, string> { }

	[Serializable]
	public class S_Sprite : SerializableDictionaryBase<string, Sprite> { }

	[Serializable]
	public class V3_Q : SerializableDictionaryBase<Vector3, Quaternion> { }
	[Serializable]
	public class Q_V3 : SerializableDictionaryBase<Quaternion, Vector3> { }
}

