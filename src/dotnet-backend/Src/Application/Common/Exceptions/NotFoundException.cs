using System;

namespace ProgrammingChallenge.Application.Common.Exceptions
{
    public class NotFoundException<TEntity> : Exception
    {
        public NotFoundException(int id)
            : base($"Entity \"{nameof(TEntity)}\" ({id}) was not found.")
        {
        }
    }
}