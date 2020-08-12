using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace polymorphic_join.Models
{
    public interface ICommentable
    {
        public ICollection<Comment> Comments { get; set; }
    }
    
    public enum CommentType
    {
        Article,
        Video,
        Event
    }

    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
        public int? TypeId { get; set; }
        public CommentType CommentType { get; set; }
    }

    public class Article : ICommentable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        [NotMapped] public ICollection<Comment> Comments { get; set; }
    }

    public class Video : ICommentable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        [NotMapped] public ICollection<Comment> Comments { get; set; }
    }

    public class Event : ICommentable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
        [NotMapped] public ICollection<Comment> Comments { get; set; }
    }

    // Approach #1 - Polymorphic
    /*public class Acl
    {
        public int Id { get; set; }
        public string ResourceType { get; set; }
        public int ResourceId { get; set; }
    }
    public class Document {}
    public class Image {}
    public class File {}
    public class Report {}*/
    
    // Approach #2 - Join Table Per Relationship Type
    public class Acl
    {
        public int Id { get; set; }
    }
    public class Document {}
    public class AclDocument {}
    public class Image {}
    public class AclImage {}
    public class File {}
    public class AclFile {}
    public class Report {}
    public class AclReport {}
}