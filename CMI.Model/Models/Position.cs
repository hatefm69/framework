namespace CMI.Model.Models
{
    public class Position
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string NameCode
        {
            get
            {
                return $"({Code})-{Name}";
            }
        }
    }
}
