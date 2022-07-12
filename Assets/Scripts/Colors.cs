using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    System.Random random = new System.Random();

    public Material player;
    public Material splash;
    public Material lastRing;
    public Material cylinder;
    public Material safe;
    public Material unSafe;

    public Image fill;
    public Image current;
    public Image next;

    public Camera camera;

    public int numberOfColors;
    float[,] color1 = { { 127, 167, 184 }, { 3, 129, 117 }, { 154, 156, 233 }, { 226, 184, 172 }, { 78, 46, 85 }, { 43, 78, 97 }, { 213, 114, 143 }, { 152, 156, 131 } };
    float[,] color2 = { { 248, 238, 237 }, { 11, 182, 140 }, { 162, 185, 237 }, { 145, 159, 136 }, { 149, 79, 116 }, { 189, 199, 201 }, { 249, 220, 216 }, { 221, 183, 170 } };
    float[,] color4 = { { 245, 71, 90 }, { 148, 221, 139 }, { 163, 220, 239 }, { 206, 218, 216 }, { 248, 218, 194 }, { 234, 211, 203 }, { 255, 255, 255 }, { 240, 217, 209 } };
    float[,] color3 = { { 50, 84, 109 }, { 255, 227, 179 }, { 174, 238, 224 }, { 152, 167, 174 }, { 248, 244, 233 }, { 132, 84, 96 }, { 187, 208, 209 }, { 242, 238, 235 } };
    void Start()
    {
        numberOfColors = random.Next(0,8);
        
        splash.color = new Color(color1[numberOfColors, 0] / 255f, color1[numberOfColors, 1] / 255f, color1[numberOfColors, 2] / 255f);
        unSafe.color = new Color(color1[numberOfColors, 0] / 255f, color1[numberOfColors, 1] / 255f, color1[numberOfColors, 2] / 255f);

        fill.color = new Color(color1[numberOfColors, 0] / 255f, (color1[numberOfColors, 1] - 20) / 255f, color1[numberOfColors, 2] / 255f);
        current.color = new Color(color1[numberOfColors, 0] / 255f, (color1[numberOfColors, 1] - 20) / 255f, color1[numberOfColors, 2] / 255f);
        next.color = new Color(color1[numberOfColors, 0] / 255f, (color1[numberOfColors, 1] - 20) / 255f, color1[numberOfColors, 2] / 255f);

        lastRing.color = new Color(color2[numberOfColors, 0] / 255f, color2[numberOfColors, 1] / 255f, color2[numberOfColors, 2] / 255f);
        safe.color = new Color(color2[numberOfColors, 0] / 255f, color2[numberOfColors, 1] / 255f, color2[numberOfColors, 2] / 255f);

        cylinder.color = new Color(color3[numberOfColors, 0] / 255f, color3[numberOfColors, 1] / 255f, color3[numberOfColors, 2] / 255f);

        player.color = new Color(color4[numberOfColors, 0] / 255f, color4[numberOfColors, 1] / 255f, color4[numberOfColors, 2] / 255f);
        camera.backgroundColor = new Color(color4[numberOfColors, 0] / 255f, color4[numberOfColors, 1] / 255f, color4[numberOfColors, 2] / 255f);

    }
}
