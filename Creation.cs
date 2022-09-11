namespace OOPRPG
{
    internal class Creation
    {
        Attributes? attributes = null;

        Data data = new();

        public Creation()
        {
            while (true)
            {
                Menu();
            }
        }

        private void Menu()
        {
            Console.WriteLine("\n1. Roll dices for attributes");
            if (attributes != null) Console.WriteLine("2. Create Character");
            if (data.Party?.Count > 0) Console.WriteLine("3. Show Party");
            if (data.Party?.Count > 3) Console.WriteLine("4. Start game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    attributes = RollAttributes();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if (attributes != null) CreateCharacter();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    if (data.Party.Count > 0) ShowParty();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    if (data.Party.Count > 3) new Game().StartGame(data);
                        break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    break;

                default:
                    break;
            }
        }

        private void ShowParty()
        {
            Console.WriteLine("\nThe party so far...\n");
            foreach (Character character in data.Party)
            {
                character.Show();
            }
        }

        private void CreateCharacter()
        {
            Character character = new Character() { Xp = 350, Attributes = attributes };

            PickARole(character);

            while (character.Name == null || character.Name == "")
            {
                Console.Write("Pick a name: ");
                character.Name = Console.ReadLine();
            }

            character.Show();

            Console.WriteLine($"\nDo you want to add {character.Name} to the party? (Y/N)");


            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine($"{character.Name} have been added to the party.");
                    data.Party.Add(character);
                    break;
                case ConsoleKey.N:
                    Console.WriteLine($"You waved goodbye to {character.Name} as he left for other adventures.");
                    break;
                default:
                    break;
            }

            attributes = null;
        }

        private void PickARole(Character character)
        {
            Console.WriteLine("\n*** Roles ****");
            int numberOfRoles = Enum.GetValues(typeof(Role)).Length;
            for (int i = 1; i <= numberOfRoles; i++)
            {
                Console.WriteLine(i + " " + (Role)i);
            }

            int r = 0;
            Console.Write("\nPick a role: ");
            while (!int.TryParse(Console.ReadLine(), out r) || r < 1 || r > numberOfRoles)
            {
                Console.Write("Try again:");
            }
            character.Role = (Role)r;
        }

        private Attributes RollAttributes()
        {
            Attributes attributes = new();
            do
            {
                Console.WriteLine("\nRolling...");
                foreach (System.Reflection.PropertyInfo property in attributes.GetType().GetProperties())
                {
                    Console.Write(property.Name + " ");
                    int roll = Tools.RollDices(3, 6);
                    property.SetValue(attributes, roll);
                }
                Console.WriteLine("\nAny key for Reroll or E for Exit");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.E);

            return attributes;
        }
    }
}
