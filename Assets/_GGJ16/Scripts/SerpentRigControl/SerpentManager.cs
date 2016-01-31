using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Serpent{
	public class SerpentManager : MonoBehaviour {

		IList<Transform> joints;
		Transform head;
		public bool is_x_forward;
		public bool findJoints;
		int indexer;

		public string jointPrefix;
		public float jointRotateSpeed;
		// Use this for initialization
		void Start () {
			indexer = 0;
			joints = new List<Transform> ();
			is_x_forward = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (findJoints) {
				FindAllJoints (jointPrefix);
				findJoints = false;
			}
		}

		void FindAllJoints(string jointName){
			Transform[] children = gameObject.transform.GetComponentsInChildren<Transform> ();
			for(int i = 0; i < children.Length; i++){

				Transform puppet = children[i];
				if (puppet.name.Contains (jointName)) {
					GameObject go = new GameObject ("joint_master_" + indexer);
					Transform trans = go.transform;
					trans.position = puppet.position;
					JointControl joint = trans.gameObject.AddComponent<JointControl> () as JointControl;
					joint.puppetJoint = puppet;
					joint.SetOffset (puppet);
					joint.jointRotateSpeed = jointRotateSpeed;
					joint.index = indexer;
					if (indexer == 0) {
						trans.gameObject.AddComponent<HeadJoint> ();
						trans.gameObject.AddComponent<HeadControl> ();
					//	trans.Rotate (0, 180, 0);
					}
					if (indexer > 0) {
						joint.prevJoint = joints [indexer - 1];
						joint.spacing = Vector3.Distance (trans.position, joint.prevJoint.position);
					}
					indexer++;
					joints.Add (trans);
				}
			}
		}
	}
}
