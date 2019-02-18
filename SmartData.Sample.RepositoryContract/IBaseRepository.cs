using SmartData.Sample.DataContract;
using SmartData.Sample.DataContract.Enums;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SmartData.Sample.RepositoryContract
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Gets HealthCheck for Base Repository.
        /// </summary>
        /// <returns>UTC Datetime</returns>
        Task<object> HealthCheckAsync();

        /// <summary>
        /// Returns one (first) element of the result set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        T GetFirstOrDefault<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Returns one (first) element of the result set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        Task<T> GetFirstOrDefaultAsync<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Returns list of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        IEnumerable<T> Get<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Returns list of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync<T>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Inserts an entity and returns the id of the newly inserted entity
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        int Add(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Inserts an entity and returns the id of the newly inserted entity
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        Task<int> AddAsync(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

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
        Task<dynamic> GetMultipleAsync<T1, T2>(string sql, object parameters = null, int? commandTimeout = null, CommandType? commandType = null, DatabaseName databaseName = DatabaseName.SYNC_DB);

        /// <summary>
        /// Registers the list of properties which you would like to map to it's corresponsing sql column name.
        /// This is usually used where your object's property name is different from the underline sql column name.
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="columns">list fo columns</param>
        void RegisterColumnMappings<T>(IEnumerable<SqlColumnMapping> columns);
    }
}
