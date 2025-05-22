using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PosLibrary.Model;
using PosLibrary.Repo;

namespace PosTest
{
    [TestClass]
    public class UserRepositoryTests
    {
        private SqliteConnection _connection;
        private UserRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            var connString = "Data Source=file:memdb3?mode=memory&cache=shared";
            _connection = new SqliteConnection(connString);
            _connection.Open();

            var cmd = _connection.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );
                DELETE FROM Users;
                INSERT INTO Users (Username, Password, Role)
                VALUES ('admin', '1234', 'Manager'),
                       ('cashier1', 'abcd', 'Cashier');
            ";
            cmd.ExecuteNonQuery();

            _repo = new UserRepository(connString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _connection.Close();
        }

        [TestMethod]
        public void GetByUser_ShouldReturnUser_WhenValidCredentials()
        {
            var user = _repo.GetByUser("admin", "1234");

            Assert.IsNotNull(user);
            Assert.AreEqual("admin", user!.Username);
            Assert.AreEqual("1234", user.Password);
            Assert.AreEqual("Manager", user.Role);
        }

        [TestMethod]
        public void GetByUser_ShouldReturnNull_WhenInvalidUsername()
        {
            var user = _repo.GetByUser("wronguser", "1234");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetByUser_ShouldReturnNull_WhenInvalidPassword()
        {
            var user = _repo.GetByUser("admin", "wrongpass");
            Assert.IsNull(user);
        }
    }
}
