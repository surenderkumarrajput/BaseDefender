using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum States
{
    WAITING,SPAWNNING,COUNTING
}
public class WaveSpawnner : MonoBehaviour
{
    public Wave[] waves;
    int nextwave = 0;

    public float TimeBetweenWaves;
    [HideInInspector]
    public float waveCountDown;
    [HideInInspector]
    public float searchCountdown;

    public Transform[] SpawnPoints;

    States states = States.COUNTING;
    void Start()
    {
        waveCountDown = TimeBetweenWaves;
    }

    void Update()
    {
        if(states==States.WAITING)
        {
            if(!enemyisAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
       if(waveCountDown<=0)
        {
            if(states!=States.SPAWNNING)
            {
                StartCoroutine(Spawnning(waves[nextwave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }
    void WaveCompleted()
    {
        states = States.COUNTING;
        waveCountDown = TimeBetweenWaves;
        if(nextwave+1>waves.Length-1)
        {
            FindObjectOfType<AudioManager>().Play("WinVoice");
            SceneChangeManager.instance.SceneChangeMethod("Win");
        }
        else
        {
            nextwave++;
        }
    }
    IEnumerator Spawnning(Wave _wave)
    {
        states = States.SPAWNNING;
        for (int i = 0; i < _wave.count; i++)
        {
            Spawn(_wave.enemy);
            yield return new WaitForSeconds(1/_wave.rate);
        }
        states = States.WAITING;
        yield break;
    }
    public void Spawn(Transform _enemy)
    {
        Transform _Spawnpoints = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy,_Spawnpoints.transform.position, Quaternion.identity);
    }
    bool enemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown<=0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
}
