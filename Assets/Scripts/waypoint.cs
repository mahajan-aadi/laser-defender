using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="waypoint")]
public class waypoint : ScriptableObject
{
    [SerializeField] GameObject waypoints;
    [SerializeField] float speed = 10f;
    [SerializeField] int enemies_number = 5;
    [SerializeField] float time_gap = 0.25f;
    [SerializeField] float randomness = 0.1f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject laser;
    [SerializeField] float bullet_speed = -10f;
    [SerializeField] float bullet_gap = 0.5f;

    public float get_speed() { return speed; }
    public float get_bullet_speed() { return bullet_speed; }
    public float get_bullet_gap() { return bullet_gap; }
    public float get_time_gap() { return time_gap; }
    public float get_randomness() { return randomness; }
    public int get_enemy_number() { return enemies_number; }
    public GameObject get_sprite() { return enemy; }
    public GameObject get_laser() { return laser; }
    public List<Transform> get_way()
    {
        List<Transform> ways = new List<Transform>();
        foreach(Transform child in waypoints.transform) { ways.Add(child); }
        return ways;
    }
}
