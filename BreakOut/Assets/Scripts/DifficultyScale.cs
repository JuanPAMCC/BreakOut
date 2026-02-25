public static class DifficultyScaler
{
    public static float BallSpdMul(Difficulty d)
    {
        if (d == Difficulty.Easy) return 0.9f;
        if (d == Difficulty.Hard) return 1.15f;
        return 1f;
    }

    public static int BlockBonus(Difficulty d)
    {
        if (d == Difficulty.Easy) return -1;
        if (d == Difficulty.Hard) return 1;
        return 0;
    }
}