using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TDK.APaF.Database.SearchPatterns;
using TDK.APaF.Model;
using TDK.APaF.Model.Lists;

namespace TDK.APaF.Database.MySQL
{
    /// <summary>
    /// MySQL database implementation of <see cref="IDatabase">IDatabase</see>
    /// </summary>
    public class Database : IDatabase
    {
        #region Fields
        private DatabaseConfig _config;
        #endregion

        #region enums
        private enum BookListTypes { ReferenceBook = 0, OtherLiterature = 1 };
        #endregion

        #region Consts
        private const string DBConnectString = "Server={0};Database={1};Uid={2};Pwd={3};ConvertZeroDateTime=True;"
            + "tablecache=true;DefaultTableCacheAge=30;UseCompression=True;Pooling=True;";
        //private const string DBConnectString = "Server={0};Database={1};Uid={2};Pwd={3};";
        private const string DELETE_CREATURE = "UPDATE `creaturesandplants` SET deleted=1 WHERE id=@id";
        private const string UNDELETE_CREATURE = "UPDATE `creaturesandplants` SET deleted=0 WHERE id=@id";
        private const string UPDATE_CREATURE = "UPDATE `creaturesandplants` SET `creatuteType`=@creatuteType,`currentVersion`=@currentVersion,`danishTradenames`=@danishTradenames,`englishTradenames`=@englishTradenames,`germanTradenames`=@germanTradenames,`danishDescription`=@danishDescription,`englishDescription`=@englishDescription,`germanDescription`=@germanDescription,`scientificNameId`=@scientificNameId,`aqualogCode`=@aqualogCode,`createdId`=@createdId,`dataSource`=@dataSource,`familyId`=@familyId,`minHardness`=@minHardness,`maxHardness`=@maxHardness,`minLight`=@minLight,`maxLight`=@maxLight,`minPh`=@minPh,`maxPh`=@maxPh,`regionId`=@regionId,`minTemperature`=@minTemperature,`maxTemperature`=@maxTemperature,`groupTypeId`=@groupTypeId,`protected`=@protected,`waterType`=@waterType,`bottomTypeId`=@bottomTypeId,`flowering`=@flowering,`growthSpeedId`=@growthSpeedId,`hardy`=@hardy,`minHeight`=@minHeight,`maxHeight`=@maxHeight,`minWidth`=@minWidth,`maxWidth`=@maxWidth,`waterDepth`=@waterDepth,`zone`=@zone,`fishBaseId`=@fishBaseId,`minSize`=@minSize,`maxSize`=@maxSize,`swimmingPositionId`=@swimmingPositionId,`tankWidth`=@tankWidth WHERE `id`=@id;";
        private const string SELECT_CREATURE = "SELECT `id`,`creatuteType`,`currentVersion`,`danishTradenames`,`englishTradenames`,`germanTradenames`,`danishDescription`,`englishDescription`,`germanDescription`,`scientificNameId`,`aqualogCode`,`createdId`,`dataSource`,`familyId`,`minHardness`,`maxHardness`,`minLight`,`maxLight`,`minPh`,`maxPh`,`regionId`,`minTemperature`,`maxTemperature`,`groupTypeId`,`protected`,`waterType`,`bottomTypeId`,`flowering`,`growthSpeedId`,`hardy`,`minHeight`,`maxHeight`,`minWidth`,`maxWidth`,`waterDepth`,`zone`,`fishBaseId`,`minSize`,`maxSize`,`swimmingPositionId`,`tankWidth` FROM `V_creaturesAndPlants` "; //TODO: select creature sql
        private const string INSERT_CREATURE = "INSERT INTO `creaturesandplants`"
            + "(`creatuteType`,`aqualogCode`,`createId`,`dataSource`,`familyId`,`minHardness`,`maxHardness`,`minLight`,`maxLight`,`minPh`,`maxPh`,`regionId`,"
            + "`scientificNameId`,`minTemperature`,`maxTemperature`,`danishTradenames`,`englishTradenames`,`germanTradenames`,`groupTypeId`,`protected`,`waterType`,"
            + "`bottomTypeId`,`flowering`,`growthSpeedId`,`hardy`,`minHeight`,`maxHeight`,`minWidth`,`maxWidth`,`waterDepth`,`zone`,`fishBaseId`,`minSize`,`maxSize`,"
            + "`swimmingPositionId`,`tankWidth`) VALUES("
            + "@creatuteType, @aqualogCode, @createId, @dataSource, @familyId, @minHardness, @maxHardness, @minLight, @maxLight, @minPh, @maxPh, @regionId, @scientificNameId,"
            + "@minTemperature, @maxTemperature, @danishTradenames, @englishTradenames, @germanTradenames, @groupTypeId, S@protected,"
            + "@waterType, @bottomTypeId, @flowering, @growthSpeedId, @hardy, @minHeight, @maxHeight, @minWidth, @maxWidth, @waterDepth, @zone, @fishBaseId, @minSize,"
            + "@maxSize, @swimmingPositionId, @tankWidth);SELECT last_insert_id();";
        private const string INSERT_VERSION_CREATURE = "INSERT INTO `creaturesandplants_versions` (`orgId`,`deleted`,`creatuteType`,`currentVersion`,`danishTradenames`,`englishTradenames`,`germanTradenames`,`danishDescription`,`englishDescription`,`germanDescription`,`scientificNameId`,`aqualogCode`,`createdId`,`dataSource`,`familyId`,`minHardness`,`maxHardness`,`minLight`,`maxLight`,`minPh`,`maxPh`,`regionId`,`minTemperature`,`maxTemperature`,`groupTypeId`,`protected`,`waterType`,`bottomTypeId`,`flowering`,`growthSpeedId`,`hardy`,`minHeight`,`maxHeight`,`minWidth`,`maxWidth`,`waterDepth`,`zone`,`minSize`,`maxSize`,`fishBaseId`,`swimmingPositionId`,`tankWidth`) VALUES (@orgId,@deleted,@creatuteType,@currentVersion,@danishTradenames,@englishTradenames,@germanTradenames,@danishDescription,@englishDescription,@germanDescription,@scientificNameId,@aqualogCode,@createdId,@dataSource,@familyId,@minHardness,@maxHardness,@minLight,@maxLight,@minPh,@maxPh,@regionId,@minTemperature,@maxTemperature,@groupTypeId,@protected,@waterType,@bottomTypeId,@flowering,@growthSpeedId,@hardy,@minHeight,@maxHeight,@minWidth,@maxWidth,@waterDepth,@zone,@minSize,@maxSize,@fishBaseId,@swimmingPositionId,@tankWidth);";
        #endregion

        #region Events
        /// <summary>
        /// Event if database errors happens
        /// </summary>
        public event DatabaseErrorEvent OnDatabaseError;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor...
        /// </summary>
        public Database(DatabaseConfig config)
        {
            _config = config;
            // Tests that the connection is valid. SqlException thrown if not.
            try
            {
                using (MySqlConnection conn = getAConnection()) { }
            }
            catch (SqlException ex)
            {
                if (!handleDBError(new Delegates.DatabaseArgs(ex)))
                    throw ex;
            }
        }



        #endregion

        #region Public methods from IDatabase
        /// <summary>
        /// Undeletes a creature from the database. Only use in admin mode
        /// </summary>
        /// <param name="itemId">The database id for the creature</param>
        /// <returns>True if successfull, false otherwise</returns>
        public bool UndeleteCreature(int itemId)
        {
            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(UNDELETE_CREATURE, conn);
                    cmd.Parameters.AddWithValue("id", itemId);
                    try
                    {
                        cmd.ExecuteScalar();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        handleDBError(new Delegates.DatabaseArgs(ex));
                        return false;
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a list of older version. Admin only
        /// </summary>
        /// <param name="itemId">The orginal database id of the item</param>
        /// <returns>A list</returns>
        public List<Model.CreatureIdentification> GetOldVersion(int itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a Crustacean in the database
        /// </summary>
        /// <param name="item">The item to save</param>
        /// <returns>the item with db id set.</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">If crustacean already exists</exception>
        public CrustaceanClass CreateCrustacean(CrustaceanClass item)
        {
            item.ID = createCreature(item);
            return item;
        }

        /// <summary>
        /// Create the item in the database
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns>The updated item with database id</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if item already exists</exception>
        public FishClass CreateFish(FishClass item)
        {
            item.ID = createCreature(item);
            return item;
        }
        /// <summary>
        /// Delete the crustacean in the database
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        public bool DeleteCrustacean(CrustaceanClass item)
        {
            return deleteCreature(item);
        }
        /// <summary>
        /// Delete the fish in the database
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        public bool DeleteFish(FishClass item)
        {
            return deleteCreature(item);
        }
        /// <summary>
        /// Reads a list of creature items from database
        /// </summary>
        /// <param name="search">The search pattern</param>
        /// <returns>A list of Creatures. Empty list if no Creatures was found</returns>
        public List<Creatures> Read(BasicSearch search)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads a creature item from database
        /// </summary>
        /// <param name="dbId">The database id</param>
        /// <returns>An instance of Creatures</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if dbId is not valid</exception>
        public Creatures Read(int dbId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads a list of crustacean based on search
        /// </summary>
        /// <param name="search">Search pattern</param>
        /// <returns>A list of crustacean. Empty list if no crustaceans was found</returns>
        public List<CrustaceanClass> ReadCrustacean(BasicSearch search)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads a crustacean from database id
        /// </summary>
        /// <param name="id">the database id</param>
        /// <returns>A Crustacean</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        public CrustaceanClass ReadCrustacean(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads a list of fish based on search
        /// </summary>
        /// <param name="search">Search pattern</param>
        /// <returns>A list of fish. Empty list if no fish was found</returns>
        public List<FishClass> ReadFish(BasicSearch search)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Reads a fish from database id
        /// </summary>
        /// <param name="id">the database id</param>
        /// <returns>A fish</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        public FishClass ReadFish(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the crustacean in the database
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Crustacean is not found</exception>
        public bool UpdateCrustacean(CrustaceanClass item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the fish in the database
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        public bool UpdateFish(FishClass item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a Reptile in the database
        /// </summary>
        /// <param name="item">The reptile to create</param>
        /// <returns>The reptile with the database id set</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if the reptile already exists</exception>
        public ReptileClass CreateReptile(ReptileClass item)
        {
            item.ID = createCreature(item);
            return item;
        }

        /// <summary>
        /// Read a Reptile from the database
        /// </summary>
        /// <param name="id">The database id</param>
        /// <returns>The reptile</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Reptile is not found</exception>
        public ReptileClass ReadReptile(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read a list of Reptiles from the database with search parameters
        /// </summary>
        /// <param name="search">The search parameters</param>
        /// <returns>A list of Reptiles matching the search parameters. Empty list of no matches</returns>
        public List<ReptileClass> ReadReptile(BasicSearch search)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the Reptile
        /// </summary>
        /// <param name="item">The Reptile to update</param>
        /// <returns>True if successfull, false otherwise</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Reptile was not found</exception>
        public bool UpdateReptile(ReptileClass item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the reptile
        /// </summary>
        /// <param name="item">The Reptile to delete</param>
        /// <returns>True if successfull, false otherwise</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if Reptile not found</exception>
        public bool DeleteReptile(ReptileClass item)
        {
            return deleteCreature(item);
        }

        /// <summary>
        /// Create a Gastropoda in the database
        /// </summary>
        /// <param name="item">The Gastropoda to create</param>
        /// <returns>The Gastropoda with updated database id</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if gastropoda already exists</exception>
        public GastropodaClass CreateGastropoda(GastropodaClass item)
        {
            item.ID = createCreature(item);
            return item;
        }

        public GastropodaClass ReadGastropoda(int id)
        {
            throw new NotImplementedException();
        }

        public List<GastropodaClass> ReadGastropoda(BasicSearch search)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGastropoda(GastropodaClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGastropoda(GastropodaClass item)
        {
            return deleteCreature(item);
        }

        public PlantClass CreatePlant(PlantClass item)
        {
            item.ID = createCreature(item);
            return item;
        }

        public PlantClass ReadPlant(int id)
        {
            throw new NotImplementedException();
        }

        public List<PlantClass> ReadPlant(BasicSearch search)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlant(PlantClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlant(PlantClass item)
        {
            return deleteCreature(item);
        }

        public Behavior CreateBehavior(Behavior item)
        {
            throw new NotImplementedException();
        }

        public Behavior ReadBehavior(int dbId)
        {
            throw new NotImplementedException();
        }

        public BehaviorList ReadBehavior()
        {
            throw new NotImplementedException();
        }

        public BehaviorList ReadBehavior(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBehavior(Behavior item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBehavior(Behavior item)
        {
            throw new NotImplementedException();
        }

        public Book CreateBook(Book item)
        {
            throw new NotImplementedException();
        }

        public Book ReadBook(int dbId)
        {
            throw new NotImplementedException();
        }

        public BookList ReadBook()
        {
            throw new NotImplementedException();
        }

        public BookList ReadBook(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(Book item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(Book item)
        {
            throw new NotImplementedException();
        }

        public BottomTypeClass CreateBottom(BottomTypeClass item)
        {
            throw new NotImplementedException();
        }

        public BottomTypeClass ReadBottom(int dbId)
        {
            throw new NotImplementedException();
        }

        public BottomList ReadBottom()
        {
            throw new NotImplementedException();
        }

        public BottomList ReadBottom(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBottom(BottomTypeClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBottom(BottomTypeClass item)
        {
            throw new NotImplementedException();
        }

        public Decoration CreateDecoration(Decoration item)
        {
            throw new NotImplementedException();
        }

        public Decoration ReadDecoration(int dbId)
        {
            throw new NotImplementedException();
        }

        public DecorationList ReadDecoration()
        {
            throw new NotImplementedException();
        }

        public DecorationList ReadDecoration(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDecoration(Decoration item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDecoration(Decoration item)
        {
            throw new NotImplementedException();
        }

        public FoodTypeClass CreateFoodType(FoodTypeClass item)
        {
            throw new NotImplementedException();
        }

        public FoodTypeClass ReadFoodType(int dbId)
        {
            throw new NotImplementedException();
        }

        public FoodTypeList ReadFoodType()
        {
            throw new NotImplementedException();
        }

        public FoodTypeList ReadFoodType(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFoodType(FoodTypeClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFoodType(FoodTypeClass item)
        {
            throw new NotImplementedException();
        }

        public GrowthSpeedClass CreateGrowthSpeed(GrowthSpeedClass item)
        {
            throw new NotImplementedException();
        }

        public GrowthSpeedClass ReadGrowthSpeed(int dbId)
        {
            throw new NotImplementedException();
        }

        public GrowthSpeedList ReadGrowthSpeed()
        {
            throw new NotImplementedException();
        }

        public GrowthSpeedList ReadGrowthSpeed(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGrowthSpeed(GrowthSpeedClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGrowthSpeed(GrowthSpeedClass item)
        {
            throw new NotImplementedException();
        }

        public SwimmingPositionClass CreateSwimmingPosition(SwimmingPositionClass item)
        {
            throw new NotImplementedException();
        }

        public SwimmingPositionClass ReadSwimmingPosition(int dbId)
        {
            throw new NotImplementedException();
        }

        public SwimmingPositionList ReadSwimmingPosition()
        {
            throw new NotImplementedException();
        }

        public SwimmingPositionList ReadSwimmingPosition(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSwimmingPosition(SwimmingPositionClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSwimmingPosition(SwimmingPositionClass item)
        {
            throw new NotImplementedException();
        }

        public FamilyClass CreateFamily(FamilyClass item)
        {
            throw new NotImplementedException();
        }

        public FamilyClass ReadFamily(int dbId)
        {
            throw new NotImplementedException();
        }

        public FamilyListClass ReadFamily()
        {
            throw new NotImplementedException();
        }

        public FamilyListClass ReadFamily(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateFamily(FamilyClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFamily(FamilyClass item)
        {
            throw new NotImplementedException();
        }

        public RegionClass CreateRegion(RegionClass item)
        {
            throw new NotImplementedException();
        }

        public RegionClass ReadRegion(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<RegionClass> ReadRegion()
        {
            throw new NotImplementedException();
        }

        public List<RegionClass> ReadRegion(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRegion(RegionClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRegion(RegionClass item)
        {
            throw new NotImplementedException();
        }

        public GroupClass CreateGroup(GroupClass item)
        {
            throw new NotImplementedException();
        }

        public GroupClass ReadGroup(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<GroupClass> ReadGroup()
        {
            throw new NotImplementedException();
        }

        public List<GroupClass> ReadGroup(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGroup(GroupClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGroup(GroupClass item)
        {
            throw new NotImplementedException();
        }

        public OrderClass CreateOrder(OrderClass item)
        {
            throw new NotImplementedException();
        }

        public OrderClass ReadOrder(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<OrderClass> ReadOrder()
        {
            throw new NotImplementedException();
        }

        public List<OrderClass> ReadOrder(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(OrderClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(OrderClass item)
        {
            throw new NotImplementedException();
        }

        public ClassificationClass CreateClassification(ClassificationClass item)
        {
            throw new NotImplementedException();
        }

        public ClassificationClass ReadClassification(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<ClassificationClass> ReadClassification()
        {
            throw new NotImplementedException();
        }

        public List<ClassificationClass> ReadClassification(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClassification(ClassificationClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClassification(ClassificationClass item)
        {
            throw new NotImplementedException();
        }

        public LatinNameClass CreateLatinName(LatinNameClass item)
        {
            throw new NotImplementedException();
        }

        public LatinNameClass ReadLatinName(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<LatinNameClass> ReadLatinName()
        {
            throw new NotImplementedException();
        }

        public List<LatinNameClass> ReadLatinName(CreatureIdentification creature)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLatinName(LatinNameClass item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLatinName(LatinNameClass item)
        {
            throw new NotImplementedException();
        }

        public PlantZone CreatePlantZone(PlantZone item)
        {
            throw new NotImplementedException();
        }

        public PlantZone ReadPlantZone(int dbId)
        {
            throw new NotImplementedException();
        }

        public List<PlantZone> ReadPlantZone()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlantZone(PlantZone item)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlantZone(PlantZone item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods
        private void saveSynonyms(List<LatinNameClass> synonyms, int creatureId)
        {
            string updateSQL = "UPDATE `synonyms` SET `creaturesAndPlantsId`=@creaturesAndPlantsId,`scientificNameId`=@scientificNameId WHERE `creaturesAndPlantsId`=@creaturesAndPlantsId AND `scientificNameId`=@scientificNameId;";
            string insertSQL = "INSERT INTO `synonyms` (`creaturesAndPlantsId`,`scientificNameId`) VALUES (@creaturesAndPlantsId,@scientificNameId);";

            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(updateSQL, conn))
                    {
                        foreach (LatinNameClass lnc in synonyms)
                        {
                            try
                            {
                                LatinNameClass uplnc = this.CreateLatinName(lnc);
                                lnc.ID = uplnc.ID;
                            }
                            catch (Exceptions.ItemAlreadyExists)
                            {
                                // It's already in the database, so we are good ;o)
                            }
                            cmd.Parameters.AddWithValue("@creaturesAndPlantsId", creatureId);
                            cmd.Parameters.AddWithValue("@scientificNameId", lnc.ID);
                            try
                            {
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    cmd.CommandText = insertSQL;
                                    cmd.Parameters.AddWithValue("@creaturesAndPlantsId", creatureId);
                                    cmd.Parameters.AddWithValue("@scientificNameId", lnc.ID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (SqlException ex)
                            {
                                handleDBError(new Delegates.DatabaseArgs(ex));
                            }
                        }
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
        }

        private void saveBookList(List<Book> bookList, int creatureId, BookListTypes bookListType)
        {
            throw new NotImplementedException();
        }

        private void savePictures(PictureList Pictures, int creatureId)
        {
            string updateSQL = "UPDATE `picturelist` SET `creatureAndPlantsId`=@creatureAndPlantsId,`pictureId`=@pictureId WHERE `creatureAndPlantsId`=@creatureAndPlantsId AND `pictureId`=@creatureAndPlantsId;";
            string insertSQL = "INSERT INTO `picturelist` (`creatureAndPlantsId`,`pictureId`) VALUES (@creatureAndPlantsId,@pictureId);";

            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    using (MySqlCommand cmd = new MySqlCommand(updateSQL, conn))
                    {
                        foreach (Picture pic in Pictures)
                        {
                            cmd.Parameters.AddWithValue("@creaturesAndPlantsId", creatureId);
                            cmd.Parameters.AddWithValue("@pictureId", pic.ID);
                            try
                            {
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    cmd.CommandText = insertSQL;
                                    cmd.Parameters.AddWithValue("@creaturesAndPlantsId", creatureId);
                                    cmd.Parameters.AddWithValue("@pictureId", pic.ID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch (SqlException ex)
                            {
                                handleDBError(new Delegates.DatabaseArgs(ex));
                            }
                        }
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
        }
        #region Save lists
        private void setValues(MySqlCommand cmd, CreatureIdentification item)
        {
            if (item is CreatureIdentification)
                setValuesFromCreatureIdentification(cmd, item);
            if (item is Creatures)
                setValuesFromCreature(cmd, (Creatures)item);
            if (item is Animal)
                setValuesFromAnimal(cmd, (Animal)item);
            if (item is ReptileClass)
                setValuesFromReptile(cmd, (ReptileClass)item);
            if (item is GastropodaClass)
                setValuesFromGastropoda(cmd, (GastropodaClass)item);
            if (item is CrustaceanClass)
                setValuesFromCrustacean(cmd, (CrustaceanClass)item);
            if (item is PlantClass)
                setValuesFromPlant(cmd, (PlantClass)item);
        }

        private void setValuesFromCreatureIdentification(MySqlCommand cmd, CreatureIdentification item)
        {
            cmd.Parameters.AddWithValue("creatuteType", (int)item.CreatureType);
            cmd.Parameters.AddWithValue("danishTradenames", item.Tradenames.Danish);
            cmd.Parameters.AddWithValue("englishTradenames", item.Tradenames.English);
            cmd.Parameters.AddWithValue("germanTradenames", item.Tradenames.German);
            cmd.Parameters.AddWithValue("danishDescription", item.Description.Danish);
            cmd.Parameters.AddWithValue("englishDescription", item.Description.English);
            cmd.Parameters.AddWithValue("germanDescription", item.Description.German);

            if (item.ScientificName.ID == 0)
            {
                this.CreateLatinName(item.ScientificName);
            }
            cmd.Parameters.AddWithValue("scientificNameId", item.ScientificName.ID);
            //TODO: Handle foreign keys
        }

        private void setValuesFromCreature(MySqlCommand cmd, Creatures item)
        {
            cmd.Parameters.AddWithValue("aqualogCode", item.AquaLogCode);
            cmd.Parameters.AddWithValue("createdDateTime", item.Created.DateTime);
            cmd.Parameters.AddWithValue("createdUser", item.Created.User);
            cmd.Parameters.AddWithValue("dataSource", (int)item.DataSource);
            if (item.Family.ID == 0)
            {
                this.CreateFamily(item.Family);
            }
            cmd.Parameters.AddWithValue("familyId", item.Family.ID);
            cmd.Parameters.AddWithValue("minHardness", item.Hardness.MinValue);
            cmd.Parameters.AddWithValue("maxHardness", item.Hardness.MaxValue);
            cmd.Parameters.AddWithValue("minLight", (int)item.Light.MinLight);
            cmd.Parameters.AddWithValue("maxLight", (int)item.Light.MaxLight);
            cmd.Parameters.AddWithValue("minPh", item.PH.MinValue);
            cmd.Parameters.AddWithValue("maxPh", item.PH.MaxValue);
            if (item.Region.ID == 0)
            {
                this.CreateRegion(item.Region);
            }
            cmd.Parameters.AddWithValue("regionId", item.Region.ID);
            cmd.Parameters.AddWithValue("minTemperature", item.Temperature.MinValue);
            cmd.Parameters.AddWithValue("maxTemperature", item.Temperature.MaxValue);
            if (item.Group.ID == 0)
            {
                this.CreateGroup(item.Group);
            }
            cmd.Parameters.AddWithValue("groupTypeId", item.Group.ID);
            cmd.Parameters.AddWithValue("protected", item.Protected.ID);
            cmd.Parameters.AddWithValue("waterType", (int)item.WaterType);

            saveSynonyms(item.Synonyms, item.ID);
            savePictures(item.Pictures, item.ID);
            saveBookList(item.ReferenceBooks, item.ID, BookListTypes.ReferenceBook);
            saveBookList(item.ReferenceBooks, item.ID, BookListTypes.OtherLiterature);
        }

        private void setValuesFromAnimal(MySqlCommand cmd, Animal item)
        {
            cmd.Parameters.AddWithValue("minSize", item.Size.MinValue);
            cmd.Parameters.AddWithValue("maxSize", item.Size.MaxValue);
            //TODO: Lists
            //item.Behavior
            //item.Decorations
            //item.FoodTypes
        }

        private void setValuesFromPlant(MySqlCommand cmd, PlantClass item)
        {
            setValuesFromCreatureIdentification(cmd, item);
            setValuesFromCreature(cmd, item);

            if (item.BottomType.ID == 0)
            {
                this.CreateBottom(item.BottomType);
            }
            cmd.Parameters.AddWithValue("bottomTypeId", item.BottomType.ID);
            cmd.Parameters.AddWithValue("flowering", item.Flowering);
            if (item.GrowthSpeed.ID == 0)
            {
                this.CreateGrowthSpeed(item.GrowthSpeed);
            }
            cmd.Parameters.AddWithValue("growthSpeedId", item.GrowthSpeed.ID);
            cmd.Parameters.AddWithValue("hardy", ((item.Hardy) ? 1 : 0));
            cmd.Parameters.AddWithValue("minHeight", item.Height.MinValue);
            cmd.Parameters.AddWithValue("maxHeight", item.Height.MaxValue);
            cmd.Parameters.AddWithValue("minWidth", item.Width.MinValue);
            cmd.Parameters.AddWithValue("maxWidth", item.Width.MaxValue);
            cmd.Parameters.AddWithValue("waterDepth", item.WaterDepth);
            if (item.Zone.ID == 0)
            {
                this.CreatePlantZone(item.Zone);
            }
            cmd.Parameters.AddWithValue("zone", item.Zone.ID);
        }

        private void setValuesFromGastropoda(MySqlCommand cmd, GastropodaClass item)
        {
            setValuesFromCreatureIdentification(cmd, item);
            setValuesFromCreature(cmd, item);
            setValuesFromAnimal(cmd, item);
        }

        private void setValuesFromReptile(MySqlCommand cmd, ReptileClass item)
        {
            setValuesFromCreatureIdentification(cmd, item);
            setValuesFromCreature(cmd, item);
            setValuesFromAnimal(cmd, item);
        }

        private void setValuesFromCrustacean(MySqlCommand cmd, CrustaceanClass item)
        {
            setValuesFromCreatureIdentification(cmd, item);
            setValuesFromCreature(cmd, item);
            setValuesFromAnimal(cmd, item);
        }

        private void setValuesOnFishcmd(MySqlCommand cmd, FishClass item)
        {
            setValuesFromCreatureIdentification(cmd, item);
            setValuesFromCreature(cmd, item);
            setValuesFromAnimal(cmd, item);

            cmd.Parameters.AddWithValue("fishBaseId", item.FishBaseId);
            cmd.Parameters.AddWithValue("swimmingPositionId", item.SwimmingPosition.ID);
            cmd.Parameters.AddWithValue("tankWidth", item.TankWidth);

        }

        #endregion

        #region Set Parameter Values

        #endregion

        private bool handleDBError(Delegates.DatabaseArgs e)
        {
            if (OnDatabaseError != null)
            {
                OnDatabaseError(this, e);
                return true;
            }
            else
                return false;
        }

        private MySqlConnection getAConnection()
        {
            MySqlConnection conn = new MySqlConnection(string.Format(
                DBConnectString,
                _config.ServerIp,
                _config.Schema,
                _config.Username,
                _config.Password
                ));
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Delegates.DatabaseArgs dbArgs = null;
                switch (ex.Number)
                {
                    case 4060: // Invalid Database 
                        dbArgs = new Delegates.DatabaseArgs(ex, "Invalid Database");
                        break;
                    case 18456: // Login Failed 
                        dbArgs = new Delegates.DatabaseArgs(ex, "Login failed");
                        break;
                    default:
                        dbArgs = new Delegates.DatabaseArgs(ex);
                        break;
                }
                if (dbArgs == null)
                    dbArgs = new Delegates.DatabaseArgs(ex);
                if (OnDatabaseError != null)
                    OnDatabaseError(this, dbArgs);
            }
            return conn;
        }

        private int createCreature(CreatureIdentification item)
        {
            int insertId = 0;
            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    //TODO: Foreign keys and lists 

                    MySqlCommand cmd = new MySqlCommand(INSERT_CREATURE, conn);
                    setValues(cmd, item);
                    try
                    {
                        insertId = (int)cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        handleDBError(new Delegates.DatabaseArgs(ex));
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
            return insertId;
        }

        private bool deleteCreature(CreatureIdentification item)
        {
            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand(DELETE_CREATURE, conn);
                    cmd.Parameters.AddWithValue("id", item.ID);
                    try
                    {
                        cmd.ExecuteScalar();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        handleDBError(new Delegates.DatabaseArgs(ex));
                        return false;
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
            return false;
        }

        private bool updateCreature(CreatureIdentification item)
        {
            using (MySqlConnection conn = getAConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    doVersionControl(item);
                    MySqlCommand cmd = new MySqlCommand(UPDATE_CREATURE, conn);
                    setValues(cmd, item);
                    try
                    {
                        cmd.ExecuteScalar();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        handleDBError(new Delegates.DatabaseArgs(ex));
                        return false;
                    }
                }
                else
                {
                    handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                }
            }
            return false;
        }

        private CreatureIdentification selectCreature(int itemId, CreatureTypes creatureType)
        {
            CreatureIdentification item = null;

            switch (creatureType)
            {
                case CreatureTypes.Crustacean:
                    item = new Model.CrustaceanClass();
                    break;
                case CreatureTypes.Fish:
                    item = new Model.FishClass();
                    break;
                case CreatureTypes.Gastropoda:
                    item = new Model.GastropodaClass();
                    break;
                case CreatureTypes.Plant:
                    item = new Model.PlantClass();
                    break;
                case CreatureTypes.Reptile:
                    item = new Model.ReptileClass();
                    break;
            }
            if (item != null)
            {
                using (MySqlConnection conn = getAConnection())
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        MySqlCommand cmd = new MySqlCommand(SELECT_CREATURE, conn);
                        cmd.Parameters.AddWithValue("id", itemId);
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                            {
                                if (reader.Read())
                                {
                                    //TODO: Set commen fields
                                    switch (creatureType)
                                    {
                                        case CreatureTypes.Crustacean:
                                            //TODO: Set special Crustacean fields
                                            break;
                                        case CreatureTypes.Fish:
                                            //TODO: Set special Crustacean fields
                                            break;
                                        case CreatureTypes.Gastropoda:
                                            //TODO: Set special Crustacean fields
                                            break;
                                        case CreatureTypes.Plant:
                                            //TODO: Set special Crustacean fields
                                            break;
                                        case CreatureTypes.Reptile:
                                            //TODO: Set special Crustacean fields
                                            break;
                                    }
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            handleDBError(new Delegates.DatabaseArgs(ex));
                        }
                    }
                    else
                    {
                        handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                    }
                }
            }
            else
            {
                handleDBError(new Delegates.DatabaseArgs("creature type is unknown"));
            }
            return item;
        }

        private void doVersionControl(CreatureIdentification newItem)
        {
            CreatureIdentification oldItem = selectCreature(newItem.ID, newItem.CreatureType);
            if (oldItem != null)
            {
                using (MySqlConnection conn = getAConnection())
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        using (MySqlCommand cmdInsert = new MySqlCommand(INSERT_VERSION_CREATURE, conn))
                        {
                            setValues(cmdInsert, oldItem);
                            cmdInsert.Parameters.AddWithValue("orgId", newItem.ID);
                            try
                            {
                                cmdInsert.ExecuteScalar();
                            }
                            catch (SqlException ex)
                            {
                                handleDBError(new Delegates.DatabaseArgs(ex));
                            }
                        }
                    }
                    else
                    {
                        handleDBError(new Delegates.DatabaseArgs("Connection not open"));
                    }
                }
            }
        }

        #endregion
    }
}
