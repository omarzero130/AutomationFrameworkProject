namespace AutomationFrameworkProject.Models
{
    public class Card
    {
        //virtual keyword means that classes that inherit this class can override them and give them new functionalities

        public virtual string id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Icon { get; set; }
        public virtual int Cost { get; set; }

        public virtual string Rarity { get; set; }

        public virtual string Type { get; set; }

        public virtual string Arena { get; set; }
    }
}