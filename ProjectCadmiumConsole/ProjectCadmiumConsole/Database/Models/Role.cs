namespace ProjectCadmiumConsole.Database.Models
{
    #region Sample Database Model
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public long Nth { get; set; }
    }
    #endregion
}
