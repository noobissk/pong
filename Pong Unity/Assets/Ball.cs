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
    public int score;
    Vector2 BounceDir;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            /*transform.position = new Vector2(0, 0);
            RB.velocity = new Vector2(0, 0);
            score = 0;
            Player.transform.position = new Vector2(0, -7);*/
            //Camera.main.ScreenToWorldPoint(Input.mousePosition) = new Vector2(0, 0);
        }
        Score.text = score.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            BounceDir = Player.position - transform.position;
            RB.velocity = new Vector2(RB.velocity.x, 17);
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
