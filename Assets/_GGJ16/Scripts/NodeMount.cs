using UnityEngine;
using System.Collections;

public class NodeMount : MonoBehaviour {
    void Awake()
    {
        _Root.mountedNode = gameObject;
    }
}
