using System;

namespace Puzzle.Core.Model
{
    public class User
    {
        public long UserID{get;set;}

        public string FirstName {get;set;}

        public string LastName{get;set;}

        public string Email {get;set;}

        public Puzzle.Core.Model.Gender Gender {get;set;}

        public DateTime CreateDate {get;set;}

        public DateTime DeleteDate {get;set;}    
    }
}