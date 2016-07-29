using UnityEngine;
using System.Collections;

public class ShellCollision : MonoBehaviour {
    private string m_type;
	void Start () {
	
	}

    public void setType(string type) {
        m_type = type;
    }

	void Update () {
	
	}

    public void OnCollisionEnter(Collision collision) {
        string TargetName = collision.rigidbody.name;
        Debug.Log("shoot----" + TargetName);
        if (TankMove.TYPE_PLAYER == m_type) {
            if (!TargetName.StartsWith("Edge")) {

            }
            Destroy(this);
        }
    }
}
