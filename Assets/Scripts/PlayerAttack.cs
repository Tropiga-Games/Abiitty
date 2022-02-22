using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;
    public bool canReceiveInput;
    public bool inputReceived;
    
    void Awake()
    {
        instance = this;
    }
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
            }
            else
                return;
        }
    }
    public void InputManager()
    {
        if (!canReceiveInput)
            canReceiveInput = true;
        else
            canReceiveInput = false;
    }
    
}
