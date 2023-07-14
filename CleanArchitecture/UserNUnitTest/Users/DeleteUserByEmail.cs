using AutoFixture;
using CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using AutoMapper;
using CleanArchitecture.Application.Features.UserFeatures.CreateUser;

namespace UserNUnitTest.Users
{
    [TestFixture]
    public class DeleteUserByEmail
    {
        private DeleteUserByEmailHandler handlerDeleteUser;
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
                cfg.AddProfile(new DeleteUserByEmailMapper());
            });

            mapper = mapConfig.CreateMapper();
            UserRepository _userRepository = new(cleanArchitectureContextFake);
            handlerDeleteUser= new DeleteUserByEmailHandler(new UnitOfWork(cleanArchitectureContextFake), _userRepository, mapper);
        }
        [Test]
        public async Task DeleteUserByEmail_InputEmail_ReturnsUser()
        {
            string email = "emailprueba@gmail.com";
            string nombre = "prueba";
            DeleteUserByEmailRequest request = new(email, nombre);
            var result= await handlerDeleteUser.Handle(request, new System.Threading.CancellationToken());
            User? user = mapper.Map<User>(result);
            Assert.That(user.Email, Is.EqualTo(email));
        }
    }
}
