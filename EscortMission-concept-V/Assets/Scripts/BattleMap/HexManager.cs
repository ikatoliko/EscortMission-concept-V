using System.Collections.Generic;
using UnityEngine;


public class HexManager : MonoBehaviour {
    public bool addHex = false;

    public GameObject hexPrefab;
    private IHexSpawnMethod _spawnMethod;
    private List<Hexa> _hexesList;
    private IHexDisplacer _hexDisplacer;

    void OnEnable() {
        _spawnMethod = new RhomboidMethod();
        _spawnMethod.SetPrefab(hexPrefab);
        _hexesList = _spawnMethod.SpawnHexes();

        _hexDisplacer = new DirectHexDisplacer();
        _hexDisplacer.RegisterHexesList(_hexesList);
        _hexDisplacer.DisplaceHexes();
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
            float hexVectorScalar = hexRendererComponent.radius * Mathf.Sqrt(3 / 2f) + 0.2F;

            foreach (var hex in HexesList) {
                int s = (hex.q + hex.r) * -1;
                hex.transform.position = new Vector3(hex.q, hex.r, s) * hexVectorScalar;
            }
        }
    }
}

public interface IHexSpawnMethod {
    public GameObject HexPrefab { get; }

    public void SetPrefab(GameObject hexPrefab);
    public List<Hexa> SpawnHexes();
}

public class RhomboidMethod : IHexSpawnMethod {
    public GameObject HexPrefab { get; private set; }

    private int _fromIndex = -10;
    private int _toIndex = 10;

    public void SetPrefab(GameObject hexPrefab) {
        this.HexPrefab = hexPrefab;
    }

    public List<Hexa> SpawnHexes() {
        List<Hexa> hexesList = new List<Hexa>();
        for (int i = _fromIndex; i <= _toIndex; i++) {
            for (int j = _fromIndex; j <= _toIndex; j++) {
                var goHexaComp = GameObject.Instantiate(this.HexPrefab).GetComponent<Hexa>();
                goHexaComp.SetCoords(i, j);
                hexesList.Add(goHexaComp);
            } 
        }
        return hexesList;
    }

    public bool SetFromToIndexes(int fromIndex, int toIndex) {
        if(fromIndex >= toIndex) return false;
        
        _fromIndex = fromIndex;
        _toIndex = toIndex;
        return true;
    }
}