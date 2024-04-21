namespace FindDifferences.UI
{
    public struct EndGameData
    {
        public bool IsWin;
        public string Time;

        public EndGameData(bool isWin, string time)
        {
            IsWin = isWin;
            Time = time;
        }
    }
}