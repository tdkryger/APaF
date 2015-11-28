using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database
{

    /// <summary>
    /// Interface for database access
    /// </summary>
    public interface IDatabase
    {
        #region Events
        /// <summary>
        /// Event if database errors happens
        /// </summary>
        event DatabaseErrorEvent OnDatabaseError;
        #endregion

        #region Main classes
        #region Basic CRUD
        /// <summary>
        /// Reads a creature item from database
        /// </summary>
        /// <param name="dbId">The database id</param>
        /// <returns>An instance of Creatures</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if dbId is not valid</exception>
        Model.Creatures Read(int dbId);
        /// <summary>
        /// Reads a list of creature items from database
        /// </summary>
        /// <param name="search">The search pattern</param>
        /// <returns>A list of Creatures. Empty list if no Creatures was found</returns>
        List<Model.Creatures> Read(SearchPatterns.BasicSearch search);
        #endregion
        
        #region Crustacean CRUD
        /// <summary>
        /// Creates a Crustacean in the database
        /// </summary>
        /// <param name="item">The item to save</param>
        /// <returns>the item with db id set.</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">If crustacean already exists</exception>
        Model.CrustaceanClass CreateCrustacean(TDK.APaF.Model.CrustaceanClass item);
        /// <summary>
        /// Reads a crustacean from database id
        /// </summary>
        /// <param name="id">the database id</param>
        /// <returns>A Crustacean</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        Model.CrustaceanClass ReadCrustacean(int id);
        /// <summary>
        /// Reads a list of crustacean based on search
        /// </summary>
        /// <param name="search">Search pattern</param>
        /// <returns>A list of crustacean. Empty list if no crustaceans was found</returns>
        List<Model.CrustaceanClass> ReadCrustacean(SearchPatterns.BasicSearch search);
        /// <summary>
        /// Updates the crustacean in the database
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        bool UpdateCrustacean(Model.CrustaceanClass item);
        /// <summary>
        /// Delete the crustacean in the database
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        bool DeleteCrustacean(Model.CrustaceanClass item);
        #endregion

        #region Fish CRUD
        /// <summary>
        /// Create the item in the database
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns>The updated item with database id</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if item already exists</exception>
        Model.FishClass CreateFish(Model.FishClass item);
        /// <summary>
        /// Reads a fish from database id
        /// </summary>
        /// <param name="id">the database id</param>
        /// <returns>A fish</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        Model.FishClass ReadFish(int id);
        /// <summary>
        /// Reads a list of fish based on search
        /// </summary>
        /// <param name="search">Search pattern</param>
        /// <returns>A list of fish. Empty list if no fish was found</returns>
        List<Model.FishClass> ReadFish(SearchPatterns.BasicSearch search);
        /// <summary>
        /// Updates the fish in the database
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        bool UpdateFish(Model.FishClass item);
        /// <summary>
        /// Delete the fish in the database
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        bool DeleteFish(Model.FishClass item);
        #endregion

        #region Reptile CRUD
        /// <summary>
        /// Create a new reptile
        /// </summary>
        /// <param name="item">The reptile to create</param>
        /// <returns>The reptile with id set</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if creature already exists</exception>
        Model.ReptileClass CreateReptile(Model.ReptileClass item);
        /// <summary>
        /// Read a reptile
        /// </summary>
        /// <param name="id">The database id of the reptile</param>
        /// <returns>A reptile</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if creature is not found</exception>
        Model.ReptileClass ReadReptile(int id);
        /// <summary>
        /// Reads a list of reptiles
        /// </summary>
        /// <param name="search">The search pattern to use. <see cref="SearchPatterns.BasicSearch"/></param>
        /// <returns>A list of reptiles matching the search pattern. If no reptiles where found the list is empty</returns>
        List<Model.ReptileClass> ReadReptile(SearchPatterns.BasicSearch search);
        /// <summary>
        /// Updates a reptile
        /// </summary>
        /// <param name="item">The reptile to update</param>
        /// <returns>True if update was successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if reptile is not found</exception>
        bool UpdateReptile(Model.ReptileClass item);
        /// <summary>
        /// Delete a reptile
        /// </summary>
        /// <param name="item">The reptile to delete</param>
        /// <returns>true if deletion was successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if the reptile was not found</exception>
        bool DeleteReptile(Model.ReptileClass item);
        #endregion

        #region Gastropoda CRUD
        /// <summary>
        /// Create a gastropoda in the database
        /// </summary>
        /// <param name="item">The gastrpoda to create</param>
        /// <returns>The gastropoda with the database id set</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Trown if the gastropoda exists</exception>
        Model.GastropodaClass CreateGastropoda(Model.GastropodaClass item);
        /// <summary>
        /// Reads a gastropoda from the database
        /// </summary>
        /// <param name="id">the database id</param>
        /// <returns>The gastropoda</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if the gastropoda is not found</exception>
        Model.GastropodaClass ReadGastropoda(int id);
        /// <summary>
        /// Reads a list of gastropoda from the database
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<Model.GastropodaClass> ReadGastropoda(SearchPatterns.BasicSearch search);
        /// <summary>
        /// Update a gastropoda
        /// </summary>
        /// <param name="item">The gastropoda to update</param>
        /// <returns>True if successfull, false otherwise</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Gastropoda is not found</exception>
        bool UpdateGastropoda(Model.GastropodaClass item);
        /// <summary>
        /// Delete a gastropoda
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if gastropoda is not found</exception>
        bool DeleteGastropoda(Model.GastropodaClass item);
        #endregion

        #region Plant CRUD
        Model.PlantClass CreatePlant(Model.PlantClass item);
        Model.PlantClass ReadPlant(int id);
        List<Model.PlantClass> ReadPlant(SearchPatterns.BasicSearch search);
        bool UpdatePlant(Model.PlantClass item);
        bool DeletePlant(Model.PlantClass item);
        #endregion

        #endregion
    }
}
