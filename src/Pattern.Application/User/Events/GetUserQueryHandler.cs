using AutoMapper;
using Pattern.Application.User.Queries;
using Pattern.Domain.Common;
using Pattern.Domain.Shared;
using Pattern.Infrastructure.Repositories;

namespace Pattern.Application.User.Events
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, Result<UserDto>>
    {
        private readonly IUserRepository<Pattern.Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(
            IUserRepository<Pattern.Domain.Entities.User> userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                var userDto = _mapper.Map<UserDto>(user);
                return Result<UserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return Result<UserDto>.Failure($"An error occurred while retrieving the user: {ex.Message}");
            }
        }
    }
}