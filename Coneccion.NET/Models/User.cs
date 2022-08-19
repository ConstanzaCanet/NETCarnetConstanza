using System;


namespace Coneccion.NET.Models
{
    public class User
    {
        public int Id { get; set; }
        private string name;
        private string lastname;
        private string userName;
        private string password;
        private string email;


        public User()
        {
            Id = 0;
            name = string.Empty;
            lastname = string.Empty;
            userName = string.Empty;
            password = string.Empty;
            email = string.Empty;
        }

        public User(int id, string name, string lastname, string userName, string password, string email)
        {
            Id = id;
            this.name = name;
            this.lastname = lastname;
            this.userName = userName;
            this.password = password;
            this.email = email;
        }

        //setters & getters

        public string Name
        {
            get { return Name; }
            set { name = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
