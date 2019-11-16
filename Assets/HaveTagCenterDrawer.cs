using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveTagCenterDrawer : MonoBehaviour
{

    private GameObject[] HaveTagObjs;
    
    private Camera Cam;
    private Vector3 [] ObjScreenPosition;
    private int ObjCount;


    // Start is called before the first frame update
    void Start()
    {
        HaveTagObjs = GameObject.FindGameObjectsWithTag("HaveTag");
        ObjCount = HaveTagObjs.Length;
        ObjScreenPosition = new Vector3[ObjCount];

        for (int i = 0; i < HaveTagObjs.Length; i++)
        {
            Debug.Log("Name " + HaveTagObjs[i].name);
        }
        Cam = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        //  Vector3 pos = Cam.WorldToScreenPoint(cube.transform.position);


        for (int i = 0; i < ObjCount; i++)
        {
            
            ObjScreenPosition[i] = Cam.WorldToScreenPoint( HaveTagObjs[i].transform.position);
            ObjScreenPosition[i].y = Screen.height - ObjScreenPosition[i].y;
            Debug.Log(ObjScreenPosition[i].x + " " + ObjScreenPosition[i].y);
        }


        //Debug.Log(" pos  " + pos);

    }


    void OnGUI()
    {

        for (int i = 0; i < ObjCount; i++)
        {

            Texture2D lineTex = new Texture2D(1, 1);
            GUI.color = Color.red;

            GUI.DrawTexture(new Rect(ObjScreenPosition[i].x, ObjScreenPosition[i].y, 50,50), lineTex);

        }

    }

}
