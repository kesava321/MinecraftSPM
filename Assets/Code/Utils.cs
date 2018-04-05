using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {

    static int maxHeight = 150;
    static float smooth = 0.01f;
    static int octaves = 4;
    static float persistence = 0.5f;

    //generate the stone layers
    public static int GenerateStoneHeight(float x, float z)
    {
        float height = Map(0, maxHeight -5, 0, 1, fBM(x * smooth * 2, z * smooth * 2, octaves +1, persistence));
        return (int)height;
    }

    //generate the dirt layers
    public static int GenerateHeight(float x, float z)
    {
        float height = Map(0, maxHeight, 0, 1, fBM(x * smooth, z * smooth, octaves, persistence));
        return (int) height;
    }

    //for the probability of air or not within the ground
    public static float fBM3D(float x, float y, float z, float sm, int oct)
    {
        
        float XY = fBM(x * sm , y * sm, oct, 0.5f);
        float YZ = fBM(y * sm , z * sm, oct,0.5f);
        float XZ = fBM(x * sm , z * sm, oct,0.5f);

        float YX = fBM(y * sm , x * sm, oct, 0.5f);
        float ZY = fBM(y * sm , z * sm, oct, 0.5f);
        float ZX = fBM(x * sm , z * sm, oct, 0.5f);

        return (XY + YZ + XZ + YX + ZY + ZX) / 6.0f;
    }

    //generate the math for the noise
    static float Map(float newmin, float newmax, float origmin, float origmax, float value)
    {
        return Mathf.Lerp(newmin, newmax, Mathf.InverseLerp(origmin, origmax, value));
    }

    static float fBM(float x, float z, int oct, float pers)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
		float offset = 32000f; //gets rid of negative coordinates
        for (int i = 0; i < oct; i++)
        {
			total += Mathf.PerlinNoise((x+offset) * frequency, (z+offset) * frequency) * amplitude;

            maxValue += amplitude;

            amplitude *= pers;
            frequency *= 2;
        }

        return total / maxValue;
    }
}
