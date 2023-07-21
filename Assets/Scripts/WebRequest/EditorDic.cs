using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorDic<Tkey, Tvalue> : MonoBehaviour
{
    public Dictionary<Tkey, Tvalue> KeyValues = new Dictionary<Tkey, Tvalue>();
}
