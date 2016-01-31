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
		public bool is_x_forward;
		public bool isHeadInit;
		// Use this for initialization
		void Awake(){
			
		}

		void Start () {
			range = 0.5f;
			speed = 3;
			if (index == 0) {
				puppetJoint.Rotate (180, 180, 0);
			}
		}
		
		// Update is called once per frame
		void Update () {
		//	puppetJoint.position = transform.position;
		//	puppetJoint.rotation = transform.rotation;
			if (prevJoint != null ||
			   index > 0) {
				MoveMe ();
			//	puppetJoint.rotation = transform.rotation * rotOffset;//Quaternion.Euler (0, 180, 0);// (-90, -90, 0);
			//	puppetJoint.localRotation = transform.rotation * rotOffset;
			}
			if (this.index == 0) {
				transform.Rotate (0,Mathf.Sin (Time.time*speed)*range, 0);

			}

		}

		public void SetOffset(Transform puppet){
		//	rotOffset = Quaternion.FromToRotation(transform.forward, transform.up);
			rotOffset = Quaternion.Euler(90,0,-90);
			puppet.transform.parent = null;
			puppet.transform.parent = transform;
			Debug.Log (rotOffset);
		}
		void MoveMe(){
			transform.LookAt (prevJoint);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (prevJoint.forward), jointRotateSpeed * Time.deltaTime);
			Vector3 desiredPos = prevJoint.position - (transform.forward.normalized * spacing);
			//transform.position = Vector3.Lerp (transform.position, desiredPos, Time.deltaTime);
				//(prevJoint.forward*-1) + transform.forward.normalized * spacing;
//			transform.position = desiredPos;
			transform.position = desiredPos; 
		//	LineDebug (puppetJoint);

		}

		void LineDebug(Transform pos){
			Debug.DrawLine (pos.position, pos.position + pos.forward * 0.2f, Color.blue);
			Debug.DrawLine (pos.position, pos.position + pos.up * 0.2f, Color.green);
			Debug.DrawLine (pos.position, pos.position + pos.right * 0.2f, Color.red);
		}
	}
}
