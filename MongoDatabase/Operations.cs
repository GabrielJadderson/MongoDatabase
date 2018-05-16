using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBProject
{
    public class Operations
    {

        //constructor
        public Operations()
        {
            Console.WriteLine("Starting");
        }


        public static BsonDocument createUser(String userName)
        {//Creating the user if nonmember tries to login
            var user = new BsonDocument
            {
                {"userName",userName},
                {"ratingList", new BsonArray{}}
            };

            return user;
        }

        public static BsonDocument login()
        {//Loggin in users and save user name in variable
            return null;
        }
        
        public static BsonDocument createCombination()
        {//Create a combination of gin and tonic
            return null;
        }

        static async Task searchCombination()
        {//Search a combination of gin and tonic
            
        }

        static async Task createRatingEvaluation(int rating, string evaluationText)
        {//Create/Insert a rating or evaluation of a combination of gin an tonic
            if (rating < 0 || rating > 5)
            {
                Console.WriteLine("ERROR: The rating has to be bigger than or equal to Zero or less than or equal to Five");
            } 
            
        }

        static async Task returnRatingsEvaluations()
        {//return all ratings and evaluation(text?) for a specific combination
            
        }

        static async Task avgRating()
        {//retunr the average rating for a specific combination
            
        }

        static async Task numUsers()
        {//return the number of users that has rated the combination
            
        }

        static async Task returnMyRatings()
        {//return a list of a specific users combinations and ratings, that they have rated
            
        }

        static async Task markRating()
        {//mark rating as helpfull by incrementing numOfHelpfullMarks (search by combinationName and then comment id)
            
        }
        
    }
}