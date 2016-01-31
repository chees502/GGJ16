using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HairManager : MonoBehaviour {

	int indexer;
	public string hairJointPrefix;
	IList<Transform> joints;

	public bool init;
	// Use this for initialization
	void Start () {
		indexer = 0;
		joints = new List<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (init) {
			FindAllJoints (hairJointPrefix);
			init = false;
		}
	}
	void FindAllJoints(string jointName){
		Transform[] children = gameObject.transform.GetComponentsInChildren<Transform> ();
		for(int i = 0; i < children.Length; i++){

			Transform puppet = children[i];
			if (puppet.name.Contains (jointName)) {
				Debug.Log ("found");
				HairJoint joint = puppet.gameObject.AddComponent<HairJoint> () as HairJoint;

				joint.index = indexer;

				if (indexer > 0) {
					joint.prevJoint = joints [indexer - 1];
					joint.spacing = Vector3.Distance (puppet.position, joint.prevJoint.position);
				}
				indexer++;
				puppet.parent = null;
				joints.Add (puppet);
			}
		}
	}
}
