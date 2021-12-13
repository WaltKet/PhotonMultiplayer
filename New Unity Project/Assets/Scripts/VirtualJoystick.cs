using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualJoystick : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            circle.GetComponent<SpriteRenderer>().sortingOrder = 2;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        if (touchStart )
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            if (direction != new Vector2(0, 0))
            {
                if(SceneManager.GetActiveScene().name == "TopDownWalker")
                {

                   if (System.Math.Abs(direction.x) > System.Math.Abs(direction.y))
                   {
                        if (direction.x > 0)
                        {
                            anim.SetBool("WalkingRight", true);
                            anim.SetBool("WalkingLeft", false);
                            anim.SetBool("WalkingFront", false);
                            anim.SetBool("WalkingTop", false);
                        }
                        else
                        {
                            anim.SetBool("WalkingRight", false);
                            anim.SetBool("WalkingLeft", true);
                            anim.SetBool("WalkingFront", false);
                            anim.SetBool("WalkingTop", false);
                        }
                   }
                   else
                   {
                        if (direction.y > 0)
                        {
                            anim.SetBool("WalkingRight", false);
                            anim.SetBool("WalkingLeft", false);
                            anim.SetBool("WalkingFront", false);
                            anim.SetBool("WalkingTop", true);
                        }
                        else
                        {
                            anim.SetBool("WalkingRight", false);
                            anim.SetBool("WalkingLeft", false);
                            anim.SetBool("WalkingFront", true);
                            anim.SetBool("WalkingTop", false);
                        }
                   }
                }
            moveCharacter(direction);
            }
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            anim.SetBool("WalkingRight", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingFront", false);
            anim.SetBool("WalkingTop", false);
        }

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}