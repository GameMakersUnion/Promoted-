﻿using UnityEngine;
using System.Collections;

public class MarketingCanvas : MonoBehaviour {
    private SpriteRenderer rend;
    private Color[] colors;
    // Use this for initialization
    void Start () {
        rend = GetComponent("SpriteRenderer") as SpriteRenderer;
        int mipCount = Mathf.Min(3, rend.sprite.texture.mipmapCount);

        for (var mip = 0; mip < mipCount; ++mip)
        {
            var cols = rend.sprite.texture.GetPixels(mip);
            for (var i = 0; i < cols.Length; ++i)
            {
                cols[i] = Color.black;
            }
            rend.sprite.texture.SetPixels(cols, mip);
           // var OffsetX = (target.position.x - transform.position.x) / myWidth;
            //var OffsetZ = (target.position.z - transform.position.z) / myLength;

            //rend.sprite.textureRectOffset.x;//.material.SetTextureOffset("_MainTex", Vector2(OffsetX, OffsetZ));
        }
        rend.sprite.texture.SetPixels(0, 0, rend.sprite.texture.width, rend.sprite.texture.height,colors);
        //Texture2D clone = Instantiate(rend.sprite.texture);
        //rend.sprite.texture = clone;
        //clone.SetPixel(0, 0, Color.red);
        //clone.Apply();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "MarketingPaint")
        {
        

            if (other.name == "PaintRed")
            {
                
                Collider2D otherCollider = other.GetComponent("Collider2D") as Collider2D;
                //SpriteRenderer renderer = otherCollider.GetComponentInChildren<SpriteRenderer>();

                Texture2D tex = rend.sprite.texture;
       
                tex.SetPixel(Random.Range(0, tex.width), Random.Range(0, tex.height), Color.red);

                tex.Apply();
                /*
                Vector2 pixelUV = other.v;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;
                */
                
            }
            if (other.name == "PaintGreen")
            {
                Collider2D otherCollider = other.GetComponent("Collider2D") as Collider2D;
                //SpriteRenderer renderer = otherCollider.GetComponentInChildren<SpriteRenderer>();

                Texture2D tex = rend.sprite.texture;

                Vector2 uv;
                uv.x = ((other.transform.position.x - (transform.position.x- (tex.width/2/32))));
                uv.y = ((other.transform.position.y - (transform.position.y- (tex.height/2/32))));
                Debug.Log(uv);

            
                //tex.SetPixel((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.green);
                tex.SetPixel(Mathf.RoundToInt(uv.x*32.0f), Mathf.RoundToInt(uv.y*30.0f), Color.green);
                //tex.SetPixel(1, 1, Color.green);
                //tex.SetPixel(10, 10, Color.green);

                //for(int x=0;x<16;x++)
                //    for (int y=0; y < 16; y++)
                //       tex.SetPixel(Mathf.RoundToInt(rend.sprite.textureRectOffset.x) + Mathf.RoundToInt(transform.position.x) +Mathf.RoundToInt(other.transform.position.x) +x + 90, 100, Color.black);

                tex.Apply();
            }
            if (other.name == "PaintBlue")
            {
                Collider2D otherCollider = other.GetComponent("Collider2D") as Collider2D;
                //SpriteRenderer renderer = otherCollider.GetComponentInChildren<SpriteRenderer>();

                Texture2D tex = rend.sprite.texture;
            


                tex.SetPixel(Random.Range(0, tex.width), Random.Range(0, tex.height), Color.blue);

                tex.Apply();
            }
        }
    }
}
