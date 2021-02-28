using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_path : MonoBehaviour
{
    waypoint way;
    List<Transform> path;
    int index=0;

    private void Start()
    {
        StartCoroutine(start_fire());
    }
    void Update()
    {
        start_enemy(way);
    }
    IEnumerator start_fire()
    {
        while (true)
        {
            float random = Random.Range(-0.1f, 0.1f);
            GameObject lasers = Instantiate(way.get_laser(), transform.position, Quaternion.identity);
            lasers.GetComponent<Rigidbody2D>().velocity = new Vector2(0, way.get_bullet_speed());
            yield return (new WaitForSeconds(way.get_bullet_gap()+random));
        }
    }
    public void set_way(waypoint way) { this.way = way; path = way.get_way(); }
    void start_enemy(waypoint way)
    {
        if(index<path.Count)
        {
            Transform ways = path[index];
            transform.position = Vector2.MoveTowards(transform.position, ways.position, way.get_speed() * Time.deltaTime);
            if (transform.position == ways.position) { index++; }
        }
        if (transform.position==path[path.Count-1].position) { Destroy(this.gameObject); }
    }
}
