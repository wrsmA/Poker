/// <summary>
/// 役チェッカー
/// </summary>
public sealed class RoleChecker
{
    /// <summary>
    /// 手の内を見せろ！
    /// </summary>
    /// <param name="hand"></param>
    /// <returns></returns>
    public static Role CheckHand(Hand hand)
    {
        var numbers = hand.cards.Select(x => x.number);
        var suites = hand.cards.Select(x => x.suite);

        Role role = Role.HighCard;

        // 数字チェック
        CheckNumbers(numbers, ref role);

        // スーツチェック
        CheckSuites(suites, ref role);

        return role;
    }

    /// <summary>
    /// 数字だけチェック
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="role"></param>
    /// <exception cref="Exception"></exception>
    private static void CheckNumbers(IEnumerable<int> numbers, ref Role role)
    {
        // なんの数字が何枚あるかを出しておる
        (int number, int count)[]? arry = numbers.Distinct().Select(number => (number, numbers.Count(i => i == number))).ToArray();

        // 同数字で一番持ってる個数
        int dMax = arry.Max(x => x.count);

        // 同じ数字判定
        role = dMax switch
        {
            1 => Role.HighCard | Role.Straight,
            2 => arry.Count(x => x.count == 2) == 2 ? Role.TwoPair : Role.OnePair,
            3 => arry.Any(x => x.count == 2) ? Role.FullHouse : Role.ThreeCard,
            4 => Role.FourCard,
            _ => throw new Exception()
        };

        // 連続した数字判定
        IEnumerable<int>? source = Enumerable.Range(numbers.First(), 5);
        bool result = numbers.OrderBy(x => x).SequenceEqual(source);
        if (result && role.HasFlag(Role.Straight))
        {
            // 連番であるのでHighCardの可能性が無くなった
            role &= ~Role.HighCard;

        }
        if (numbers.SequenceEqual(new int[] { 1, 10, 11, 12, 13 }))
        {
            // 特定の組み合わせ
            role |= Role.RoyalFlash;
        }
    }

    /// <summary>
    /// スーツだけチェック
    /// </summary>
    /// <param name="suites"></param>
    /// <param name="role"></param>
    private static void CheckSuites(IEnumerable<Suite> suites, ref Role role)
    {
        // 同一スーツが何枚あるかを出しておる
        int[]? counts = suites.Distinct().Select(suite => suites.Count(i => i == suite)).ToArray();

        if (counts.Max(x => x) == 5)
        {
            // 5枚とも同じスーツ = Flash状態
            if (role.HasFlag(Role.RoyalFlash))
            {
                role = Role.RoyalFlash;
            }
            else if (role.HasFlag(Role.Straight))
            {
                role = Role.StraightFlash;
            }
            else
            {
                role = Role.Flash;
            }
        }
    }
}
