using UnityEngine;

/// <summary>
/// �L�����N�^�[�𑀍삵�ăW�����v������@�\��񋟂���R���|�[�l���g
/// WASD �ňړ����ASpace �ŃW�����v����iInput Manager �g�p�j
/// �����Ƀg���K�[��ݒu���邱�ƁB�����̃g���K�[���ڐG���Ă�����u�ڒn���Ă���v�Ɣ��肵�A�W�����v�ł���B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacterMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _jumpPower = 5f;
    Rigidbody _rb = default;
    Animator _anim = default;
    /// <summary>�ڒn�t���O</summary>
    bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ���͂��󂯕t����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ���͂��ꂽ�������u�J��������Ƃ��� XZ ���ʏ�̃x�N�g���v�ɕϊ�����
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        
        // �L�����N�^�[���u���͂��ꂽ�����v�Ɍ�����
        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
        }

        // Y �������̑��x��ۂ��Ȃ���A���x�x�N�g�������߂ăZ�b�g����
        Vector3 velocity = dir.normalized * _moveSpeed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        // �W�����v����
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        // �A�j���[�V�����̏���
        if (_anim)
        {
            _anim.SetBool("IsGrounded", _isGrounded);
            Vector3 walkSpeed = _rb.velocity;
            walkSpeed.y = 0;
            _anim.SetFloat("Speed", walkSpeed.magnitude);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }
}
