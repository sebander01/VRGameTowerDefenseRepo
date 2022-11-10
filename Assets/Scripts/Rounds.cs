using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{

    public Transform player;
    public GameObject[] _Rounds;
    public GameObject[] spawn_points;

    public int round_counter;
    public int wave_counter;
    public int wave_spawn_counter = 1;

    public float timer;
    public float spawn_delay = 1.0f;

    public float wave_delay = 15.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wave_delay)
        {
            wave_delay += spawn_delay;

            
            int spawn_pos = Random.Range(0, spawn_points.Length - 1);
            GameObject spawnedEnemy = Instantiate(_Rounds[round_counter].GetComponent<WaveInfo>().enemy[wave_counter], spawn_points[spawn_pos].transform.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            wave_spawn_counter++;

            if (wave_spawn_counter > _Rounds[round_counter].GetComponent<WaveInfo>().enemy_count[wave_counter])
            {
                timer = 0;
                wave_delay = 15.0f;
                wave_spawn_counter = 1;

                wave_counter++;
                
                if(wave_counter == _Rounds[round_counter].GetComponent<WaveInfo>().enemy.Length)
                {
                    wave_counter = 0;
                    round_counter++;

                    if(round_counter == _Rounds.Length)
                    {
                        round_counter = 0;
                    }
                }
            }

        }
    }
}
