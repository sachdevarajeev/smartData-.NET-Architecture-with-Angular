using Dapper;
using Dapper.FluentColumnMapping;
using Microsoft.Extensions.Configuration;
using SmartData.Sample.DataContract;
using SmartData.Sample.DataContract.Enums;
using SmartData.Sample.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Threading.Tasks;

namespace SmartData.Sample.Repository
{
    // <summary>
    ///  Base Repository to work with database.
    /// </summary>    
    public class BaseRepository : IBaseRepository
    {
        public IConfiguration Configuration;

        // Sql connection string for SYNC_DB database
        private string _sync_DB_ConnectionString = string.Empty;

        // Sql connection string for Database2 database
        private string _database2ConnectionString = string.Empty;

        // column mapping collection
        private ColumnMappingCollection _mappings = null;

        public BaseRepository(IConfiguration configuration)
        {
            _mappings = new ColumnMappingCollection();

            Configuration = configuration;

            _sync_DB_ConnectionString = configuration
                                .GetSection("Data:Sync_DB")
                                .GetSection("DbConnectionString").Value;

            _database2ConnectionString = configuration
                               .GetSection("Data:Database2")
                               .GetSection("DbConnectionString").Value;
        }

        /// <summary>
        /// Gets HealthCheck for Base Repository. Declared virtual for other Repositories to override.
        /// </summary>
        /// <returns>UTC datetime</returns>
        public virtual async Task<object> HealthCheckAsync()
        {
            DateTime currentUtcDateTime = DateTime.MinValue;

            #region Un Comment when actual database used like 'SYNC_DB'.
            //var sql = "Select GetUtcDate()";

            //currentUtcDateTime = await GetFirstOrDefaultAsync<DateTime>(sql, null, commandType: CommandType.Text, databaseName: DatabaseName.SYNC_DB);
            #endregion
            currentUtcDateTime = DateTime.Now;

            return currentUtcDateTime;
        }

        /// <summary>
        /// Returns the first result set based on the type of the requested entity.
        /// Example : To get details of an address based on address id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public T GetFirstOrDefault<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            T result = default(T);

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = conn.QueryFirstOrDefault<T>(sql, parameters, null, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Returns the first result set based on the type of the requested entity.
        /// Example : To get details of an address based on address id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public async Task<T> GetFirstOrDefaultAsync<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            T result = default(T);

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = await conn.QueryFirstOrDefaultAsync<T>(sql, parameters, null, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Returns an collection of the type of requested entity.
        /// Example: To list of all address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public IEnumerable<T> Get<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            IEnumerable<T> result = default(IEnumerable<T>);

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = conn.Query<T>(sql, parameters, null, true, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Returns an collection of the type of requested entity.
        /// Example: To list of all address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param> 
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            IEnumerable<T> result = default(IEnumerable<T>);

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = await conn.QueryAsync<T>(sql, parameters, null, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Adds an entity. 
        /// The onus of getting the Id of the newly added entity is on each class that implements this API.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param> 
        /// <returns></returns>
        public int Add(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            var result = 0;

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = conn.Execute(sql, parameters, null, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Adds an entity. 
        /// The onus of getting the Id of the newly added entity is on each class that implements this API.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param> 
        /// <returns></returns>
        public async Task<int> AddAsync(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            var result = 0;

            using (IDbConnection conn = GetConnection(databaseName))
            {
                result = await conn.ExecuteAsync(sql, parameters, null, commandTimeout, commandType);
            }

            return result;
        }

        /// <summary>
        /// Updates an entity. 
        /// The onus of getting the Id of the newly added entity is on each class that implements this API.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>  
        /// <returns></returns>
        public async Task<int> UpdateAsync(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            return await this.AddAsync(sql, parameters, commandTimeout, commandType, databaseName);
        }

        /// <summary>
        /// Deletes an entity. 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>   
        protected async Task DeleteAsync(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            using (IDbConnection conn = GetConnection(databaseName))
            {
                await conn.ExecuteAsync(sql, parameters, null, commandTimeout, commandType);
            }
        }

        /// <summary>
        /// Returns multiple results based on the types specified.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>   
        /// <returns></returns>
        public async Task<dynamic> GetMultipleAsync<T1, T2>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB)
        {
            dynamic result = new ExpandoObject();

            using (IDbConnection conn = GetConnection(databaseName))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, parameters, null, commandTimeout, commandType))
                {
                    var t1 = multi.Read<T1>();
                    var t2 = multi.Read<T2>();

                    result.Item1 = t1;
                    result.Item2 = t2;
                }
            }

            return result;
        }

        /// <summary>
        /// Registers the list of properties which you would like to map to it's corresponsing sql column name.
        /// This is usually used where your object's property name is different from the underline sql column name.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="columns">list fo columns</param>
        public void RegisterColumnMappings<T>(IEnumerable<SqlColumnMapping> columns)
        {
            // register only if the type is not already added to the mapping collection
            if (!_mappings.Mappings.Keys.Contains(typeof(T)))
            {
                var mappedType = _mappings.RegisterType<T>();

                foreach (var item in columns)
                {
                    mappedType
                    .MapProperty(item.Source).ToColumn(item.Target);
                }

                // register with dapper
                _mappings.RegisterWithDapper();
            }
        }

        /// <summary>
        /// Returns the sql connection based on the database against which the comnection is requested for.
        /// The default is against SYNC_DB database.
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private IDbConnection GetConnection(DatabaseName databaseName)
        {
            string connectionString = _sync_DB_ConnectionString;

            if (databaseName == DatabaseName.SYNC_DB)
            {
                connectionString = _sync_DB_ConnectionString;
            }
            else if (databaseName == DatabaseName.Database2)
            {
                connectionString = _database2ConnectionString;
            }

            return new SqlConnection(connectionString);
        }
    }
}
