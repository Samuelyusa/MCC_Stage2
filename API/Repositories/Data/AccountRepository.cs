using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext mycontext;

        public AccountRepository(MyContext myContext)
        {
            this.mycontext = myContext;
        }

        public ResponseLogin Login(Login login)
        {
            var data = mycontext.UserRole
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Staff)
                .FirstOrDefault(x =>
                    x.User.Staff.Email.Equals(login.email)); 

            if (data != null)
            {
                if(ValidatePassword(login.password, data.User.Password))
                {
                    ResponseLogin responseLogin = new ResponseLogin();
                    {
                        responseLogin.Id = data.User.Id;
                        responseLogin.FullName = data.User.Staff.FullName;
                        responseLogin.Email = data.User.Staff.Email;
                        responseLogin.Role = data.Role.Name;
                    };
                    return responseLogin;
                }
            }
            return null;
        }

        public ResponseRegister Register(Register register)
        {
            Staff staff = new Staff()
            {
                FullName = register.FullName,
                Email = register.Email
            };

            mycontext.Staff.Add(staff);

            if (mycontext.SaveChanges() > 0)
            {
                var staffRegister = mycontext.Staff.Where(x => x.Email == register.Email).FirstOrDefault();
                mycontext.User.Add(new User()
                {
                    Id = staffRegister.Id,
                    Password = HashPassword(register.password)
                });

                if (mycontext.SaveChanges() > 0)
                {
                    
                    mycontext.UserRole.Add(new UserRole()
                    {
                        UserId = staffRegister.Id,
                        RoleId = register.RoleId
                    });

                    if (mycontext.SaveChanges() > 0)
                    {
                        ResponseRegister response = new ResponseRegister()
                        {
                            Id = staffRegister.Id,
                            FullName = staffRegister.FullName,
                            Email = staffRegister.Email,
                            Password = register.password,
                            RoleId = register.RoleId
                        };
                        return response;
                    }
                }
            }
            return null;
        }

        public bool ForgotPassword(ForgotPassword forgotPassword)
        {
            var data = mycontext.Staff.Where(x => x.Email.Equals(forgotPassword.Email) &&
                        x.FullName.Equals(forgotPassword.FullName)).FirstOrDefault();

            if (data!= null)
            {
                var account = mycontext.User.Where(x => x.Id == data.Id).FirstOrDefault();
                if (account != null)
                {
                    if(forgotPassword.NewPassword == forgotPassword.ConfirmNewPassword)
                    {
                        account.Password = HashPassword(forgotPassword.NewPassword);
                        mycontext.User.Update(account);

                        if(mycontext.SaveChanges() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
