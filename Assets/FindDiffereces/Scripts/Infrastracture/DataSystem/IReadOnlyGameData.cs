namespace FindDifferences.Infrastracture.DataSystem
{
    public interface IReadOnlyGameData
    {
        public int CurrentLevelIndex { get; }
        public bool IsWin { get; }
    }
}
