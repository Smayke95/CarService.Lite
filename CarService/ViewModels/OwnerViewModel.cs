namespace CarService.ViewModels
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Name => FirstName + " " + LastName;

        public string Phone { get; set; } = string.Empty;
    }
}