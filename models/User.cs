namespace models
{
    public class User
    {
        public string Name{get; set;}
        public string Email{get; set;}
        public string Phone{get; set;}
        public string Address{get; set;}

        public override string ToString(){
            return $"{Name}/n{Email}/n{Phone}/n{Address}";
        }
    }
}