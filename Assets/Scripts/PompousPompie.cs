using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PompousPompie : MonoBehaviour
{
    public void AnimatePompousPompie(bool animate)
    {
        //CancelInvoke("StartAnimatingHands");
        GetComponent<Animator>().SetBool("ShakeHands", animate);
        //Invoke("StartAnimatingHands", Random.Range(1f, 3f));
    }
}
