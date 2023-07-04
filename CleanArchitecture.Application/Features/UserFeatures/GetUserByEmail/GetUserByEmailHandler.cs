using AutoMapper;
using CleanArchitecture.Application.Repositories;
using MediatR;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail
{
    public sealed class GetUserByEmailHandler : IRequestHandler<GetUserByEmailRequest, GetUserByEmailResponse>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByEmailHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitofWork= unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<GetUserByEmailResponse> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var email = _mapper.Map<User>(request).Email;
            var user = _userRepository.GetUserByEmail(email, cancellationToken).Result ;
            return _mapper.Map<GetUserByEmailResponse>(user);
        }
    }
}
