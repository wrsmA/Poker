
/// <summary>
/// カードレコード
/// </summary>
public sealed record Card
{
    /// <summary>
    /// 番号
    /// </summary>
    public int number { get; init; }

    /// <summary>
    /// スーツ
    /// </summary>
    public Suite suite { get; init; }
}