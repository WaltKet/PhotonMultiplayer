using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
public class CollisionChecker : MonoBehaviour
{
    Collider2D myCollider;
    Vector2 startPosition;
    public Text text;
    int score;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        score = 0;
        startPosition = new Vector2(transform.position.x, transform.position.y);
        myCollider = GetComponent<Collider2D>();
        text.text = "Count: 0";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        
        gameObject.transform.position = randomPositionOnScreen;
        score += 10;
        text.text = "Count: " + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (score >= 100)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
