using Cinemachine;
using UnityEngine;

[SelectionBase]
public class Pickup1 : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public float RotationSpeed = 20.0f;
    public GameObject ItemVisual;
    public GameObject mur;
    public GameObject mur2;
    //private Hud _hud;

    // Start is called before the first frame update
    public void Start()
    {
        mur.SetActive(true);
        // place l'objet en utilisant la data de l'objet
        //transform.position = ItemData.ItemPosition;

        //Mesh myMesh = Instantiate(ItemData.ItemMeshFilter);
        //GetComponent<MeshFilter>().sharedMesh = myMesh;        

        //_hud = GameObject.FindGameObjectWithTag("Hud")?.GetComponent<Hud>();
        //_hud = FindObjectOfType<Hud>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemVisual.transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {

            Instantiate(ParticleSystem, transform.position, Quaternion.identity);
            ItemVisual.SetActive(false);
            mur.SetActive(false);
            mur2.SetActive(false);
            //VirtualCamera.enabled = false;

            //if (_hud != null)
            //{
            //    _hud.UpdateScore(1);
            //}

            //_hud?.UpdateScore(ItemData.ItemScore);
    }
}