namespace models
{
    public class Pet : Products
    {
        public Pet(string _species, string _gender, string _color)
        {
            this.Species = _species;
            this.Gender = _gender;
            this.Color = _color;

        }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }

        public override string ToString(){
            return $"{Color} {Gender} {Species}";
        }
    }

    
}