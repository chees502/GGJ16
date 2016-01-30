using UnityEngine;
using System.Collections;

public class NodeRespawn : MonoBehaviour {
    void Awake()
    {
        _Root.respawnNode = gameObject;
    }
}
