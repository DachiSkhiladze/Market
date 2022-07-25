using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Declarations.Shared
{
    public record GetQuery<TEntity, TModel>(Expression<Func<TEntity, bool>> predicate) : IStreamRequest<TModel>;
}
