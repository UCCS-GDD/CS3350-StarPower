using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1_Main : MonoBehaviour {

    // determines which phase is currently being used
    public int whichPhase = 0;

    // base enemies
    public GameObject defaultEnemyPrefab;                           // prefabs of each enemy type to be instantiateds
    public GameObject bomberEnemyPrefab;
    public GameObject tankEnemyPrefab;

    //
    // Phase 1   
    public int phase1Default;                                       // number of default enemies
    public int phase1Bomber;                                        // number of bomber enemies
    public int phase1Tank;                                          // number of tank enemies
    public float phase1Duration;                                    // length of phase
    float phase1DefaultEnemyInterval;                               // determines how often these enemies spawn
    float phase1BomberEnemyInterval;                                  
    float phase1TankEnemyInterval;

    //
    // Phase 2   
    public int phase2Default;                                       // number of default enemies
    public int phase2Bomber;                                        // number of bomber enemies
    public int phase2Tank;                                          // number of tank enemies
    public float phase2Duration;                                    // length of phase
    float phase2DefaultEnemyInterval;                               // determines how often these enemies spawn
    float phase2BomberEnemyInterval;
    float phase2TankEnemyInterval;

    //
    // Phase 3   
    public int phase3Default;                                       // number of default enemies
    public int phase3Bomber;                                        // number of bomber enemies
    public int phase3Tank;                                          // number of tank enemies
    public float phase3Duration;                                    // length of phase
    float phase3DefaultEnemyInterval;                               // determines how often these enemies spawn
    float phase3BomberEnemyInterval;
    float phase3TankEnemyInterval;

    //
    // Phase 4
    public int phase4Default;                                       // number of default enemies
    public int phase4Bomber;                                        // number of bomber enemies
    public int phase4Tank;                                          // number of tank enemies
    public float phase4Duration;                                    // length of phase
    float phase4DefaultEnemyInterval;                               // determines how often these enemies spawn
    float phase4BomberEnemyInterval;
    float phase4TankEnemyInterval;

    //
    // Phase 5
    public int phase5Default;                                       // number of default enemies
    public int phase5Bomber;                                        // number of bomber enemies
    public int phase5Tank;                                          // number of tank enemies
    public float phase5Duration;                                    // length of phase
    float phase5DefaultEnemyInterval;                               // determines how often these enemies spawn
    float phase5BomberEnemyInterval;
    float phase5TankEnemyInterval;

    //
    // Phase 6
    public GameObject bossPrefab;                                   // boss object
    bool bossSpawned = false;                                                 


    //
    // Timers
    float defaultTimer;
    float bomberTimer;
    float tankTimer;
    float OneSecondTimer;

    public void Awake()
    {
        // set phase 1 intervals
        if (phase1Default > 0)
            phase1DefaultEnemyInterval = (phase1Duration / phase1Default);
        else
            phase1DefaultEnemyInterval = -1;
        if (phase1Bomber > 0)
            phase1BomberEnemyInterval = phase1Duration / phase1Bomber;
        else
            phase1BomberEnemyInterval = -1;
        if (phase1Tank > 0)
            phase1TankEnemyInterval = phase1Duration / phase1Tank;
        else
            phase1TankEnemyInterval = -1;

        // set phase 2 intervals
        if (phase2Default > 0)
            phase2DefaultEnemyInterval = phase2Duration / phase2Default;
        else
            phase2DefaultEnemyInterval = -1;
        if (phase2Bomber > 0)
            phase2BomberEnemyInterval = phase2Duration / phase2Bomber;
        else
            phase2BomberEnemyInterval = -1;
        if (phase2Tank > 0)
            phase2TankEnemyInterval = phase2Duration / phase2Tank;
        else
            phase2TankEnemyInterval = -1;

        // set phase 3 intervals
        if (phase3Default > 0)
            phase3DefaultEnemyInterval = phase3Duration / phase3Default;
        else
            phase3DefaultEnemyInterval = -1;
        if (phase3Bomber > 0)
            phase3BomberEnemyInterval = phase3Duration / phase3Bomber;
        else
            phase3BomberEnemyInterval = -1;
        if (phase3Tank > 0)
            phase3TankEnemyInterval = phase3Duration / phase3Tank;
        else
            phase3TankEnemyInterval = -1;

        // set phase 4 intervals
        if (phase4Default > 0)
            phase4DefaultEnemyInterval = phase4Duration / phase4Default;
        else
            phase4DefaultEnemyInterval = -1;
        if (phase4Bomber > 0)
            phase4BomberEnemyInterval = phase4Duration / phase4Bomber;
        else
            phase4BomberEnemyInterval = -1;
        if (phase4Tank > 0)
            phase4TankEnemyInterval = phase4Duration / phase4Tank;
        else
            phase4TankEnemyInterval = -1;

        // set phase 5 intervals
        if (phase5Default > 0)
            phase5DefaultEnemyInterval = phase5Duration / phase5Default;
        else
            phase5DefaultEnemyInterval = -1;
        if (phase5Bomber > 0)
            phase5BomberEnemyInterval = phase5Duration / phase5Bomber;
        else
            phase5BomberEnemyInterval = -1;
        if (phase5Tank > 0)
            phase5TankEnemyInterval = phase5Duration / phase5Tank;
        else
            phase5TankEnemyInterval = -1;


        // extend phase duration by 1 second
        phase1Duration++;
        phase2Duration++;
        phase3Duration++;
        phase4Duration++;
        phase5Duration++;

        // set the timers
        defaultTimer = 0;
        bomberTimer = 0;
        tankTimer = 0;
        OneSecondTimer = 0;
    }

    public void Update()
    {
        // set phase using a finite state machine
        switch (whichPhase)
        {
            // phase 1
            case 0:
                Phase1();
                break;
            // phase 2
            case 1:
                Phase2();
                break;
            // phase 3
            case 2:
                Phase3();
                break;
            case 3:
                Phase4();
                break;
            case 4:
                Phase5();
                break;
            case 5:
                Phase6();
                break;
            default:
                break;
        }

        defaultTimer += Time.deltaTime;
        bomberTimer += Time.deltaTime;
        tankTimer += Time.deltaTime;
        OneSecondTimer += Time.deltaTime;
    }

    public void SpawnEnemy(GameObject enemy)
    {
        float x = UnityEngine.Random.Range(-6.5f, 6.5f);
        float y = 6f;

        var spawn = Instantiate(enemy);
        spawn.transform.position = new Vector3(x, y);
    }

    public void Phase1()
    {
        // if there is still time left in the phase
        if (phase1Duration > 0)
        {
            // check to spawn a default enemy
            if (phase1DefaultEnemyInterval > 0 && phase1DefaultEnemyInterval <= defaultTimer)
            {
                defaultTimer = 0;
                SpawnEnemy(defaultEnemyPrefab);
                Debug.Log("default");
            }

            // check to spawn a bomber enemy
            if (phase1BomberEnemyInterval > 0 && phase1BomberEnemyInterval <= bomberTimer)
            {
                bomberTimer = 0;
                SpawnEnemy(bomberEnemyPrefab);
                Debug.Log("bomber");
            }

            // check to spawn a tank enemy
            if (phase1TankEnemyInterval > 0 && phase1TankEnemyInterval <= tankTimer)
            {
                tankTimer = 0;
                SpawnEnemy(tankEnemyPrefab);
                Debug.Log("tank");
            }

            // reduce time left in phase
            phase1Duration -= Time.deltaTime;
        }
        else
        {
            // increment to next phase
            whichPhase++;
            defaultTimer = 0;
            bomberTimer = 0;
            tankTimer = 0;
        }
    }

    public void Phase2()
    {
        // if there is still time left in the phase
        if (phase2Duration > 0)
        {
            // check to spawn a default enemy
            if (phase2DefaultEnemyInterval > 0 && phase2DefaultEnemyInterval <= defaultTimer)
            {
                defaultTimer = 0;
                SpawnEnemy(defaultEnemyPrefab);
                Debug.Log("default");
            }

            // check to spawn a bomber enemy
            if (phase2BomberEnemyInterval > 0 && phase2BomberEnemyInterval <= bomberTimer)
            {
                bomberTimer = 0;
                SpawnEnemy(bomberEnemyPrefab);
                Debug.Log("bomber");
            }

            // check to spawn a tank enemy
            if (phase2TankEnemyInterval > 0 && phase2TankEnemyInterval <= tankTimer)
            {
                tankTimer = 0;
                SpawnEnemy(tankEnemyPrefab);
                Debug.Log("tank");
            }

            // reduce time left in phase
            phase2Duration -= Time.deltaTime;
        }
        else
        {
            // increment to next phase
            whichPhase++;
            defaultTimer = 0;
            bomberTimer = 0;
            tankTimer = 0;
        }
    }

    public void Phase3()
    {
        // if there is still time left in the phase
        if (phase3Duration > 0)
        {
            // check to spawn a default enemy
            if (phase3DefaultEnemyInterval > 0 && phase3DefaultEnemyInterval <= defaultTimer)
            {
                defaultTimer = 0;
                SpawnEnemy(defaultEnemyPrefab);
                Debug.Log("default");
            }

            // check to spawn a bomber enemy
            if (phase3BomberEnemyInterval > 0 && phase3BomberEnemyInterval <= bomberTimer)
            {
                bomberTimer = 0;
                SpawnEnemy(bomberEnemyPrefab);
                Debug.Log("bomber");
            }

            // check to spawn a tank enemy
            if (phase3TankEnemyInterval > 0 && phase3TankEnemyInterval <= tankTimer)
            {
                tankTimer = 0;
                SpawnEnemy(tankEnemyPrefab);
                Debug.Log("tank");
            }

            // reduce time left in phase
            phase3Duration -= Time.deltaTime;
        }
        else
        {
            // increment to next phase
            whichPhase++;
            defaultTimer = 0;
            bomberTimer = 0;
            tankTimer = 0;
        }
    }

    public void Phase4()
    {
        // if there is still time left in the phase
        if (phase4Duration > 0)
        {
            // check to spawn a default enemy
            if (phase4DefaultEnemyInterval > 0 && phase4DefaultEnemyInterval <= defaultTimer)
            {
                defaultTimer = 0;
                SpawnEnemy(defaultEnemyPrefab);
                Debug.Log("default");
            }

            // check to spawn a bomber enemy
            if (phase4BomberEnemyInterval > 0 && phase4BomberEnemyInterval <= bomberTimer)
            {
                bomberTimer = 0;
                SpawnEnemy(bomberEnemyPrefab);
                Debug.Log("bomber");
            }

            // check to spawn a tank enemy
            if (phase4TankEnemyInterval > 0 && phase4TankEnemyInterval <= tankTimer)
            {
                tankTimer = 0;
                SpawnEnemy(tankEnemyPrefab);
                Debug.Log("tank");
            }

            // reduce time left in phase
            phase4Duration -= Time.deltaTime;
        }
        else
        {
            // increment to next phase
            whichPhase++;
            defaultTimer = 0;
            bomberTimer = 0;
            tankTimer = 0;
        }
    }

    public void Phase5()
    {
        // if there is still time left in the phase
        if (phase5Duration > 0)
        {
            // check to spawn a default enemy
            if (phase5DefaultEnemyInterval > 0 && phase5DefaultEnemyInterval <= defaultTimer)
            {
                defaultTimer = 0;
                SpawnEnemy(defaultEnemyPrefab);
                Debug.Log("default");
            }

            // check to spawn a bomber enemy
            if (phase5BomberEnemyInterval > 0 && phase5BomberEnemyInterval <= bomberTimer)
            {
                bomberTimer = 0;
                SpawnEnemy(bomberEnemyPrefab);
                Debug.Log("bomber");
            }

            // check to spawn a tank enemy
            if (phase5TankEnemyInterval > 0 && phase5TankEnemyInterval <= tankTimer)
            {
                tankTimer = 0;
                SpawnEnemy(tankEnemyPrefab);
                Debug.Log("tank");
            }

            // reduce time left in phase
            phase5Duration -= Time.deltaTime;
        }
        else
        {
            // increment to next phase
            whichPhase++;
            defaultTimer = 0;
            bomberTimer = 0;
            tankTimer = 0;
        }
    }

    public void Phase6()
    {
        if (!bossSpawned)
        {
            Instantiate(bossPrefab);
            bossSpawned = true;
        }
    }
}
