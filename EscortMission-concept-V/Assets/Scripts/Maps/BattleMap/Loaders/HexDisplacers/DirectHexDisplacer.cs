using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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