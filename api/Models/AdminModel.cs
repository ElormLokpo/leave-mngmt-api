﻿namespace api.Models
{
    public class AdminModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
