using UnityEngine;

/// <summary>
/// Player �𑀍삷��R���|�[�l���g
/// WASD �ő��삷��B
/// </summary>
public class SimplePlayerController : MonoBehaviour
{
    [SerializeField] float _movePower = 5f;
    Rigidbody _rb = default;
    /// <summary>���͂��ꂽ����</summary>
    Vector3 _dir;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���͂��󂯕t����
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // ���͂��ꂽ�������u�J��������Ƃ��� XZ ���ʏ�̃x�N�g���v�ɕϊ�����
        _dir = new Vector3(h, 0, v);
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;

        // �����Ă������������
        Vector3 dir = _rb.velocity;
        dir.y = 0;

        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower);
    }
}
