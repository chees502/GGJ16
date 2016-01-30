using UnityEngine;
using System.Collections;

public class HairSpawner : MonoBehaviour {
    public int chainLength = 5;
    public float chainSpace = 0.01f;
	void Awake () {
        GameObject lastGO = new GameObject();
        GameObject zero = new GameObject();
        LineRenderer lr = zero.AddComponent<LineRenderer>();
        zero.transform.position = Vector3.zero;
        lr.SetVertexCount(chainLength);
        for (int x = 0; x < chainLength; x++)
        {
            GameObject tempGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tempGO.transform.position = new Vector3(0, x * -chainSpace, 0);
            tempGO.layer = LayerMask.NameToLayer("Ignore Raycast");
            DestroyImmediate(tempGO.GetComponent<BoxCollider>());
            tempGO.name = "Joint " + x;
            tempGO.AddComponent<Rigidbody>();
            tempGO.GetComponent<MeshRenderer>().enabled = false;
            HairDrawer hd = tempGO.AddComponent<HairDrawer>() as HairDrawer;
            hd.SetValues(lr, x);
            if (x != 0)
            {
                HingeJoint hinge = tempGO.AddComponent<HingeJoint>();
                hinge.connectedBody = lastGO.GetComponent<Rigidbody>();
                //tempGO.transform.localScale=new Vector3(0.1f,0.1f,0.1f);
                hinge.anchor = new Vector2(0, chainSpace);
                hinge.connectedAnchor = new Vector2(0, -chainSpace);

            }
            else
            {
                //SetToPlayer(tempGO);
                tempGO.transform.localPosition = new Vector3();
                tempGO.GetComponent<Rigidbody>().isKinematic = true;
            }
            lastGO = tempGO;

        }
	}
}
