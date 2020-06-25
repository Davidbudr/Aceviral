using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public MasterController Master;
    private Material m_mainMaterial;

    private float f_offset;
    public float xScrollSpeed;



    private void Awake()
    {
        m_mainMaterial = this.GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        if (Master.PlayState)
        {
            //while playstate scroll smoothly in the x direction
            f_offset += Time.deltaTime * xScrollSpeed;
            m_mainMaterial.SetTextureOffset("_MainTex", Vector2.right * f_offset);

            //reset the offset to prevent float overflow
            if(f_offset >= 1)
            {
                f_offset = 0;
            }
        }
    }
}
