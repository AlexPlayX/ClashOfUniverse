using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Univ : MonoBehaviour
{
  

    public float TimeOut = 20.0f;
    private float activeTime;
    private bool destroy_object = false;

    private GameObject anim;
    private Animation animation;
    private AnimationState AnimState;

    //private bool moreAnim = false;
    private bool anim_exist = true;
    private bool end_wave = false;
    // Start is called before the first frame update
    void Start()
    {
        animation = this.gameObject.GetComponent<Animation>();


        if (animation == null)
            anim_exist = false;

        if (anim_exist && this.gameObject.tag != "Wave8" && this.gameObject.tag != "Wave9")
            animation.Play("Univ");

        if (this.gameObject.tag == "Wave8")
        {
            animation.CrossFadeQueued("Univ");
           
        }

        if (this.gameObject.tag == "Wave9")
        {
            animation.CrossFadeQueued("Univ");
           
        }

        activeTime = Time.time + TimeOut;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim_exist)
        {
            if (animation.IsPlaying("TimeOut") && (this.gameObject.tag == "Wave8" || this.gameObject.tag == "Wave9"))
                end_wave = true;

            if (!animation.IsPlaying("TimeOut") && end_wave && (this.gameObject.tag == "Wave8" || this.gameObject.tag == "Wave9"))
                Destroy(this.gameObject);


            if (!animation.IsPlaying("TimeOut") && destroy_object && this.gameObject.tag != "Wave8" && this.gameObject.tag != "Wave9")
                Destroy(this.gameObject);


            if (Time.time >= activeTime)
            {
                if (this.gameObject.tag != "Wave8" && this.gameObject.tag != "Wave9")
                    animation.Play("TimeOut");
                else
                {
                    animation.CrossFade("TimeOut", 0.75f);
                }

                destroy_object = true;
            }
        }
        if (transform.childCount == 0)
            Destroy(this.gameObject);

    }
}
