using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Runtime.ExceptionServices;

namespace CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail
{
    public sealed class DeleteUserByEmailHandler : IRequestHandler<DeleteUserByEmailRequest, DeleteUserByEmailResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public DeleteUserByEmailHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<DeleteUserByEmailResponse> Handle(DeleteUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var deleteUser= await _userRepository.GetUserByEmail(user.Email,cancellationToken);
            if(deleteUser.DateDeleted==null) {
                _userRepository.Delete(deleteUser);
                await _unitOfWork.Save(cancellationToken);
                return _mapper.Map<DeleteUserByEmailResponse>(user);
            }
            else
            {
                throw new NotFoundException("Ya se ha borrado previamente");
            }
            
        }
    }
}
