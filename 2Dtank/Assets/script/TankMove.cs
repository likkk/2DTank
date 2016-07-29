using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {
    private Transform m_ParentTrans;
    Quaternion m_originalRotate;

    public GameObject PrafebShell;


    public static string TYPE_PLAYER = "tank_player";
    public static string TYPE_ENIMY = "tank_enimy";
    private string m_type;

    public float speed = 20.0f;

    public float interval_fire = 5.0f;


    void Start() {
        m_ParentTrans = GetComponentsInParent<Transform>()[0];
        InvokeRepeating("fire", 2, interval_fire);
    }

    void Update() {
        if (TYPE_PLAYER == m_type)
            checKey();
        m_ParentTrans.Translate(m_ParentTrans.forward * speed * Time.deltaTime);
    }
    public void setType(string type) {
        m_type = type;
    }

    public void fire() {
        Debug.Log("on fire" + m_type);
    }

    private void checKey() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            m_ParentTrans.rotation = m_originalRotate;
            m_ParentTrans.Rotate(new Vector3(0, -90, 0));
            Debug.Log("Left----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            m_ParentTrans.rotation = m_originalRotate;
            m_ParentTrans.Rotate(new Vector3(0, 90, 0));
            Debug.Log("Right----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            m_ParentTrans.rotation = m_originalRotate;
            Debug.Log("up----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            m_ParentTrans.rotation = m_originalRotate;
            m_ParentTrans.Rotate(new Vector3(0, 180, 0));
            Debug.Log("Down----" + m_ParentTrans.forward);
        }
    }
}
