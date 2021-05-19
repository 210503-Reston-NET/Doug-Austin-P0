using Models = models;
using Entities = DL.Entities;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace BL
{

    
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository repo){
            _repo = repo;
        }
        public bool CheckForUser (string nameInput, string phoneInput, string addressInput){
            bool exists = false;
            List<Entities.User> users = _repo.GetAllUsers();
            foreach (Entities.User user in users){
                if (user.Phone == phoneInput){
                    exists = true;
                }
            }
            return exists;
        }
        public Models.AppUser CreateUser (string nameInput, string phoneInput, string addressInput){
            Models.AppUser user1 = new Models.AppUser(nameInput, addressInput, phoneInput);
            user1.userType="Customer";
            return _repo.AddUser(user1);

        }
    }
}