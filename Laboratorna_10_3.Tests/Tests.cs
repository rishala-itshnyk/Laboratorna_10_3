namespace Laboratorna_10_3.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void View()
    {
        string fileName = "students.txt";
        string content = "Лисяк 5 5 5\nДурибаба 4 4 4\nРимар 3 3 3\n";
        File.WriteAllText(fileName, content);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Program.View(fileName);
            string expectedOutput = "\nСписок студентів:\nЛисяк 5 5 5\nДурибаба 4 4 4\nРимар 3 3 3\n";
            string actualOutput = sw.ToString().Replace("\r\n", "\n");

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        File.Delete(fileName);
    }

    [Test]
    public void Add_Test()
    {
        string fileName = "students.txt";
        string input = "Лисяк\n5\n5\n5";
        using (StringReader sr = new StringReader(input))
        {
            Console.SetIn(sr);

            Program.Add(fileName);
        }

        string expectedContent = "Лисяк 5 5 5";
        string actualContent = File.ReadAllText(fileName).Trim();

        Assert.AreEqual(expectedContent, actualContent);

        File.Delete(fileName);
    }
}