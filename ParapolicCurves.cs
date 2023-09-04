using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurves : ProcessingLite.GP21
{
    float spaceBetweenLines = 0.2f;
    [Range(0f, 255)] public int redColorValue = 255;
    [Range(0f, 255)] public int greenColorValue = 125;
    [Range(0f, 255)] public int blueColorValue = 0;

    void Start()
    {
        //Clear Background
        Background(0);
    }
    int frame = 0;

    // Update is called once per frame    
    void Update()
    {

        frame++;
        //Prepare our stroke settings
        Stroke(128, 128, 128, 64);
        StrokeWeight(0.5f);
        if (frame < 2)
        {
            //Draw our scan lines
            for (int i = 0; i < 10; i++)
            {
                if (i % 3 == 0)
                {
                    Stroke(Random.Range(0, 255), Random.Range(0, 245), Random.Range(0, 250), 64);
                }
                //Increase y-cord each time loop run
                float y = i * spaceBetweenLines;

                //Draw a line from left side of screen to the right
                Line(0, 10 - i, 1 + i, 0);
            }
        }
        
        //Line(0, 10, 1, 0);
        //Line(0, 9, 2, 0);
        //Line(0, 8, 3, 0);
    }

}
