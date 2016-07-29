using UnityEngine;
using System.Collections;

public class GameManage : MonoBehaviour {
    //the point where player will born
    public GameObject PlayerPoint;
    //the points where tanks will born
    public GameObject[] TankPoint;
    //config the number of enimy    `
    public int[] LevelEnimy;
    public int PlayerLife;
    public GameObject TankPrefab;
    public float FirstAppearDelay;
    public float AppearDelay;


    [HideInInspector] public static GameManage instance = null;

    private Tank m_Player = null;
    private int MAXLIFE = 3;
    private int m_PlayerLife;

    private ArrayList m_EnimyTank = null;

    // Use this for initialization
    void Start() {
        instance = this;
        m_Player = new Tank(PlayerPoint, TankMove.TYPE_PLAYER);

        InvokeRepeating("createTank", FirstAppearDelay, AppearDelay);
    }

    // Update is called once per frame
    void Update() {

    }

    void createTank() {
        //m_EnimyTank.Add(new Tank(TankPrefab, Tank.TYPE_ENIMY));
    }

    public void onPlayerDead() {
        Debug.Log("Player Dead");
    }
}