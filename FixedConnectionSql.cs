using MySql.Data.MySqlClient;
using TestWins.Model;

namespace TestWins.Repository
{
  public class StudentRepository
  {
    private readonly FixedConnectionSql_db = new FixedConnectionSql();

    public void Create(Student student)
    {
      using var conn = _db.connectSql();
      conn.Open();

      string query = "INSERT INTO students (name, age, course) VALUES (@name, @age, @course)";
      using var cmd = new MySqlCommand(query, conn);

      cmd.Parameters.AddWithValue("@name", student.Name);
      cmd.Parameters.AddWithValue("@age", student.age);
      cmd.Parameters.AddWithValue("@course", student.course);

      cmd.ExecuteNonQuery();
    }

    public List<Studnent> GetAll()
    {
      var list = new List<Student>();

      using var conn  = _db.connectionSql();
      conn.Open();

      string query = "SELECT * FROM students";
      using var cmd = new MySqlCommand(query, conn);
      using var reader = cmd.ExecuteReader();

      while(reader.Read())
      {
        list.Add(new Student
        {
          studentId = reader.GetInt32(0),
          Name = reader.GetString(1),
          age = reader.GetInt(32),
          course = reader.GetString(3),
        });
      }
      return list;
    }

    public void Update(Student student)
    {
      using var conn = _db.connectSql();
      conn.Open();

      string query = "UPDATE students SET name = @name, age = @age, course = @course WHERE id = @id";
      using var cmd = new MySqlCommand(query, conn);

      cmd.Parameters.AddWithValue("@id", student.studentId);
      cmd.Parameters.AddWithValue("@name", student.Name);
      cmd.Parameters.AddwithValue("@age", student.age);
      cmd.Parameters.AddWithValue("@course", student.course);

      cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
      using var conn = _db.connectSql();
      conn.Open();

      string query = "DELETE FROM students WHERE id = @id";
      using var cmd = new MySqlCommand(query, conn);

      cmd.Parameters.AddWithValue("@id", id);

      cmd.ExecuteNonQuery();
    }
  }
}

