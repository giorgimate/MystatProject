using Microsoft.Data.SqlClient;
using Mystat.Models;
using MystatService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MystatService
{
    public class TeacherService : ITeacherService
    {
        public async Task AddNewTeacherAsync(Teacher teacher)
        {
            const string sqlExpression = "sp_addNewTeacher";
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("firstName", teacher.FirstName);
                    command.Parameters.AddWithValue("lastName", teacher.LastName);
                    command.Parameters.AddWithValue("pin", teacher.Pin);
                    command.Parameters.AddWithValue("phoneNumber", teacher.PhoneNumber);
                    command.Parameters.AddWithValue("email", teacher.Email);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task DeleteManyTeachersAsync(params int[] ids)
        {
            foreach (var idToDelete in ids)
            {
                string sqlExpression = $"DELETE FROM Teacher WHERE Id ={idToDelete}";
                using (SqlConnection connection = new(HelperConfig.ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = CommandType.Text;
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        await connection.CloseAsync();
                    }
                }
            }
        }

        public async Task DeleteTeacherAsync(int id)
        {
            const string sqlExpression = "sp_deleteTeacher";
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            List<Teacher> result = new();
            const string sqlExpression = "sp_getAllTeachers";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new Teacher
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                                Pin = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                PhoneNumber = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                Email = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty
                            });







                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }


            return result;
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            Teacher result = new();
            const string sqlExpression = "sp_getTeacherById";

            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Id = reader.GetInt32(0);
                            result.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                            result.Pin = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                            result.PhoneNumber = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            result.Email = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;

                        }

                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }


            return result;
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            const string sqlExpression = "sp_updateTeacher";
            using (SqlConnection connection = new(HelperConfig.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("firstName", teacher.FirstName);
                    command.Parameters.AddWithValue("lastName", teacher.LastName);
                    command.Parameters.AddWithValue("pin", teacher.Pin);
                    command.Parameters.AddWithValue("phoneNumber", teacher.PhoneNumber);
                    command.Parameters.AddWithValue("email", teacher.Email);
                    command.Parameters.AddWithValue("id", teacher.Id);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
    }
}
