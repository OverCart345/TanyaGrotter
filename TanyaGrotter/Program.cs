namespace TanyaGrotter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var actions = new List<string>();
            using (var sr = new StreamReader("D:\\C#\\TanyaGrotter\\TanyaGrotter\\inp.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    actions.Add(line);
                }
            }

            var ingredients = new List<List<string>>();
            foreach (var action in actions)
            {
                var parts = action.Split();
                ingredients.Add(parts.Skip(1).ToList());
            }

            var spell = "";
            var cast = new List<string>();
            var answer = new List<string>();
            for (var i = 0; i < actions.Count; i++)
            {
                var parts = actions[i].Split();
                for (var j = 0; j < ingredients[i].Count; j++)
                {
                    if (int.TryParse(ingredients[i][j], out int castIndex))
                    {
                        answer.RemoveAt(castIndex - 1);
                        ingredients[i][j] = cast[castIndex - 1];
                    }
                }

                if (parts[0] == "MIX")
                {
                    spell += "MX" + string.Join("", ingredients[i]) + "XM";
                }
                else if (parts[0] == "WATER")
                {
                    spell += "WT" + string.Join("", ingredients[i]) + "TW";
                }
                else if (parts[0] == "DUST")
                {
                    spell += "DT" + string.Join("", ingredients[i]) + "TD";
                }
                else if (parts[0] == "FIRE")
                {
                    spell += "FR" + string.Join("", ingredients[i]) + "RF";
                }

                cast.Add(spell);
                answer.Add(spell);
                spell = "";
            }

            foreach(var a in answer) 
            {
                Console.Write(a);
            }
            
            Console.ReadKey();

        }
    }
}