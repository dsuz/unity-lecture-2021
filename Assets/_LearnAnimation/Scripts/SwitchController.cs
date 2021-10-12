using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �X�C�b�`�̋@�\��񋟂���R���|�[�l���g
/// Player �^�O�������I�u�W�F�N�g���g���K�[�ɐN������ƁA�o�^���� UnityEvent ����x�������s����B
/// </summary>
public class SwitchController : MonoBehaviour
{
    /// <summary>Player ���N���������Ɏ��s���邱��</summary>
    [SerializeField] UnityEvent _onEnter = default;
    /// <summary>��x���삵�����ǂ���</summary>
    bool _isFinished = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_isFinished)
            {
                _onEnter.Invoke();
                _isFinished = true;
            }
        }
    }
}
