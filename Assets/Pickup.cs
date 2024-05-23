using Cinemachine;
using UnityEngine;

[SelectionBase]
public class Pickup : MonoBehaviour
{
    public GameObject ParticleSystem;
    public float RotationSpeed = 20.0f;
    public GameObject ItemVisual;
    public GameObject mur;
    public GameObject Light;
    //private Hud _hud;

    // Start is called before the first frame update
    void Start()
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

            ParticleSystem.SetActive(true);
            ItemVisual.SetActive(false);
            mur.SetActive(false);
            Light.SetActive(true);
            //VirtualCamera.enabled = false;

            //if (_hud != null)
            //{
            //    _hud.UpdateScore(1);
            //}

            //_hud?.UpdateScore(ItemData.ItemScore);
    }
}
