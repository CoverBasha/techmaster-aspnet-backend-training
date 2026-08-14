namespace task_01_csharp_drills.Drills
{
    public class Drill02_GradeCalculator
    {
        public static void Calculate()
        {
            while (true)
            {
                Console.WriteLine("Enter a grade (0-100) or type e to exit: "); //A refactor for reading wouldn't be necessary

                var input = Console.ReadLine();

                if(input.ToLower() == "e")
                    return;

                if(!int.TryParse(input, out int grade))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine();
                    continue;
                }

                if (!Drill20_MethodRefactoringChallenge.IsValidGrade(grade)) // return weather the grade is valid or not
                    continue;

                Console.WriteLine(Drill20_MethodRefactoringChallenge.CalculateGrade(grade)); // return the letter grade for the given grade
            }
        }
    }
}
