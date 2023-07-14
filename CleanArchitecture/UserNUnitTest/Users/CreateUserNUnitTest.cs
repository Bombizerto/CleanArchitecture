
using AutoFixture;
using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using AutoMapper;
namespace UserNUnitTest.Users
{
    [TestFixture]
    public class CreateUserNUnitTest
    {
        private CreateUserHandler handlerCreateUser;
        private IMapper? mapper;
        [SetUp]
        public void SetUp()
        {
            Fixture fixture = new();

            List<User>? makeUpUsers = fixture.CreateMany<User>().ToList();

            makeUpUsers.Add(fixture.Build<User>()
                .With(tr=>tr.Id, Guid.Empty)
                .Create()
            );

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: $"CleanArchitectureDbContext-{Guid.NewGuid}")
                .Options;
            DataContext cleanArchitectureContextFake = new DataContext(options);
            cleanArchitectureContextFake.AddRange(makeUpUsers);
            cleanArchitectureContextFake.SaveChanges();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateUserMapper());
            });

            mapper = mapConfig.CreateMapper();
            UserRepository _userRepository= new(cleanArchitectureContextFake);
            handlerCreateUser = new CreateUserHandler(new UnitOfWork(cleanArchitectureContextFake), _userRepository, mapper);
        }
        [Test]
        public async Task CreateUser_InputUser_ReturnsCreatedUser()
        {
            String email = "EmailPrueba@gmail.com";
            String nombre = "UsuarioPrueba";
            CreateUserRequest request = new(email,nombre);
            var result = await handlerCreateUser.Handle(request, new System.Threading.CancellationToken());
            User? user = mapper.Map<User>(result);

            Assert.That(user.Name, Is.EqualTo(nombre));
            Assert.That(user.Email, Is.EqualTo(email));
            Assert.That(user.Id, !Is.EqualTo(null));

        }
    }
}
