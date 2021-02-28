using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField] List<waypoint> waypoints;
    [SerializeField] float wait = 2f;
    background score;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<background>();
        StartCoroutine(new_wave());
        score.start_score();
        score.reset_score();
        Instantiate(Resources.Load("player", typeof(GameObject)), new Vector3(0, -3.5f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator new_wave()
    {
        foreach (waypoint way in waypoints)
        {
            Coroutine enemies=StartCoroutine(enemy(way));
            yield return (enemies);
            yield return (new WaitForSeconds(wait));
        }
        yield return (new WaitForSeconds(wait));
        StartCoroutine(new_wave());
    }
    IEnumerator enemy(waypoint way)
    {
        for(int i = 0; i < way.get_enemy_number(); i++)
        {
            GameObject Enemy = Instantiate(way.get_sprite(), way.get_way()[0].position, Quaternion.identity);
            Enemy.AddComponent<enemy_path>();
            Enemy.GetComponent<enemy_path>().set_way(way);
            float randomness = Random.Range(-way.get_randomness(), way.get_randomness());
            yield return (new WaitForSeconds(way.get_time_gap()+randomness));
        }

    }
}
