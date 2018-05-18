using System;
using System.Collections.Generic;
using MongoDatabase.DBElements;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase
{
    public class Operations
    {

        /// <summary>
        /// Create a new User with the given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool CreateUser(String username)
        {
            bool succeed = false;
            try
            {
                if (username.Length > 1)
                {
                    var user = new User { Name = username };
                    Globals.UserCollection.InsertOne(user);
                    succeed = true;
                }
            }
            catch (Exception) { succeed = false; }
            return succeed;
        }

        /// <summary>
        /// Queries the user collection for the given user id, if found returns true, false otherwise.
        /// </summary>
        /// <param name="username"> The User</param>
        /// <returns> true if the username is found and thus "authenticated", false if no user exists with that name.</returns>
        public static bool Login(string username)
        {
            bool succeed = false;
            try
            {
                if (username.Length > 1)
                {
                    var result = Globals.UserCollection.Find(x => x.Name == username).ToList();
                    if (result.Count > 0)
                        succeed = true;
                }
            }
            catch (Exception) { succeed = false; }
            return succeed;
        }

        ///  <summary>
        ///  </summary>
        ///  <param name="gin"></param>
        ///  <param name="tonic"></param>
        ///  <param name="garnish"></param>
        /// <param name="comment"></param>
        /// <param name="userRating"></param>
        /// <returns>A Tuple of containing both Combination and Rating</returns>
        public static (Combination, Rating) CreateCombination(string gin, string tonic, string garnish, string comment, int userRating)
        {
            try
            {
                if (gin != null && tonic != null && garnish != null)
                {
                    var combination = new Combination
                    {
                        CombinationID = gin + tonic + garnish,
                        Gin = gin,
                        Tonic = tonic,
                        Garnish = garnish,
                        accumulativeRating = userRating
                    };
                    Globals.CombinationCollection.InsertOne(combination);
                    Rating rating = CreateRating(userRating, comment, combination.CombinationID);

                    return (combination, rating);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return (null, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userRating">the user rating</param>
        /// <param name="comment">A comment for the rating</param>
        /// <param name="combinationId">The id of the compination we want to create a rating for.</param>
        /// <returns></returns>
        public static Rating CreateRating(int userRating, string comment, string combinationId)
        {
            try
            {
                Rating rating = new Rating
                {
                    ratingId = new ObjectId(),
                    rating = userRating,
                    helpfulmarks = 0,
                    comment = comment,
                    theRatedCoombination = combinationId,
                    theUser = Globals.Username
                };
                Globals.RatingCollection.InsertOne(rating);
                return rating;
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }


        /// <summary>
        /// You should given a gin, tonic and optionally a garnish be able to retrieve the following:
        /// A list of ratings / comments for that combination(maybe with some pagination)
        /// An average rating for the combination
        /// The number of users having rated the combination
        /// </summary>
        /// <param name="gin"></param>
        /// <param name="tonic"></param>
        /// <param name="garnish"></param>
        /// <returns>
        /// a Tuple with the following elements:
        /// A list of ratings / comments for that combination(maybe with some pagination)
        /// An average rating for the combination
        /// The number of users having rated the combination
        /// on failure returns (null, -1, -1)
        /// (Ratings, users)
        /// </returns>
        public static (List<Rating>, List<int>) SearchCombination(string gin, string tonic, string garnish)
        {
            try
            {
                List<Combination> combinations;

                var gintonicFilter = Builders<Combination>.Filter.Eq(x => x.Gin, gin) & Builders<Combination>.Filter.Eq(x => x.Tonic, tonic);
                var allFilter = Builders<Combination>.Filter.Eq(x => x.Gin, gin) & Builders<Combination>.Filter.Eq(x => x.Tonic, tonic) & Builders<Combination>.Filter.Eq(x => x.Garnish, garnish);

                if (string.IsNullOrWhiteSpace(garnish) || string.IsNullOrEmpty(garnish))
                    combinations = Globals.CombinationCollection.Find(gintonicFilter).ToList();
                else
                    combinations = Globals.CombinationCollection.Find(allFilter).ToList();

                if (combinations != null && combinations.Count > 0)
                {
                    List<int> results = new List<int>();
                    List<Rating> ratings = new List<Rating>();
                    foreach (var c in combinations)
                    {
                        ratings.AddRange(ReturnRatingsForCombination(c.CombinationID));
                        results.Add(NumOfUsersRatedTheCombination(c.CombinationID));
                    }
                    return (ratings, results);
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return (null, null);
        }

        private static int NumOfUsersRatedTheCombination(string combinationId)
        {
            try
            {
                if (combinationId != null)
                    return Globals.RatingCollection.Find(x => x.theRatedCoombination == combinationId).ToList().Count;
            }
            catch (Exception)
            {
                // ignored
            }
            return -1;
        }


        public static List<Rating> ReturnRatingsForUser(string username)
        {
            try
            {
                if (username != null)
                    return Globals.RatingCollection.Find(x => x.theUser == username).ToList();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }


        /// <summary>
        /// You must be able to retrieve a list of the combinations you have rated, with the ratings you have supplied.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<Combination> ReturnCombinationsUserHasRated(string username)
        {
            try
            {
                List<Rating> ratings = ReturnRatingsForUser(username);

                if (ratings != null && ratings.Count > 0)
                {

                    var filter = Builders<Combination>.Filter.Eq(x => x.CombinationID, ratings[0].theRatedCoombination);

                    for (int i = 1; i < ratings.Count; i++) //you can (AND &&) filters :D
                    {
                        filter = filter & Builders<Combination>.Filter.Eq(x => x.CombinationID, ratings[i].theRatedCoombination);
                    }

                    return Globals.CombinationCollection.Find(filter).ToList();
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        public static List<Rating> ReturnRatingsForCombination(string combinationId)
        {
            try
            {
                return Globals.RatingCollection.Find(x => x.theRatedCoombination == combinationId).ToList();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        /// <summary>
        /// Increments the Helpful rating counter.
        /// </summary>
        /// <param name="ratingId"></param>
        /// <returns>true if sucessfully increased the mark, false on failure.</returns>
        public static bool MarkRatingAsHelpful(string ratingId)
        {
            try
            {
                if (ratingId != null && ratingId.Length > 1)
                {
                    var updateDef = Builders<Rating>.Update.Inc(o => o.helpfulmarks, 1);
                    var result = Globals.RatingCollection.UpdateOne(x => x.ratingId == new ObjectId(ratingId), updateDef);

                    if (result.IsAcknowledged)
                        return true;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }

        /// <summary>
        /// You should be able sort ratings after the number of helpfull marks.
        /// </summary>
        /// <returns></returns>
        public static List<Rating> GetSortedRatings()
        {
            try
            {
                return Globals.RatingCollection.Find(_ => true).Sort("{helpful: -1}").ToList();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        public static List<Combination> ReturnAllCombinationsWithLimit(int limit)
        {
            try
            {
                return Globals.CombinationCollection.Find(_ => true).Limit(limit).ToList();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        public static List<Rating> ReturnAllRatingsWithLimit(int limit)
        {
            try
            {
                return Globals.RatingCollection.Find(_ => true).Limit(limit).ToList();
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }
    }
}