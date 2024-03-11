namespace _Game.Scripts.Enums
{
    [System.Flags]
    public enum IngredientPrepState
    {
        None = 0,
        BigRaw = 1,
        SmallRaw = 2,
        Raw = 3,
        Cut = 4,
        Scent = 5
    }

    [System.Flags]
    public enum IngredientCookState
    {
        None = 0,
        Fry = 1,
        Steam = 2,
        Grill = 3
    }
}