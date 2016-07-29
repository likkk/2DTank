using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {
    private Transform m_ParentTrans;
    Quaternion m_originalRotate;

    public float m_shellSpeed = 50;


    public static string TYPE_PLAYER = "tank_player";
    public static string TYPE_ENIMY = "tank_enimy";
    private string m_type;

    public float speed = 20.0f;

    public float interval_fire = 5.0f;

    private const int TURN_UP = 0;
    private const int TURN_DOWN = 1;
    private const int TURN_LEFT = 2;
    private const int TURN_RIGHT = 3;


    void Start() {
        m_ParentTrans = GetComponentsInParent<Transform>()[0];
        InvokeRepeating("fire", 2, interval_fire);
    }

    void Update() {
        if (TYPE_PLAYER == m_type)
            checKey();

        m_ParentTrans.Translate(m_ParentTrans.forward * speed * Time.deltaTime, Space.World);
    }
    public void setType(string type) {
        m_type = type;
        InvokeRepeating("randomTurn", 5, 5);
    }

    public void fire() {
        //Debug.Log("on fire" + m_type);
        GameObject shell = GameObject.Instantiate(GameManage.instance.Prefab_Shell, m_ParentTrans.position + m_ParentTrans.forward * 2,
            m_ParentTrans.rotation) as GameObject;
        if (null != shell)
        shell.GetComponent<Rigidbody>().velocity = m_ParentTrans.forward * m_shellSpeed;
    }

    private void checKey() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            turnLeft();
            Debug.Log("Left----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            turnRight();
            Debug.Log("Right----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            turnUp();
            Debug.Log("up----" + m_ParentTrans.forward);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            turnDown();
            Debug.Log("Down----" + m_ParentTrans.forward);
        }

        
    }

    public void turnUp() {
        m_ParentTrans.rotation = m_originalRotate;
    }
    public void turnDown() {
        m_ParentTrans.rotation = m_originalRotate;
        m_ParentTrans.Rotate(new Vector3(0, 180, 0));
    }
    public void turnLeft() {
        m_ParentTrans.rotation = m_originalRotate;
        m_ParentTrans.Rotate(new Vector3(0, -90, 0));

    }
    public void turnRight() {
        m_ParentTrans.rotation = m_originalRotate;
        m_ParentTrans.Rotate(new Vector3(0, 90, 0));
    }

    public void turn(int direction) {
        switch (direction) {
            case TURN_UP:
                turnUp(); break;
            case TURN_DOWN:
                turnDown(); break;
            case TURN_LEFT:
                turnLeft(); break;
            case TURN_RIGHT:
                turnRight(); break;
        }
    }

    private void randomTurn() {
        turn(Random.Range(0, 3));
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("collison----" + this.name);
        if (collision.rigidbody != null) {
            switch (collision.rigidbody.name) {
                case "Edge_Up":
                    turnDown();
                    break;
                case "Edge_down":
                    turnUp();
                    break;
                case "Edge_Left":
                    turnRight();
                    break;
                case "Edge_Right":
                    turnLeft();
                    break;
            }
        }
    }
}
