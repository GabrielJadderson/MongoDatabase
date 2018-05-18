using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MongoDatabase;
using MongoDatabase.DBElements;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBProject
{
    public class Operations
    {
        //constructor
        public Operations()
        {
            Console.WriteLine("Starting operations");
        }

        public static bool createUser(String username)
        {
            try
            {
                if (username.Length > 1 && username != null)
                {
                    var user = new User { userID = new ObjectId(), Name = username, Ratings = null };
                    Globals.UserCollection.InsertOne(user);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// Queries the user collection for the given user id, if found returns true, false otherwise.
        /// </summary>
        /// <param name="username"> The User</param>
        /// <returns> true if the username is found and thus "authenticated", false if no user exists with that name.</returns>
        public static bool login(string username)
        {
            try
            {
                if (username.Length > 1 && username != null)
                {
                    var result = Globals.UserCollection.Find(x => x.Name == username).ToList();

                    foreach (var user in result)
                    {
                        Console.WriteLine(user.Name);
                    }

                    Console.WriteLine("found the user");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public bool createCombination()
        {
            //Create a combination of gin and tonic
            return false;
        }

        public static List<string> searchCombination()
        {
            //Search a combination of gin and tonic
            return null;
        }

        public static void createRatingEvaluation(int rating, string evaluationText)
        {
            //Create/Insert a rating or evaluation of a combination of gin an tonic
            if (rating < 0 || rating > 5)
            {
                Console.WriteLine(
                    "ERROR: The rating has to be bigger than or equal to Zero or less than or equal to Five");
            }
        }

        public static List<List<Rating>> returnRatingsEvaluations()
        {
            //return all ratings and evaluation(text?) for a specific combination
            return null;
        }

        public static int avgRating()
        {
            //retunr the average rating for a specific combination
            return 0;
        }

        static int numUsers()
        {
            //return the number of users that has rated the combination
            return 0;
        }

        public static List<Rating> returnMyRatings()
        {
            //return a list of a specific users combinations and ratings, that they have rated
            return null;
        }

        public static void markRating()
        {
            //mark rating as helpfull by incrementing numOfHelpfullMarks (search by combinationName and then comment id)
        }
    }
}