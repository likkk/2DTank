using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour{
    private GameObject BornPoint;
    private GameObject m_tank;


    public Tank(GameObject point, string type) {
        BornPoint = point;
        m_tank = GameObject.Instantiate(GameManage.instance.TankPrefab,
            BornPoint.transform.position, BornPoint.transform.rotation) as GameObject;
        //m_tank.transform.localScale = BornPoint.transform.localScale;
        m_tank.AddComponent<TankMove>();
        ((TankMove)m_tank.transform.GetComponent<TankMove>()).setType(type);
        m_tank.GetComponent<Rigidbody>().AddForce(m_tank.transform.forward);
    }

    public GameObject getTank() {
        return m_tank;
    }
}
