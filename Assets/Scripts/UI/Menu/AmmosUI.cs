using UnityEngine;
using TMPro;

public class AmmosUI : MonoBehaviour
{
    public TextMeshProUGUI currentAmmoText;
    public TextMeshProUGUI totalAmmoText;
    private Gun gun; 

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>(); 
        totalAmmoText.text = gun.maxAmmo.ToString(); // �Ѿ� �ִ� ���� ��Ÿ���� �� ���� (���� ������ ���� ������ ����)
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoText.text = gun.currentAmmo.ToString(); // ���� �Ѿ� ��
    }
}
