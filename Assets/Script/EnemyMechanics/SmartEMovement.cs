using UnityEngine;

public class SmartEMovement : MonoBehaviour
{
    private Vector3 position;
    private float speed;
    private int angle = 0;
    private Animator enemyA;

    void Start()
    {
        enemyA = gameObject.GetComponentInChildren<Animator>();
        speed = 5.0f;
    }

    private void movement(){
        position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
    }

    public void CliffNoticed(){
        //scale 
            if(angle == 180){
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                angle = 0;
            }else{
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                angle = 180;
            }
            
            speed = -speed;
        }
    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
