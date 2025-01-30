using UnityEngine;

public class JumpTrigg2 : MonoBehaviour
{
    [SerializeField] private Player2 playerMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Tag platform 
        if (collision.gameObject.tag == "Platform")
        {
            playerMovement.LandedOnground();
        }

    }

}
