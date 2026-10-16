using Xunit;

namespace RaceDayAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestProject_IsWorking()
        {
            Assert.True(true);
        }


    [Fact]
        public void UserEmail_ShouldNotBeEmpty()
        {
            string email = "student@example.com";

            Assert.False(string.IsNullOrWhiteSpace(email));
        }

        [Fact]
        public void UserRole_ShouldBeParticipantOrOrganiser()
        {
            string role = "Participant";

            Assert.True(
                role == "Participant" || role == "Organiser"
            );
        }
    }

}
