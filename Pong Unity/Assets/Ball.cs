using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform Player;
    Rigidbody2D RB;
    [SerializeField] Text Score;
    [SerializeField] int RestartScene;
    public int score;
    Vector2 BounceDir;
    [SerializeField] float Gravity;
    float OriginalGravity;
    void Start()
    {
        OriginalGravity = Gravity;
        RB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !Menu.IsPaused)
        {
            SceneManager.LoadScene(RestartScene);
        }
        Score.text = score.ToString();
        Gravity += 2f * Time.deltaTime;
    }
    void FixedUpdate()
    {
        RB.AddForce (-transform.up * Gravity, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Gravity = OriginalGravity;
            BounceDir = Player.position - transform.position;
            RB.velocity = new Vector2(RB.velocity.x, 22 + (score * 0.2f));
        }
        if (collision.transform.CompareTag("Block"))
        {
            score += 1;
            Destroy(collision.gameObject, 0);
        }
        if (collision.transform.CompareTag("Border"))
        {
            RB.velocity = new Vector2(-RB.velocity.x, RB.velocity.y);
        }
        
    }

}
