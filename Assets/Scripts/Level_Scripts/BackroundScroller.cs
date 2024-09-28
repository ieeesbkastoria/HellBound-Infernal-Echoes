using UnityEngine;

public class BackroundScroller : MonoBehaviour
{
    //public CharacterController2D script;
    public PlayerMovement script;

    [Range( -1f,1f)]
    public float scrollSpeed;
    [SerializeField] float Accelerance;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
       mat = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        // First try test1
        /*if (script.pz > 0) scrollSpeed = 0.5f;
        else if (script.pz < 0) scrollSpeed = -0.5f;
        else if (script.pz == 0) scrollSpeed = 0f;*/

        if (script.DoNotMinedMe == 1) scrollSpeed = 0.5f + Accelerance;
        else if (script.DoNotMinedMe == 2) scrollSpeed = -0.5f - Accelerance;
        else if (script.DoNotMinedMe == 3) scrollSpeed = 0f;

        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
