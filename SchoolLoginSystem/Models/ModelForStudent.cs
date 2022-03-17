using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLoginSystem.Models
{
    public class ModelForStudent
    {
        private string name { get; set; }
        private string password { get; set; }
        private int id { get; set; }
        private int math_point { get; set; }
        private int physics_point { get; set; }
        private int chemistry_point { get; set; }
        private string email { get; set; }
        private string username { get; set; }


        public ModelForStudent() { }
        public ModelForStudent(string _name, string _username, string _password, int _id, int _mathPoint, int _physicsPoint, int _chemistryPoint, string _email)
        {
            name = _name;
            password = _password;
            id = _id;
            math_point = _mathPoint;
            physics_point = _physicsPoint;
            chemistry_point = _chemistryPoint;
            email = _email;
            username = _username;
        }

        public ModelForStudent Update(string _name, string _username, string _password, int _id, int _mathPoint, int _physicsPoint, int _chemistryPoint, string _email)
        {
            name = _name ?? name;
            username = _username ?? username;
            password = _password ?? password;
            math_point = _mathPoint ;
            physics_point = _physicsPoint ;
            chemistry_point = _chemistryPoint ;
            email = _email ?? email;
            return this;


        }

        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        [Key]

        public int Id { get { return id; } set { id = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Math_point { get { return math_point; } set { math_point = value; } }
        public int Physics_point { get { return physics_point; } set { physics_point = value; } }
        public int Chemistry_point { get { return chemistry_point; } set { chemistry_point = value; } }
        public string Username { get { return username; } set { username = value; } }
    }
}
