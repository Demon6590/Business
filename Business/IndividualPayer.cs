namespace Business;

public class IndividualPayer : Payer
{
    /// <summary>
    /// ФИО физического лица.
    /// </summary>
    public string name { get; init; }

    /// <summary>
    /// Тип плательщика (всегда <see cref="PayerType.INDIVIDUAL"/>).
    /// </summary>
    public PayerType type { get; } = PayerType.INDIVIDUAL;
}