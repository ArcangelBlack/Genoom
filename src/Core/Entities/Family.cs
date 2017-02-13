namespace Core.Entities
{
    public class Family
    {
        public int Id { get; set; }

        public int SourcePersonId { get; set; }

        public int TargetPersonId { get; set; }

        public int Relation { get; set; }
    }
}
