using UnityEngine;
using System.Collections;

public class AndrewVideoCube : MonoBehaviour {

    public float distance = 10;
    public float goDepth = 4;
    Vector3 v3ViewPort;
    Vector3 v3BottomLeft;
    Vector3 v3TopRight;
    MeshRenderer rend;

    public Texture mTex;
    public float framesPerSecond;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();

        rend.material.mainTexture = Resources.Load("VideoExperiment/000001") as Texture;

        distance -= (goDepth * 0.5f);

        v3ViewPort.Set(0, 0, distance);
        v3BottomLeft = Camera.main.ViewportToWorldPoint(v3ViewPort);
        v3ViewPort.Set(1, 1, distance);
        v3TopRight = Camera.main.ViewportToWorldPoint(v3ViewPort);

        transform.localScale = new Vector3(v3BottomLeft.x - v3TopRight.x, v3BottomLeft.y - v3TopRight.y, goDepth);

        StartCoroutine(PlayVideo(framesPerSecond, "VideoExperiment", 6, "MainMenu"));

    }

    public IEnumerator PlayVideo(float fps, string path, int numberDigits, string levelAfter)
    {
        Begin:
        int i = 0;
        bool done = false;
        int allImages = Resources.LoadAll(path).Length - 1; //maybe add path, Texture2D

        while(done == false)
        {
            string digits = string.Empty;
            if(i > allImages)
            {
                done = true;
                break;
            }
            if(i < 10 && i > 0)
            {
                for(int w = 0; w < numberDigits-1; w++)
                {
                    digits += "0";
                }
                digits = digits + i;
            }
            if (i < 100 && i > 10)
            {
                for (int x = 0; x < numberDigits - 2; x++)
                {
                    digits += "0";
                }
                digits = digits + i;
            }
            if (i < 1000 && i > 100)
            {
                for (int y = 0; y < numberDigits - 3; y++)
                {
                    digits += "0";
                }
                digits = digits + i;
            }

            string currentFile = path + "/" + digits;
            Debug.Log(currentFile);

            Texture videoTexture = Resources.Load(currentFile) as Texture;
            mTex = videoTexture;
            i++;
            rend.material.mainTexture = mTex;
            yield return new WaitForSeconds(1/fps);


        }

        goto Begin;
    }
    void OnGUI()
    {
        rend.material.mainTexture = mTex;
    }

}


