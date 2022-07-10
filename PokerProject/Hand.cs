
/// <summary>
/// 手札クラス
/// </summary>
public sealed class Hand
{
    /// <summary>
    /// 持ってるカード（5枚奴）
    /// </summary>
    public List<Card> cards = new();

    /// <summary>
    /// カードを追加
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card)
    {
        cards.Add(card);
        if (cards.Count > 5)
        {
            throw new ArgumentOutOfRangeException("手札枚数が5枚を超えました！");
        }
    }
}
