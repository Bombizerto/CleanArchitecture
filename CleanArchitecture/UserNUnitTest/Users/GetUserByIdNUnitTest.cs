
using AutoFixture;
using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using AutoMapper;
using CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail;

namespace UserNUnitTest.Users
{
    [TestFixture]
    public class GetUserByIdNUnitTest
    {
        private GetUserByEmailHandler handlerGetUserByEmail;
        private IMapper? mapper;
        [SetUp]
        public void SetUp()
        {
            Fixture fixture = new();

            List<User>? makeUpUsers = fixture.CreateMany<User>().ToList();

            makeUpUsers.Add(fixture.Build<User>()
                .With(tr => tr.Id, Guid.Empty)
                .Create()
            );
            makeUpUsers.Add(
                new User
                {
                    Email = "emailprueba@gmail.com",
                    Id = Guid.NewGuid(),
                    Name = "namePrueba"
                }
            );
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: $"CleanArchitectureDbContext-{Guid.NewGuid}")
                .Options;

            DataContext cleanArchitectureContextFake = new DataContext(options);
            cleanArchitectureContextFake.AddRange(makeUpUsers);
            cleanArchitectureContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GetUserByEmailMapper());
            });

            mapper = mapConfig.CreateMapper();
            UserRepository _userRepository = new(cleanArchitectureContextFake);

            handlerGetUserByEmail = new GetUserByEmailHandler(new UnitOfWork(cleanArchitectureContextFake), _userRepository, mapper);
        }
        [Test]
        public async Task GetUserByEmail_InputEmail_ReturnsUser()
        {
            String emailBusqueda = "emailprueba@gmail.com";
            GetUserByEmailRequest request = new(emailBusqueda);
            var result = await handlerGetUserByEmail.Handle(request, new System.Threading.CancellationToken());
            User? user = mapper.Map<User>(result);
            Assert.That(user.Email, Is.EqualTo(emailBusqueda));
        }
    }
}
