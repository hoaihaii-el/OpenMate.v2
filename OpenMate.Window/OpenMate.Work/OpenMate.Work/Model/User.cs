namespace OpenMate.Work.Model
{
    public class User
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
