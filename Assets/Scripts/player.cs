using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float xmin, xmax, ymin, ymax;
    GameObject laser;
    Coroutine firing;
    [SerializeField] int padding = 1;
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        laser = Resources.Load("laser") as GameObject;
        Bounds();
    }

    private void Bounds()
    {
        Camera cam = Camera.main;
        xmin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xmax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        ymin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        ymax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
    }

    private void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firing=StartCoroutine(start_fire());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(firing);
        }
    }
    IEnumerator start_fire()
    {
        while (true)
        {
            GameObject lasers = Instantiate(laser, transform.position, Quaternion.identity);
            lasers.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
            yield return (new WaitForSeconds(0.15f));
        }
    }

    private void move()
    {
        float x_axis = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float y_axis = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        float posx = Mathf.Clamp(transform.position.x + x_axis, xmin, xmax);
        float posy = Mathf.Clamp(transform.position.y + y_axis, ymin, ymax);
        transform.position = new Vector2(posx, posy);
    }
}
