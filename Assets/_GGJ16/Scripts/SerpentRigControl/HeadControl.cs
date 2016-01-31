using UnityEngine;
using System.Collections;

namespace Serpent{
	public class HeadControl : MonoBehaviour {
        public static HeadControl main;
        float seed;
        public float speed = 15;
        public float turnRadius = 150;
		// Use this for initialization
		void Awake () {
            main = this;
            seed = Random.Range(0.0f, 8000.0f);
		}
		
		// Update is called once per frame
		void Update () {
            transform.position += transform.forward*Time.deltaTime*speed;
            if (_Root.flyingPlayer == null)
            {
                AI();
            }
		}
        void AI()
        {
            float deg = Mathf.PerlinNoise(0, seed+Time.time*0.4f)*Mathf.PI*2;
            Vector3 dir = new Vector3(Mathf.Sin(deg), 0, -Mathf.Cos(deg));
            Move(dir);
        }
        public void Move (Vector3 dir){
            if (dir.magnitude < 0.1f) return;
            dir.Normalize();
            Quaternion target = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,target,turnRadius*Time.deltaTime);
        }
        void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            _Root.flyingPlayer.score++;
        }
	}
}

