using System.Collections.Generic;
using UnityEngine;

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
