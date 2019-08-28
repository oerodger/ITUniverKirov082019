﻿using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1
{
    public class IdentityStore: IUserStore<User, long>,
        IUserPasswordStore<User, long>,
        IUserLockoutStore<User, long>,
        IUserTwoFactorStore<User, long>
    {
        private readonly ISession session;

        public IdentityStore(ISession session)
        {
            this.session = session;
        }

        #region IUserStore<User, int>
        public Task CreateAsync(User user)
        {
            return Task.Run(() => {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(user);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw;
                    }
                }                
            });
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => session.Delete(user));
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return Task.Run(() => session.Get<User>(userId));
        }

        public Task<User> FindByNameAsync(string username)
        {
            return Task.Run(() =>
            {
                return session.QueryOver<User>()
                    .Where(u => u.UserName == username)
                    .SingleOrDefault();
            });
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => session.SaveOrUpdate(user));
        }
        #endregion

        #region IUserPasswordStore<User, int>
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.Password = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            
        }
        #endregion

        #region IUserLockoutStore<User, int>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.CompletedTask;
        }
        #endregion

        #region IUserTwoFactorStore<User, int>
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.CompletedTask;
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }
        #endregion
    }
}