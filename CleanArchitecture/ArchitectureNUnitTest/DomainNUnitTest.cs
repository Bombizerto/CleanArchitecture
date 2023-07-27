using CleanArchitecture.Domain.Entities;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchitectureNUnitTest
{
    public class DomainNUnitTest
    {
        private static Assembly DomainAssembly => typeof(User).Module.Assembly;
        [Test]
        public void Test1()
        {
            var types= Types.InAssembly(DomainAssembly);
            var result= types.That().AreClasses().Should().BeSealed().Or().BeAbstract().GetResult();
            string fallos = GetFailingTypes(result);
            Assert.That(result.IsSuccessful, Is.True);
            //Assert.That(testResult.IsSuccessful, Is.True);
        }
        private string GetFailingTypes(TestResult result)
        {
            return result.FailingTypeNames != null ?
                string.Join(", ", result.FailingTypeNames) :
                string.Empty;
        }
    }
}
