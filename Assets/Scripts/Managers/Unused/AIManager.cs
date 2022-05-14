using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public GameObject ActiveEnemyHolder;
    private int _activeNum = 0;

    public GameObject SpawnPointsHolder;
    private Transform[] SpawnPoints;

    public ObjectPool EnemyPool;

    private bool _secondWave = true;
    private int _secondWaveTreshhold = 3;

    //public RoomManager RoomMngr;

    public int score;
    //public UIManager UiMngr;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(int SpawnPoint)
    {
        _activeNum++;
        Transform pickedSpawn = SpawnPoints[SpawnPoint];
        GameObject enemyToPlace = EnemyPool.RemoveObject();

        enemyToPlace.transform.SetParent(ActiveEnemyHolder.transform);

        enemyToPlace.transform.position = pickedSpawn.position;
    }

    public void SpawnEnemys(int num)
    {
        for (int i = 0; i < num; i++)
        {
            SpawnEnemy(i);
        }
    }

    public void HideEnemy(GameObject enemy)
    {
        EnemyPool.AddObject(enemy);
        enemy.GetComponent<EnemyAI>().StartIdle();

        _activeNum--;
        score += 50;
        //UiMngr.SetScoreText(score.ToString());

        if (_activeNum <= _secondWaveTreshhold && _secondWave)
        {
            SpawnSecondWave();
        }
        /*else if (_activeNum <= 0)
        {
            RoomMngr.OpenRoom();
        }*/
    }

    public void ChangeRoomSpawns(GameObject NewRoom)
    {
        SpawnPointsHolder = NewRoom;

        _secondWave = true;

        GetRoomSpawnPoints();
    }

    public void GetRoomSpawnPoints()
    {
        int count = SpawnPointsHolder.transform.childCount;
        SpawnPoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            SpawnPoints[i] = SpawnPointsHolder.transform.GetChild(i);
        }

        SpawnEnemys(6);
    }

    public void AlertAllActiveEnemies()
    {
        EnemyAI[] AllAIs = ActiveEnemyHolder.GetComponentsInChildren<EnemyAI>();

        foreach(EnemyAI ai in AllAIs)
        {
            ai.StartAlert();
        }
    }

    public void SpawnSecondWave()
    {
        _secondWave = false;
        SpawnEnemys(6);
        AlertAllActiveEnemies();
    }
}
