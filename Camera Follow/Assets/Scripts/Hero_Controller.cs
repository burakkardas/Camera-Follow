using UnityEngine;

public class Hero_Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    private float _moveX;
    private bool _isFacingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        _moveX = Input.GetAxisRaw("Horizontal");

        CheckAnim();
        if(_moveX < 0 && _isFacingRight) {
            CheckFlip();
        }
        else if(_moveX > 0 && !_isFacingRight) {
            CheckFlip();
        }
    }

    private void FixedUpdate() {
        if(_moveX != 0) {
            rb.velocity = new Vector2(
                _moveX * _moveSpeed * Time.fixedDeltaTime,
                rb.velocity.y
            );
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }

    private void CheckAnim() {
        if(_moveX != 0 ) {
            _animator.SetBool("_isRun", true);
        }
        else {
            _animator.SetBool("_isRun", false);
        }
    }

    private void CheckFlip() {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
