using UnityEngine;
using System.Collections;

namespace Serpent{
	public class JointControl : MonoBehaviour {

		public int index;
		public Transform prevJoint;
		public Transform puppetJoint;
		public Quaternion rotOffset;

		public float spacing;
		public float range;
		public float speed;
		public float jointRotateSpeed;

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
				puppetJoint.rotation = transform.rotation * rotOffset;//Quaternion.Euler (0, 180, 0);// (-90, -90, 0);
			}
			if (this.index == 0) {
				transform.Rotate (0, 0,Mathf.Sin (Time.time*speed)*range);

			}

		}

		public void SetOffset(Transform puppet){
			rotOffset = Quaternion.FromToRotation (transform.forward, transform.up);
			Debug.Log (rotOffset);
		}
		void MoveMe(){
			transform.LookAt (prevJoint,Vector3.forward);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (prevJoint.forward), jointRotateSpeed * Time.deltaTime);
			Vector3 desiredPos = prevJoint.position - (transform.forward.normalized * spacing);
			//transform.position = Vector3.Lerp (transform.position, desiredPos, Time.deltaTime);
				//(prevJoint.forward*-1) + transform.forward.normalized * spacing;
//			transform.position = desiredPos;
			transform.position = desiredPos; 
			LineDebug (puppetJoint);
		}

		void LineDebug(Transform pos){
			Debug.DrawLine (pos.position, pos.position + pos.forward * 0.2f, Color.blue);
			Debug.DrawLine (pos.position, pos.position + pos.up * 0.2f, Color.green);
			Debug.DrawLine (pos.position, pos.position + pos.right * 0.2f, Color.red);
		}
	}
}
