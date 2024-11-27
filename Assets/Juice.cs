using UnityEngine;

public class Juice : MonoBehaviour
{
    public GameObject collisionParticle;
    public MeshRenderer bg1, bg2, bg3;
    public Animator myAnimator;
 

    public float parallaxbg1, parallaxbg2, parallaxbg3;

    // Update is called once per frame
    void Update()
    {
        
        myAnimator.SetFloat("verticalSpeed", gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
        //bg1.material.mainTextureOffset = new Vector2(bg1.material.mainTextureOffset.x, gameObject.transform.position.y * parallaxbg1);
        bg1.material.mainTextureOffset = new Vector2(bg1.material.mainTextureOffset.x+Time.deltaTime*2f, gameObject.transform.position.y * parallaxbg1);
        bg2.material.mainTextureOffset = new Vector2(bg2.material.mainTextureOffset.x, gameObject.transform.position.y * parallaxbg2);
        bg3.material.mainTextureOffset = new Vector2(bg3.material.mainTextureOffset.x, gameObject.transform.position.y * parallaxbg3);
    }

    void OnCollisionEnter2D()
    {
        GameObject.Instantiate(collisionParticle, transform.position, Quaternion.identity);
        myAnimator.SetTrigger("hit"); //I have landed on something, probably should play squish
    }

    void OnCollisionStay2D()
    {
        myAnimator.SetBool("touchingCollider", true); // I am still on something, so probably don't play fall
    }

    void OnCollisionExit2D()
    {
        myAnimator.SetBool("touchingCollider", false); //I am no longer on something, therefore I can fall
    }
}
