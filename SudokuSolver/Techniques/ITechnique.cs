namespace RazorPagesSudoku.SudokuSolver.Techniques
{
    public interface ITechnique
    {
        public string Name { get; set; }
        public Difficulty  DifficultyLevel { get; set; }
        public enum Difficulty
            {
              Easy = 1,
              Medium =2,
              Hard =3,
             VeryHard = 4
            }

        public void Solve();


    
    }
}
