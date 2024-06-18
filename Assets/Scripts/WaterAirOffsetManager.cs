using NSMB.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAirOffsetManager : MonoBehaviour
{
    public GameObject tiles;
    public float tick;
    public float tick2;
    public float offset;
    private bool zero_flag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tick += 0.01f;

        if(offset > 0.04) {
            tick2 += 0.01f;
        }
        else {
            tick2 = 0;
        }

        float offset_tmp = GetWaterAirOffset(tick);
        offset = offset_tmp > 0.01 ? offset_tmp : 0;

        if(offset > 4.2) {
            zero_flag = true;
        }
        else {
            zero_flag = false;
        }

        offset = zero_flag ? offset * 0.01f : -(offset * 0.01f);

        tiles.transform.position = new Vector3(tiles.transform.position.x, tiles.transform.position.y + offset, tiles.transform.position.z);
    }

    public float GetWaterAirOffset(float x) {
        return Mathf.Pow(Mathf.Sin((x - 4.9f)), 1.5f) * (Mathf.Sin(x + 1.5f) + -5.4f) / -0.9f;
    }
}
