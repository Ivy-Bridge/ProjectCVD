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
		iTween.MoveTo(fieldCtrl, iTween.Hash("y", -deltaValue.y, "EaseType", "linear"));
	}

    IEnumerator coScrollField()
    {
        bool enableMove = false;
		bool enableMoveTo = false;

        while(true)
        {
            //iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                enableMove = true;
				enableMoveTo = true;
				tapPos = Input.mousePosition;
            }
            else if(Input.GetKeyUp(KeyCode.Mouse0))
			{
				enableMove = false;
			}

            if(enableMove)
			{
				dragPos = Input.mousePosition;
				deltaValue = tapPos - dragPos;
				deltaValue = deltaValue * 0.01f;
			}

			if(enableMoveTo)
			{
				enableMoveTo = false;
			}
				
            //fieldCtrl.transform.SetPositionAndRotation(new Vector3(fieldCtrl.transform.position.x, fieldCtrl.transform.position.y + Input.mouseScrollDelta.y, fieldCtrl.transform.position.z), fieldCtrl.transform.rotation);
            yield return null;
        }
    }
}
