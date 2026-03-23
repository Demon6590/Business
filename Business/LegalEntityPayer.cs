namespace Business;

public class LegalEntityPayer : Payer
{
    /// <summary>
    /// Наименование юридического лица.
    /// </summary>
    public string name { get; init; }

    /// <summary>
    /// Тип плательщика (всегда <see cref="PayerType.LEGAL_ENTITY"/>).
    /// </summary>
    public PayerType type { get; } = PayerType.LEGAL_ENTITY;
}