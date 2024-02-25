﻿using Microsoft.AspNetCore.Identity;

namespace toeic_web.Models
{
    public class Users : IdentityUser
    {
        public string? Fullname { get; set; }
        public string? DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string ImageURL { get; set; }
        public virtual Student Student { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
