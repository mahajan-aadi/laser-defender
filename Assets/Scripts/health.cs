using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class health : MonoBehaviour
{
    [SerializeField] int life = 100;
    Text healthbar;
    buttons button;
    background score;
    private void Start()
    {
        score = FindObjectOfType<background>();
        button = FindObjectOfType<buttons>();
        healthbar = GameObject.Find("health").GetComponent<Text>();
        health_check();
    }
    void health_check()
    {
        if (this.tag == "Player") { healthbar.text = "Health:" + life; }
        if (life <= 0) 
        {
            GameObject dead = (GameObject)Instantiate(Resources.Load("dead",typeof(GameObject)),
                transform.position, 
                Quaternion.identity);
            Destroy(dead, 1f);
            if (this.tag == "Player") { button.lose_game();score.reset_score(); }
            else { score.increase_score(); }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        life -= 100;
        health_check();
        if (collision.tag != "Player") { Destroy(collision.gameObject); }

    }
}
