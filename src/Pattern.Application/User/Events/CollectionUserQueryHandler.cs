using Pattern.Domain.Common;
using Pattern.Domain.Shared;
using Pattern.Application.User;
using Pattern.Application.User.Queries;
using Pattern.Infrastructure.Repositories;
using AutoMapper;

namespace Pattern.Application.User.Events
{
    public class CollectionUserQueryHandler : IQueryHandler<CollectionUserQuery, Result<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository<Pattern.Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public CollectionUserQueryHandler(
            IUserRepository<Pattern.Domain.Entities.User> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserDto>>> Handle(CollectionUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
                return Result<IEnumerable<UserDto>>.Success(userDtos);
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                return Result<IEnumerable<UserDto>>.Failure($"An error occurred while retrieving users: {ex.Message}");
            }
        }             
    }
}