namespace Business;

/// <summary>
/// Абстрактный базовый класс для представления плательщика.
/// Предоставляет общую структуру для всех типов плательщиков.
/// </summary>
public abstract class Payer
{
    /// <summary>
    /// Тип плательщика.
    /// </summary>
    public PayerType Type { get; init; }
}