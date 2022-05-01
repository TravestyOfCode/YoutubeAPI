using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeAPI.Web.Data.Queries
{
    public class GetVideosQuery : IRequest<IResult>
    {
        
    }

    public class GetVideosQueryHandler : IRequestHandler<GetVideosQuery, IResult>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<GetVideosQueryHandler> _logger;

        public GetVideosQueryHandler(ApplicationDbContext dbContext, ILogger<GetVideosQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IResult> Handle(GetVideosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Result.Ok(await _dbContext.Videos.ToListAsync(cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error handling request: {request}", request);
                return Result.ServerError();
            }
        }
    }
}
