using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHexDisplacer {
    public List<Hexa> HexesList { get; }
    public void RegisterHexesList(List<Hexa> hexesList);
    public void DisplaceHexes();
}