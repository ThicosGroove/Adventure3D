using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Animation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Ovo_UI")
        {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }

        if (gameObject.tag == "Pena")
        {
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
    }
}
