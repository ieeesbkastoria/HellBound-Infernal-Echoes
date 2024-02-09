using UnityEngine;

public class BackroundScroler : MonoBehaviour
{
    public MamalakisMovement script;

    [Range( -1f,1f)]
    public float scrollSpeed;
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
        if (script.pz ==1) scrollSpeed = 0.5f;
        else if (script.pz ==2) scrollSpeed = -0.5f;
        else if (script.pz ==3) scrollSpeed = 0f;
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
