namespace FeesCalculator.Model
{
    public enum Type
    {
        Zw,
        Cw,
        Elec,
        CO,
        Other,
    }
    public class Utility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type{ get; set; }
        public bool IsFixed { get; set; }
        public decimal Value { get; set; }
    }
}
