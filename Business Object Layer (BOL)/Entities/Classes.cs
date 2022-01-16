namespace Business_Object_Layer__BOL_.Entities
{
    public class Classes : Entity
    {
        public string ClassName { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}
