using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class EnforceConstraint2 : MonoBehaviour
{
    public GameObject sr1;
    public GameObject sr2;
    Vector3 savedScale;
    float savedHeight;

    public void Start()
    {
        savedScale = sr1.transform.localScale;
        savedHeight = sr2.transform.position.y;
    }

    public void Update()
    {
        if (savedScale != sr1.transform.localScale)
        {
            sr2.transform.localScale = sr1.transform.localScale;
            savedScale = sr1.transform.localScale;
        }
        else if (savedScale != sr2.transform.localScale)
        {
            sr1.transform.localScale = sr2.transform.localScale;
            savedScale = sr2.transform.localScale;
        }


        if (savedHeight != sr1.transform.position.y)
        {
            sr2.transform.position = new Vector3(sr2.transform.position.x, sr1.transform.position.y, sr2.transform.position.z);
            savedHeight = sr1.transform.position.y;
        }
        else if (savedHeight != sr2.transform.position.y)
        {
            sr1.transform.position = new Vector3(sr1.transform.position.x, sr2.transform.position.y, sr1.transform.position.z);
            savedHeight = sr2.transform.position.y;
        }
    }
}
