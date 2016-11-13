   using System;
   
   namespace Puzzle.Core.Model
   {
     public class Photo{

        public long UserId{get;set;}

        public Guid StorageId{get;set;}

        public DateTime  CreateDate{get;set;}

        public long CreateUserId{get;set;}
        
       }
   }
        
        