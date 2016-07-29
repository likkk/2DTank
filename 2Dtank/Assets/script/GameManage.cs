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
    public GameObject Prefab_Shell;


    [HideInInspector] public static GameManage instance = null;

    private Tank m_Player = null;
    private int MAXLIFE = 3;
    private int m_PlayerLife;

    private ArrayList m_EnimyTank = null;
    private int Tank_Num = 0;
    private int Level_Current = 0;

    // Use this for initialization
    void Start() {
        instance = this;
        m_Player = new Tank(PlayerPoint, TankMove.TYPE_PLAYER);

        InvokeRepeating("createTank", FirstAppearDelay, AppearDelay);
        m_EnimyTank = new ArrayList();
    }

    // Update is called once per frame
    void Update() {

    }

    void createTank() {
        Debug.Log("create tank----" + Tank_Num++);
        m_EnimyTank.Add(new Tank(TankPoint[Random.Range(0, TankPoint.Length)], TankMove.TYPE_ENIMY));
        if (Tank_Num >= LevelEnimy[Level_Current]) {
            Debug.Log("CancelInvoke----level=" + Level_Current + " enimy=" + Tank_Num);
            CancelInvoke("createTank");
        }
    }

    public void onPlayerDead() {
        Debug.Log("Player Dead");
    }
}