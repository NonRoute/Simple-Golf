using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Golf : MonoBehaviour
{

    public int score = 5;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody2D rb;
    private bool isDown = false;
    public bool isInSand = false;

    [SerializeField]
    public TMP_Text scoreText;
    private float _launchPower = 200;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private LevelController levelController;

    private void Awake()
    {
        score = LevelController._sumScore;
        rb = GetComponent<Rigidbody2D>();
        scoreText.SetText("Score : " + score);
    }

    private void FixedUpdate()
    {
        if (!isInSand)
        {
            if (rb.velocity.magnitude >= 1.5)
            {
                rb.drag = 0.2f;
            }
            else if (rb.velocity.magnitude < 1.5 && rb.velocity.magnitude >= 0.1)
            {
                rb.drag = 5;
            }
            else if (rb.velocity.magnitude < 0.1)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;
            }
        }
        else
        {
            rb.drag = 5;
            if (rb.velocity.magnitude < 0.1)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;
            }
        }
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, startPosition);
        GetComponent<LineRenderer>().SetPosition(0, endPosition);
        if (isHitable())
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        if (isHitable())
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
            startPosition = transform.position;
            GetComponent<LineRenderer>().enabled = true;
            isDown = true;
        }
    }

    private void OnMouseDrag()
    {
        if (isDown)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPosition = new Vector3(newPosition.x, newPosition.y);
        }
    }

    private void OnMouseUp()
    {
        if (isDown)
        {
            audioSource.Play();
            score--;
            scoreText.SetText("Score : " + score);
            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<LineRenderer>().enabled = false;
            rb.AddForce((startPosition - endPosition) * _launchPower);
            isDown = false;
        }
    }

    private bool isHitable()
    {
        return rb.velocity == Vector2.zero;
    }
}
