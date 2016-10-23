   using System;
   namespace Puzzle.Core.Model
   {
     public class Photo{

        public long CustomerId{get;set;}

        public Guid ImageId{get;set;}

        public DateTime  CreateDate{get;set;}

        public long CreateUserId{get;set;}
       }
   }
        
        