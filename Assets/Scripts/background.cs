using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : MonoBehaviour
{
    [SerializeField] float offset=0.5f;
    Vector2 value;
    Material back;
    int score;
    Text scoretext;

    // Start is called before the first frame update
    private void Awake()
    {
        single();
    }

    private void single()
    {
        if (FindObjectsOfType<background>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else { DontDestroyOnLoad(this.gameObject); }
    }

    void Start()
    {
        back = GetComponent<Renderer>().material;
        value = new Vector2(0f, offset);
    }

    // Update is called once per frame
    void Update()
    {
        back.mainTextureOffset += value*Time.deltaTime;
    }
    void update_score()
    {
        scoretext.text = "Score:" + score;
    }
    public void increase_score() { score += 100;update_score(); }
    public void reset_score() { score=0;update_score(); }
    public void start_score() {this.scoretext = GameObject.Find("score").GetComponent<Text>(); }
}
