
public struct HexCoords {
    public int q, r;
    public HexCoords(int q, int r) {
        this.q = q;
        this.r = r;
    }

    public int GetS() => -q -r;
    public static HexCoords Coords(int q, int r) => new(q, r);
}