using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject fieldCtrl;

    [SerializeField]
    private Vector3 tapPos;

    [SerializeField]
    private Vector3 dragPos;

    [SerializeField]
    private Vector3 deltaValue;

    // Use fieldCtrl for initialization
    void Start()
    {
        StartCoroutine(coScrollField());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator coScrollField()
    {
        bool enableMove = false;

        while(true)
        {
            //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

            if (Input.mouseScrollDelta.y != 0)
            {
                enableMove = true;
            }
            else
                enableMove = false;

            if(enableMove)
                iTween.MoveTo(fieldCtrl, iTween.Hash("y", fieldCtrl.transform.position.y + Input.mouseScrollDelta.y, "delay", 0.1f));
            //fieldCtrl.transform.SetPositionAndRotation(new Vector3(fieldCtrl.transform.position.x, fieldCtrl.transform.position.y + Input.mouseScrollDelta.y, fieldCtrl.transform.position.z), fieldCtrl.transform.rotation);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
