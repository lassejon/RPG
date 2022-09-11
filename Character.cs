namespace OOPRPG
{
    public enum Role { Fighter = 1, Paladin, Mage, Cleric, Bard, Rouge }
    public enum Race { Human = 1, HighElf, Hobbit, Dwarf, Orc, Drow }

    public class Character
    {
        public string? Name { get; set; }
        //public int Level { get; set; }
        public int Xp { get; set; }
        public Role Role { get; set; }
        public Race Race { get; set; }
        public Attributes? Attributes { get; set; }

        public void Show()
        {
            Console.WriteLine($"\n***Character***\n{Name} the {Role}\tLevel: {GetLevel()} ({Xp} xp)\n");
            if (Attributes != null) Attributes.Show();
        }

        public int GetLevel()
        {
            return (Xp / 100) + 1;
        }
    }
}