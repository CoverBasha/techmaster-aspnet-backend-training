using System.Numerics;

namespace task_01_csharp_drills.Drills
{
    public class Drill15_ArrayRotation
    {
        public static void Rotate()
        {
            var numbers = Drill20_MethodRefactoringChallenge.ParseListInput();

            if (numbers == null)
                return;
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered");
                return;
            }

            var temp = numbers[0]; // storing first item
            numbers[0] = numbers.Last(); // copying last item to the beginning

            for(int i = 1; i < numbers.Count; i++) // looping from second item
            {
                //shifting array to the right
                var next = numbers[i]; // storing next item
                numbers[i] = temp; // assigning current item
                temp = next; // assigning next item for next iteration
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
