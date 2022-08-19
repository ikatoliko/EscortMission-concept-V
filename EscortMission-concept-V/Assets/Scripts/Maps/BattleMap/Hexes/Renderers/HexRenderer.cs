using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class HexRenderer : MonoBehaviour {
    private Mesh _mesh;
    private MeshFilter _mFilter;
    private MeshRenderer _mRenderer;
    private List<Face> _faces;
    
    public Material material;

    public float radius = 0.5f;

    public bool reversedMesh = false;

    private bool changed = false;

    
    #region MonoBehaviour Methods
    void Awake() {
        _mFilter = GetComponent<MeshFilter>();
        _mRenderer = GetComponent<MeshRenderer>();

        _mesh = new Mesh();
        _mesh.name = "Hex";

        _mFilter.mesh = _mesh;
        _mRenderer.material = material;
    }

    void OnEnable() {
        DrawMesh();
    }

    void OnValidate() {
        changed = true;
    }

    void Update() {
        if(changed) {
            DrawMesh();
            changed = false;
        }
    }
    #endregion
    
    private void DrawMesh() {
        DrawFaces();
        CombineFaces();
    }

    private void DrawFaces() {
        _faces = new List<Face>();

        for (int point = 0; point < 6; point++) {
            _faces.Add(CreateFace(radius, point));
        }
    }

    private Face CreateFace(float hexRad, int point) {
        Vector3 pointA = Vector3.zero;
        Vector3 pointB = GetPoint(hexRad, (point < 5) ? point + 1 : 0);
        Vector3 pointC = GetPoint(hexRad, point);

        var vertices = new List<Vector3>() { pointA, pointB, pointC };
        var triangles = new List<int>() { 0, 1, 2 };

        if(reversedMesh) vertices.Reverse();
        
        return new Face(vertices, triangles);
    }

    private Vector3 GetPoint(float size, int index) {
        float angle_deg = 60 * index - 30;
        float angle_rad = Mathf.PI / 180f * angle_deg;
        return new Vector3(size * Mathf.Cos(angle_rad), size * Mathf.Sin(angle_rad), 0);
    }

    private void CombineFaces() {
        var vertices = new List<Vector3>();
        var triangles = new List<int>();

        for (int i = 0; i < _faces.Count; i++) {
            vertices.AddRange(_faces[i].vertices);

            int offset = 3 * i;
            foreach(int triangle in _faces[i].triangles) {
                triangles.Add(triangle + offset);
            }
        }

        _mesh.vertices = vertices.ToArray();
        _mesh.triangles = triangles.ToArray();
        _mesh.RecalculateNormals();
    }
}

public struct Face {
    public List<Vector3> vertices { get; private set; }
    public List<int> triangles { get; private set; }

    public Face(List<Vector3> vertices, List<int> triangles) {
        this.vertices = vertices;
        this.triangles = triangles;
    }    
}
