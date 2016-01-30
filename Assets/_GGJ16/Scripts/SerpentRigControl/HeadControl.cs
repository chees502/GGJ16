using UnityEngine;
using System.Collections;

namespace Serpent{
	public class HeadControl : MonoBehaviour {
        public static HeadControl main;

        public float speed = 15;
        public float turnRadius = 150;
		// Use this for initialization
		void Awake () {
            main = this;
		}
		
		// Update is called once per frame
		void Update () {
            transform.position += transform.forward*Time.deltaTime*speed;
		}
        public void Move (Vector3 dir){
            if (dir.magnitude < 0.1f) return;
            dir.Normalize();
            Quaternion target = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,target,turnRadius*Time.deltaTime);
        }
	}
}

