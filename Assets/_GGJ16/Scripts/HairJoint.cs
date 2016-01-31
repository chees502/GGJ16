using UnityEngine;
using System.Collections;

public class HairJoint : MonoBehaviour {

	public int index;
	public Transform prevJoint;
	public Transform puppetJoint;
	public float jointRotateSpeed;

	public float spacing;
	public float range;
	public float speed;

	// Use this for initialization
	void Start () {
		range = 0.5f;
		speed = 3;
	//	if (index == 0) {
	//		puppetJoint.Rotate (180, 180, 0);
	//	}
	}
	
	// Update is called once per frame
	void Update () {
		if (prevJoint != null ||
			index > 0) {
			MoveMe ();
		}
		if (this.index == 0) {
		//	transform.Rotate (Mathf.Sin (Time.time*speed)*range,0, 0);

		}
	}

	public void SetOffset(Transform puppet){
		//	rotOffset = Quaternion.FromToRotation(transform.forward, transform.up);
		puppet.transform.parent = null;
		puppet.transform.parent = transform;
	}

	void MoveMe(){
		transform.LookAt (prevJoint);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (prevJoint.forward), 10*Time.deltaTime);
		Vector3 desiredPos = prevJoint.position - (transform.forward.normalized * spacing);
		transform.position = Vector3.Lerp (transform.position, desiredPos, 10*Time.deltaTime);
		//(prevJoint.forward*-1) + transform.forward.normalized * spacing;
		//			transform.position = desiredPos;
		//transform.position = desiredPos;
	}
}
