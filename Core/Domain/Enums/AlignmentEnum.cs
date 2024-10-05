namespace Domain.Enums
{
    [Flags]
    public enum AlignmentEnum
    {
        None = 0,

        // Morality Axis
        Good = 1 << 0,       // 1
        Neutral = 1 << 1,    // 2
        Evil = 1 << 2,       // 4

        // Order Axis
        Lawful = 1 << 3,     // 8
        Chaotic = 1 << 4,    // 16

        // Combined Alignments
        LawfulGood = Lawful | Good,          // 9  (8 | 1)
        NeutralGood = Neutral | Good,        // 3  (2 | 1)
        ChaoticGood = Chaotic | Good,        // 17 (16 | 1)

        LawfulNeutral = Lawful | Neutral,    // 10 (8 | 2)
        TrueNeutral = Neutral,               // 2
        ChaoticNeutral = Chaotic | Neutral,  // 18 (16 | 2)

        LawfulEvil = Lawful | Evil,          // 12 (8 | 4)
        NeutralEvil = Neutral | Evil,        // 6  (2 | 4)
        ChaoticEvil = Chaotic | Evil,        // 20 (16 | 4)

        // General Categories
        AnyGood = Good,                      // 1
        AnyNeutral = Neutral,                // 2
        AnyEvil = Evil,                      // 4
        AnyLawful = Lawful,                  // 8
        AnyChaotic = Chaotic,                // 16

        // Any Alignment
        Any = Good | Neutral | Evil | Lawful | Chaotic  // 31 (1 | 2 | 4 | 8 | 16)
    }
}
