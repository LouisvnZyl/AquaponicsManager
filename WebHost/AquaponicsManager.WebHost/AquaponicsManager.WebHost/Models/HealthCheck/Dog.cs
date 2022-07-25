namespace AquaponicsManager.WebHost.Models.HealthCheck
{
    public class Dog
    {
        public string Breed { get; set; } = string.Empty;
        public string Colour { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public string GetName()
        {
            return Name;
        }

        public string DogSummary()
        {
            return $"This is my dog {Name} and he is a {Breed}";
        }
    }
}
