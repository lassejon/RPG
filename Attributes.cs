namespace OOPRPG
{
    public class Attributes
    {
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Charisma { get; set; }

        public void Show()
        {
            foreach (System.Reflection.PropertyInfo property in GetType().GetProperties())
            {               
                Console.Write(property.Name + " ");
                Tools.TextColor((int)property.GetValue(this), 3, 18);
            }
        }
    }
}
