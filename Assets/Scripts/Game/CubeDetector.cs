
using UnityEngine;


public class CubeDetector : MonoBehaviour
{


    [SerializeField] private AudioSource SoundEffectStar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log($"Cube {collision.gameObject.name}");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }
        }
        else  if (collision.gameObject.CompareTag("Star"))
        {
            Debug.Log("Star");
            SoundEffectStar.Play();
            ScoreManager.instance.AddPoint();
            Destroy(collision.gameObject);
        }
        

    }
      
   

    
}
