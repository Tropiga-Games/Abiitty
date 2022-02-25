using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction 
{
    LEFT,
    RIGHT,
    UP,
    DOWN
};

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject _body;
    private Rigidbody2D _rigidBody;
    [SerializeField] private Vector2 _moveDirection;
    private Direction _facingDirection = Direction.RIGHT;
    public bool actionLock = false;
    public bool idleLock = false;
    public bool secondStrikeLock = true;
    const string PLAYER_AXE_IDLE_R = "PlayerAxeIdleRight";
    const string PLAYER_AXE_WALK_R = "PlayerAxeWalkRight";
    const string PLAYER_AXE_L1_R = "PlayerAxeL1Right";
    const string PLAYER_AXE_L2_R = "PlayerAxeL2Right";
    const string PLAYER_AXE_L1Recovery_R = "PlayerAxeL1Recovery";
    public char directionChar;
    private Animator animator;
    public string currentState;
    public PlayerController _playerController;
    [SerializeField] private Direction _curDirection;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        animator = _body.GetComponent<Animator>();
        spriteRenderer = _body.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (!actionLock)
        {
            _moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            if (_moveDirection.x > 0)
                _curDirection = Direction.RIGHT;
            if (_moveDirection.x < 0)
                _curDirection = Direction.LEFT;
            if (_curDirection != _facingDirection)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                _facingDirection = _curDirection;
            }
            if (_moveDirection != Vector2.zero) //se houver input movimento
            {
                ChangeAnimationState(PLAYER_AXE_WALK_R);
                secondStrikeLock = true;
                idleLock = false;
            }
            else
            {
                if (!idleLock)
                    ChangeAnimationState(PLAYER_AXE_IDLE_R);
                else
                    ChangeAnimationState(PLAYER_AXE_L1Recovery_R);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(secondStrikeLock)
                    ChangeAnimationState(PLAYER_AXE_L1_R);
                else
                    ChangeAnimationState(PLAYER_AXE_L2_R);
                _moveDirection = Vector2.zero;
            }
        }
    }
    void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _moveDirection * moveSpeed * Time.deltaTime);
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        animator.Play(newState);
        currentState = newState;
    }
    void ConvertDirection()
    {
        if (_moveDirection.x > 0)
            directionChar = 'r';
        else if (_moveDirection.x < 0)
            directionChar = 'l';
        else if (_moveDirection.y > 0)
            directionChar = 'u';
        else if (_moveDirection.y < 0)
            directionChar = 'd';
    }
}
