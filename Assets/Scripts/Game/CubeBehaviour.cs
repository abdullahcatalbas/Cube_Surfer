using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    private Vector3 direction = Vector3.forward;
    public bool isStacked = false;
    private RaycastHit hit;
    
    [SerializeField] private AudioSource SoundEffectDropCube;
    
    void FixedUpdate()
    {
        if (!isStacked) //CubeBehaviour.isStacked
            return;

        float coeff = 0.02f;
        Debug.DrawRay(transform.position, direction * coeff, Color.red);

        if (Physics.Raycast(transform.position, direction, out hit, 1f * coeff))
        {
            if (hit.transform.gameObject.CompareTag("Obstacle"))
            {
                PlayerCubeManager.Instance.DropCube(this);
                SoundEffectDropCube.Play();
                Destroy(this);
            }
            else if(hit.transform.gameObject.CompareTag("FinalZone"))
            {
                
                GameOver.instance.SetUp();
                

            }
            
            
        }
    }



}

