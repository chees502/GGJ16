using UnityEngine;
using System.Collections;

namespace Serpent{
	public class JointControl : MonoBehaviour {

		public int index;
		public Transform prevJoint;
		public Transform puppetJoint;
		Quaternion rotOffset;

		public float spacing;
		public float range;
		public float speed;

		// Use this for initialization
		void Start () {
			range = 0.5f;
			speed = 3;

		}
		
		// Update is called once per frame
		void Update () {
			puppetJoint.position = transform.position;
			if (prevJoint != null ||
			   index > 0) {
				MoveMe ();
			}
			if (this.index == 0) {
				transform.Rotate (0, Mathf.Sin (Time.time*speed)*range, 0);

			}
		//	puppetJoint.rotation = transform.rotation.
		}

		public void SetOffset(Transform puppet){
			rotOffset = Quaternion.FromToRotation (transform.forward*-1, transform.forward);
			Debug.Log (rotOffset);
		}
		void MoveMe(){
			transform.LookAt (prevJoint);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (prevJoint.forward), Time.deltaTime);
			Vector3 desiredPos = prevJoint.position - (transform.forward.normalized * spacing);
			//transform.position = Vector3.Lerp (transform.position, desiredPos, Time.deltaTime);
				//(prevJoint.forward*-1) + transform.forward.normalized * spacing;
//			transform.position = desiredPos;
			transform.position = desiredPos;
		}
	}
}
