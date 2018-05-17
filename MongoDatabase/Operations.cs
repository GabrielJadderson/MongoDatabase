using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDatabase.DBElements;
using MongoDB.Bson;

namespace MongoDBProject
{
    public class Operations
    {

        //constructor
        public Operations()
        {
            Console.WriteLine("Starting operations");
        }

        public static bool createUser(String userName)
        {//Creating the user if nonmember tries to login
            var user = new BsonDocument
            {
                {"userName", userName},
                {"ratingList", new BsonArray{}}
            };

            return false;
        }

        public static bool login(string username)
        {
            //query the database for the usenrame
            return false;
        }

        public bool createCombination()
        {//Create a combination of gin and tonic
            return false;
        }

        public static List<string> searchCombination()
        {//Search a combination of gin and tonic
            return null;
        }

        public static void createRatingEvaluation(int rating, string evaluationText)
        {//Create/Insert a rating or evaluation of a combination of gin an tonic
            if (rating < 0 || rating > 5)
            {
                Console.WriteLine("ERROR: The rating has to be bigger than or equal to Zero or less than or equal to Five");
            }

        }

        public static List<List<Rating>> returnRatingsEvaluations()
        {//return all ratings and evaluation(text?) for a specific combination
            return null;
        }

        public static int avgRating()
        {//retunr the average rating for a specific combination
            return 0;
        }

        static int numUsers()
        {//return the number of users that has rated the combination
            return 0;
        }

        public static List<Rating> returnMyRatings()
        {//return a list of a specific users combinations and ratings, that they have rated
            return null;
        }

        public static void markRating()
        {//mark rating as helpfull by incrementing numOfHelpfullMarks (search by combinationName and then comment id)
        }

    }
}