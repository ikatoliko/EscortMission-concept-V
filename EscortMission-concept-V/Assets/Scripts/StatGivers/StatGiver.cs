using System.Collections.Generic;
using UnityEngine;

public abstract class StatGiver : BaseSO { }

public abstract class StatGiver<T> : StatGiver where T : StatSO {
    [SerializeField] private List<StatValue<T>> Stats;

    public virtual List<StatValue<Z>> GetStats<Z>() where Z : StatSO
        => Stats as List<StatValue<Z>>;
    public SignedStatValueList<Z> GetSignedStats<Z>() where Z : StatSO
        => new SignedStatValueList<Z>(this as StatGiver<Z>, GetStats<Z>());
}

public abstract class StatGiver<T, U> : StatGiver<T> where T : StatSO where U : StatSO {
    [SerializeField] private List<StatValue<U>> Stats2;

    public override List<StatValue<Z>> GetStats<Z>()
        => Stats2 as List<StatValue<Z>> ?? base.GetStats<Z>();
}

public abstract class StatGiver<T, U, G> : StatGiver<T, U> where T : StatSO where U : StatSO where G : StatSO {
    [SerializeField] private List<StatValue<G>> Stats3;

    public override List<StatValue<Z>> GetStats<Z>()
        => Stats3 as List<StatValue<Z>> ?? base.GetStats<Z>();
}