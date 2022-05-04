using CSharpFunctionalExtensions;

using NHibernate;

using System.Data;

namespace SchoolManagement.Data
{
    public class UnitOfWork : IAsyncDisposable
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private bool _isAlive = true;
        private bool _isCommitted;

        public UnitOfWork()
        {
            _session = SessionFactory.OpenSession();
            _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public async ValueTask DisposeAsync()
        {
            if (!_isAlive)
                return;

            _isAlive = false;

            try
            {
                if (_isCommitted)
                {
                    await _transaction.CommitAsync();
                }
            }
            finally
            {
                _transaction.Dispose();
                _session.Dispose();
            }
        }

        public void Commit()
        {
            if (!_isAlive)
                return;

            _isCommitted = true;
        }

        internal async Task<Maybe<T>> GetAsync<T>(long id) where T : class
        {
            return await _session.GetAsync<T>(id);
        }

        internal async Task SaveOrUpdateAsync<T>(T entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        internal async Task DeleteAsync<T>(T entity)
        {
            await _session.DeleteAsync(entity);
        }

        internal IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
    }
}
