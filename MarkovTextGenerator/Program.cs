namespace MarkovTextGenerator;

public class Program
{
    static void Main(string[] args)
    {
        Chain chain = new Chain();

        LoadText("Billboard.txt", chain);

        Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

      //  Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

        // LoadText("Sample.txt", chain);

        //if you want to add your own sentences
        /*
        while (true)
        {

            Console.Write("> ");

            var line = Console.ReadLine();
            if (line == "!")
                break;

            chain.AddSentence(line);  // Let the chain process this string
        }
        

        // Now let's update all the probabilities with the new data
      */ 
        chain.UpdateProbabilities();
        /*

        // Okay now for the fun part
        Console.WriteLine("Done learning!  Now give me a word and I'll tell you what comes next.");
        Console.Write("> ");
        */
     //   var word = Console.ReadLine() ?? string.Empty;
        string sentence = chain.GenerateSentence(chain.GetRandomStartingWord());
        Console.WriteLine("Generated sentance: " + sentence);
    }

    /*  static void LoadText(string filename, Chain chain)
      {
          int counter = 0;

          string path = Path.Combine(Environment.CurrentDirectory, $"data\\{filename}");

          var lines = File.ReadAllLines(path);
          foreach (var line in lines)
          {
              chain.AddSentence(line);
              counter++;
          }
      }*/
    static void LoadText(string filename, Chain chain)
    {
        string path = Path.Combine(Environment.CurrentDirectory, $"data\\{filename}");

        // Read all lines
        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Treat each line as a sentence
            chain.AddSentence(line.Trim());
        }
    }







}

