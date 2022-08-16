using System.Collections.Generic;
using UnityEngine;


public class BattleManager : MonoBehaviour {
    public GameObject hexPrefab;
    private RectangleHexSpawnMethod _spawnMethod;
    private Dictionary<HexCoords, Hexa> _hexesColl;
    private IHexDisplacer _hexDisplacer;

    private Hexa _currentHex;

    void OnEnable() {
        var bmObj = new GameObject("BattleMap");
        bmObj.transform.SetParent(transform);

        _spawnMethod = new RectangleHexSpawnMethod();
        _spawnMethod.SetPrefab(hexPrefab, bmObj.transform);
        var hexesList = _spawnMethod.SpawnHexes(2, 6, 2);
        _hexesColl = AssambleHexaDictColl(hexesList);

        _hexDisplacer = new DirectHexDisplacer();
        _hexDisplacer.RegisterHexesList(hexesList);
        _hexDisplacer.DisplaceHexes();

        foreach(var hex in _hexesColl) {
            hex.Value.onHexSelect += HexClickedEventHandler;
        }

    }

    private void HexClickedEventHandler(Hexa h) {
        
    }

    private Dictionary<HexCoords, Hexa> AssambleHexaDictColl(List<Hexa> hexesList) {
        Dictionary<HexCoords, Hexa> hexesColl = new ();
        foreach(var h in hexesList) {
            hexesColl.Add(h.coords, h);
        }
        return hexesColl;
    }
}

public interface IHexDisplacer {
    public List<Hexa> HexesList { get; }
    public void RegisterHexesList(List<Hexa> hexesList);
    public void DisplaceHexes();
}

public class DirectHexDisplacer : IHexDisplacer {
    public List<Hexa> HexesList { get; private set; }

    public void RegisterHexesList(List<Hexa> hexesList) {
        this.HexesList = hexesList;
    }
    public void DisplaceHexes() {
        if (HexesList != null && HexesList.Count > 0) {
            var hexRendererComponent = HexesList[0].GetComponent<HexRenderer>();
            float hexVectorScalar = hexRendererComponent.radius * Mathf.Sqrt(3 / 2f);

            foreach (var hex in HexesList) {
                hex.transform.position = new Vector3(hex.coords.q, hex.coords.r, hex.coords.GetS()) * hexVectorScalar;
            }
        }
    }
}

public class RectangleHexSpawnMethod {
    public GameObject HexPrefab { get; private set; }
    public Transform ParentTarget { get; private set; }

    public void SetPrefab(GameObject hexPrefab) {
        this.HexPrefab = hexPrefab;
    }

    public void SetPrefab(GameObject hexPrefab, Transform parentTarget) {
        SetPrefab(hexPrefab);
        this.ParentTarget = parentTarget;
    }

    public List<Hexa> SpawnHexes(int width, int height, int deploymentDistance) {
        List<Hexa> hexesList = new();
        int qStart = 1;
        int rowWidth = width * 2;
        for (int r = 0; r <= height; r++) {
            int filedNo = 0;
            if(r > deploymentDistance) filedNo = 1;
            
            if (r % 2 == 0) {
                qStart--;
                rowWidth++;
            } else rowWidth--;

            for (int j = 0; j < rowWidth; j++) {
                hexesList.Add(CreateHex(-width + qStart + j, r, filedNo));
                if (r != 0) {
                    hexesList.Add(CreateHex(-width + qStart + j + r, -r, -filedNo));
                }
            }
        }
        return hexesList;
    }

    private Hexa CreateHex(int q, int r, int fieldNo) {
        Hexa goHexaComp;

        if (ParentTarget != null) goHexaComp = GameObject.Instantiate(this.HexPrefab, ParentTarget, false).GetComponent<Hexa>();
        else goHexaComp = GameObject.Instantiate(this.HexPrefab).GetComponent<Hexa>();

        var meshRenderer = goHexaComp.gameObject.GetComponent<MeshRenderer>();

        goHexaComp.SetCoords(q, r);

        goHexaComp.AssignDeploymentField(fieldNo);
        return goHexaComp;
    }
}
