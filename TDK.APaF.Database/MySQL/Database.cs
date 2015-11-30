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

        #region Consts
        private const string DBConnectString = "Server={0};Database={1};Uid={2};Pwd={3};ConvertZeroDateTime=True;"
            + "tablecache=true;DefaultTableCacheAge=30;UseCompression=True;Pooling=True;";
        //private const string DBConnectString = "Server={0};Database={1};Uid={2};Pwd={3};";
        private const string InsertCreatures = "INSERT INTO `creaturesandplants`"
            + "(`creatuteType`,`aqualogCode`,`createId`,`dataSource`,`familyId`,`minHardness`,`maxHardness`,`minLight`,`maxLight`,`minPh`,`maxPh`,`regionId`,"
            + "`scientificNameId`,`minTemperature`,`maxTemperature`,`danishTradenames`,`englishTradenames`,`germanTradenames`,`groupTypeId`,`protected`,`waterType`,"
            + "`bottomTypeId`,`flowering`,`growthSpeedId`,`hardy`,`minHeight`,`maxHeight`,`minWidth`,`maxWidth`,`waterDepth`,`zone`,`fishBaseId`,`minSize`,`maxSize`,"
            + "`swimmingPositionId`,`tankWidth`) VALUES("
            + "@creatuteType, @aqualogCode, @createId, @dataSource, @familyId, @minHardness, @maxHardness, @minLight, @maxLight, @minPh, @maxPh, @regionId, @scientificNameId,"
            + "@minTemperature, @maxTemperature, @danishTradenames, @englishTradenames, @germanTradenames, @groupTypeId, S@protected,"
            + "@waterType, @bottomTypeId, @flowering, @growthSpeedId, @hardy, @minHeight, @maxHeight, @minWidth, @maxWidth, @waterDepth, @zone, @fishBaseId, @minSize,"
            + "@maxSize, @swimmingPositionId, @tankWidth);SELECT last_insert_id();";
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete the fish in the database
        /// </summary>
        /// <param name="item">The item to delete</param>
        /// <returns>True if successfull, false if not</returns>
        /// <exception cref="Exceptions.CreatureNotFound">Thrown if fish is not found</exception>
        public bool DeleteFish(FishClass item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a Gastropoda in the database
        /// </summary>
        /// <param name="item">The Gastropoda to create</param>
        /// <returns>The Gastropoda with updated database id</returns>
        /// <exception cref="Exceptions.CreatureAlreadyExists">Thrown if gastropoda already exists</exception>
        public GastropodaClass CreateGastropoda(GastropodaClass item)
        {
            item.ID= createCreature(item);
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        #endregion

        #region Private methods
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
        }

        private void setValuesFromCreature(MySqlCommand cmd, Creatures item)
        {

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


            cmd.Parameters.AddWithValue("aqualogCode", item.AquaLogCode);
            cmd.Parameters.AddWithValue("createId", item.Created.ID);
            cmd.Parameters.AddWithValue("dataSource", (int)item.DataSource);
            cmd.Parameters.AddWithValue("familyId", item.Family.ID);
            cmd.Parameters.AddWithValue("minHardness", item.Hardness.MinValue);
            cmd.Parameters.AddWithValue("maxHardness", item.Hardness.MaxValue);
            cmd.Parameters.AddWithValue("minLight", (int)item.Light.MinLight);
            cmd.Parameters.AddWithValue("maxLight", (int)item.Light.MaxLight);
            cmd.Parameters.AddWithValue("minPh", item.PH.MinValue);
            cmd.Parameters.AddWithValue("maxPh", item.PH.MaxValue);
            cmd.Parameters.AddWithValue("regionId", item.Region.ID);
            cmd.Parameters.AddWithValue("scientificNameId", item.ScientificName.ID);
            cmd.Parameters.AddWithValue("minTemperature", item.Temperature.MinValue);
            cmd.Parameters.AddWithValue("maxTemperature", item.Temperature.MaxValue);
            cmd.Parameters.AddWithValue("danishTradenames", item.Tradenames.Danish);
            cmd.Parameters.AddWithValue("englishTradenames", item.Tradenames.English);
            cmd.Parameters.AddWithValue("germanTradenames", item.Tradenames.German);
            cmd.Parameters.AddWithValue("groupTypeId", item.Group.ID);
            cmd.Parameters.AddWithValue("protected", item.Protected.ID);
            cmd.Parameters.AddWithValue("waterType", (int)item.WaterType);
            cmd.Parameters.AddWithValue("bottomTypeId", 0); //TODO: Not valid
            cmd.Parameters.AddWithValue("flowering", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("growthSpeedId", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("hardy", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("minHeight", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("maxHeight", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("minWidth", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("maxWidth", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("waterDepth", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("zone", "");//TODO: Not valid
            cmd.Parameters.AddWithValue("fishBaseId", item.FishBaseId);
         
            //cmd.Parameters.AddWithValue("specialId", "");
            cmd.Parameters.AddWithValue("swimmingPositionId", item.SwimmingPosition.ID);
            cmd.Parameters.AddWithValue("tankWidth", item.TankWidth);
            //cmd.Parameters.AddWithValue("foodTypeId", item.f); Changed to a list
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
                if (OnDatabaseError != null)
                    OnDatabaseError(this, new Delegates.DatabaseArgs(ex));
                /*
                switch (ex.Number)
                {
                    case 4060: // Invalid Database 
                        break;
                    case 18456: // Login Failed 
                        break;
                    default:
                        break;
                }
                */
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
                    MySqlCommand cmd = new MySqlCommand(InsertCreatures, conn);
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
            }
            return insertId;
        }



        #endregion
    }
}
