using models;
namespace BL
{
    public interface IInventoryBL
    {
        
         void Replenish(Location loc);

        bool CheckForUser (string nameInput, string phoneInput, string addressInput);
        AppUser CreateUser (string nameInput, string phoneInput, string addressInput);
        
    }
}