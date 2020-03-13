using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RxWeb.Core;
using FBRxweb.UnitOfWork.Main;
using FBRxweb.Models.Main;
using RxWeb.Core.Data;
using FBRxweb.BoundedContext.SqlContext;
using Microsoft.Data.SqlClient;
using FBRxweb.Models.ViewModels;

namespace FBRxweb.Domain.LogActivitieModule
{
    public class LogActivityDomain : ILogActivityDomain
    {
        public LogActivityDomain(ILogActivitiesUow uow, IDbContextManager<MainSqlDbContext> dbContextManager) {
            this.Uow = uow;
            DbContextManager = dbContextManager;
        }

        public async Task<object> GetAsync(LogActivity parameters)
        {
            var spParameters = new SqlParameter[2];

            spParameters[0] = new SqlParameter() { ParameterName = "userid", Value = parameters.UserId };
            spParameters[1] = new SqlParameter() { ParameterName = "postid", Value = parameters.PostId };

            //  spParameters[7] = new SqlParameter() { ParameterName = "Flag", Value = "@flag" };
            //  spParameters[7].Direction = System.Data.ParameterDirection.Output;

            return await DbContextManager.StoreProc<StoreProcResult>("[dbo].spShareLogActivities ", spParameters);
            try
            {
                await DbContextManager.CommitAsync();
            }
            catch (Exception e)
            {
                DbContextManager.RollbackTransaction();
            }
        }

        public async Task<object> GetBy(LogActivity parameters)
        {
            var spParameters = new SqlParameter[2];
            
            spParameters[0] = new SqlParameter() { ParameterName = "userid", Value = parameters.UserId };
            spParameters[1] = new SqlParameter() { ParameterName = "postid", Value = parameters.PostId };

            //  spParameters[7] = new SqlParameter() { ParameterName = "Flag", Value = "@flag" };
            //  spParameters[7].Direction = System.Data.ParameterDirection.Output;

            return await DbContextManager.StoreProc<StoreProcResult>("[dbo].spLikeLogActivities ", spParameters);
            try
            {
                await DbContextManager.CommitAsync();
            }
            catch (Exception e)
            {
                DbContextManager.RollbackTransaction();
            }
        }
        

        public HashSet<string> AddValidation(LogActivity entity)
        {
            return ValidationMessages;
        }

        public async Task AddAsync(LogActivity parameters)
        {

            //await DbContextManager.BeginTransactionAsync();

            var spParameters = new SqlParameter[3];
            spParameters[0] = new SqlParameter() { ParameterName = "Comment", Value = parameters.Comment };
            spParameters[1] = new SqlParameter() { ParameterName = "userid", Value = parameters.UserId };
            spParameters[2] = new SqlParameter() { ParameterName = "postid", Value = parameters.PostId };
            
            //  spParameters[7] = new SqlParameter() { ParameterName = "Flag", Value = "@flag" };
            //  spParameters[7].Direction = System.Data.ParameterDirection.Output;

            await DbContextManager.StoreProc<StoreProcResult>("[dbo].spLogActivities ", spParameters);
            try
            {
                await DbContextManager.CommitAsync();
            }
            catch (Exception e)
            {
                DbContextManager.RollbackTransaction();
            }
        }

        public HashSet<string> UpdateValidation(LogActivity entity)
        {
            return ValidationMessages;
        }

        public async Task UpdateAsync(LogActivity entity)
        {
            await Uow.RegisterDirtyAsync(entity);
            await Uow.CommitAsync();
        }

        public HashSet<string> DeleteValidation(LogActivity parameters)
        {
            return ValidationMessages;
        }

        public Task DeleteAsync(LogActivity parameters)
        {
            throw new NotImplementedException();
        }

        public ILogActivitiesUow Uow { get; set; }

        private HashSet<string> ValidationMessages { get; set; } = new HashSet<string>();
        private IDbContextManager<MainSqlDbContext> DbContextManager { get; set; }
    }

    public interface ILogActivityDomain : ICoreDomain<LogActivity, LogActivity> { }
}
