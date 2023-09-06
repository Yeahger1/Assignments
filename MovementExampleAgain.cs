using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementExampleAgain : MonoBehaviour
{
    Vector2 position;
    public Vector2 velocity = Vector2.zero;
    Vector2 acceleration;
    Vector2 gravity;
    bool flipped = false;
    bool gravityIsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        velocity += gravity * Time.deltaTime;
        
        transform.position = position;
        

        acceleration.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        acceleration.y += Input.GetAxisRaw("Vertical") * Time.deltaTime;

        velocity.x = Clamp(- 10, 10, velocity.x);
        velocity.y = Clamp(- 10, 10, velocity.y);
        if (Input.anyKey)
        {
            flipped = false;
        }
        if (Input.anyKey == false && flipped == false)
        {
            acceleration = Flip(acceleration);
            flipped = true;            
        }
        if (flipped && velocity.x > -0.1 && velocity.x < 0.1)
        {
            acceleration.x = 0;
            velocity.x = 0;
        }
        if (!gravityIsOn && flipped && velocity.y > -0.1 && velocity.y < 0.1)
        {
            acceleration.y = 0;
            velocity.y = 0;
        }
        if (gravityIsOn == false) 
        {        
            if (transform.position.x > 10)
            {
                position.x = -10;
            }
            if (transform.position.x < -10)
            {
               position.x = 10;
            }
            if (transform.position.y > 6)
            {
               position.y = -6;
            }
            if (transform.position.y < -6)
            {
                position.y = 6;
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityIsOn = !gravityIsOn;                        
        }
        if (gravityIsOn)
        {
            gravity.y = -2f;

            if (transform.position.y <= -5)
            {                
                velocity.y *= -1;
                velocity.y -= 0.5f;
                if (velocity.y > -1 && velocity.y < 1)
                {
                    velocity.y = 0;
                    acceleration.y = 0;
                    position.y = -5;                    
                }
            }
            if (transform.position.y >= 5)
            {
                velocity.y *= -1;
            }
            if (transform.position.x <= -9)
            {
                velocity.x *= -1;
            }
            if (transform.position.x >= 9)
            {
                velocity.x *= -1;
            }
        }
        else
        {
            gravity.y = 0; 
        }
            
    }
    public float Clamp(float min, float max, float value)
    {
        if (value < min)
        {
            value = min;
        }
        else if (value > max)
        {
            value = max;
        }
        return value;
    }
    public Vector2 Flip(Vector2 vector)
    {
        return vector *= -1;
    }
}
