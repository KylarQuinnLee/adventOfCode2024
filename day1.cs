namespace AdventOfCode2022
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // First, read in the set of lists, line.split(' ').removeemptyentries
            // add to left and right
            // linq sort
            // foreach to do the actual problem.
            const string filePath = "C:\\Users\\A1031245\\source\\repos\\AdventOfCode2022\\AdventOfCode2022\\inputs\\day1.txt";
            var contents = GetFileContents(filePath);
            var (leftList, rightList) = GetLists(contents);
            leftList.Sort();
            rightList.Sort();

            if (leftList.Count != rightList.Count)
            {
                Assert.Fail();
            }

            var totalDistance = 0;



            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }
        }


        private List<string> GetFileContents(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        private (List<int>, List<int>) GetLists(List<string> fileContents)
        {
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in fileContents)
            {
                var lineItems = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (lineItems.Length != 2)
                {
                    System.Console.WriteLine($" Error: {line}");
                    continue;
                }
                var leftSuccess = int.TryParse(lineItems[0], out int leftInt);
                var rightSuccess = int.TryParse(lineItems[1], out int rightInt);

                if (!leftSuccess || !rightSuccess)
                {
                    continue;
                }
                leftList.Add(leftInt);
                rightList.Add(rightInt);
            }

            return (leftList, rightList);
        }

    }
}
