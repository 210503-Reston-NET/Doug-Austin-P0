using models;
namespace BL
{
    public interface ICustomerBL
    {
        bool CheckForUser (string nameInput, string phoneInput, string addressInput);
        AppUser CreateUser (string nameInput, string phoneInput, string addressInput);

    }
}