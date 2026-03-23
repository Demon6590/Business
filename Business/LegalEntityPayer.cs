namespace Business;

public class LegalEntityPayer: Payer
{
    public string name { get; init; }
    public PayerType type { get; init; }
}