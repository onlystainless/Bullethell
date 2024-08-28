using UnityEngine;

// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class EmitExample : MonoBehaviour
{

    public int numer_of_columns;
    public float speed;
    public Texture texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    private float angle;
    public ParticleSystem system;
    private float OnParticleCollision;

    private void Awake()
    {
        Summon();
    }

    void Summon()
    {
        angle = 360f / numer_of_columns;

        

        for(int i = 0; i<numer_of_columns; i++)
        {
        // A simple particle material with no texture.
        Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

        // Create a green Particle System.
        var go = new GameObject("Particle System");
        go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
        go.transform.parent = this.transform;
        go.transform.position = this.transform.position;
        system = go.AddComponent<ParticleSystem>();
        go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        var mainModule = system.main;
        mainModule.startColor = Color.green;
        mainModule.startSize = 0.5f;

        var emission = system.emission;
        emission.enabled = false;
        
        var forma = system.shape;
        forma.enabled = true;
        forma.shapeType = ParticleSystemShapeType.Sprite;
        forma.sprite = null;



        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 2.0f, 2.0f);
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the start color and size.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.startColor = Color.red;
        emitParams.startSize = 0.2f;
        system.Emit(emitParams, 10);
        
        }

 

    }
}