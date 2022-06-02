using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace WebApiRepository.Utilities
{
    public abstract class QueriesHelper<T>
    {

        public static string GetTableName(T entity)
        {
            return entity.GetType().Name;
        }

        public static PropertyInfo[] GetTableFields(T entity)
        {
            var properties = entity.GetType().GetProperties();
            return properties;
        }

        public static string Insert(T entity)
        {
            var tableName = GetTableName(entity);
            var tableFields = GetTableFields(entity);

            StringBuilder query = new StringBuilder();
            StringBuilder criteria = new StringBuilder();

            foreach (var field in tableFields)
            {
                if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "string" && field.Name != "Id")
                    criteria.AppendLine($" '{field.GetValue(entity)}', ");
                else if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "boolean")
                {
                    var value = field.GetValue(entity).ToString() == "true" ? 1 : 0;
                    criteria.AppendLine($" {value}, ");
                }
                else if (field.GetValue(entity) != null && field.Name != "Id")
                    criteria.AppendLine($" {field.GetValue(entity)}, ");
            }

            query.AppendLine($"Insert into [dbo].[{tableName}]");
            query.Append(" OUTPUT INSERTED.Id ");
            query.Append($"values ({criteria.ToString().Remove(criteria.ToString().LastIndexOf(","))})");

            return query.ToString();
        }

        public static string Insert(List<T> entity)
        {
            var tableName = GetTableName(entity.FirstOrDefault());
            var tableFields = GetTableFields(entity.FirstOrDefault());

            StringBuilder query = new StringBuilder();
            StringBuilder criteria = new StringBuilder();
            StringBuilder inserts = new StringBuilder();

            foreach (var data in entity)
            {
                foreach (var field in tableFields)
                {
                    if (field.GetValue(data) != null)
                    {
                        if (field.PropertyType.Name.ToLower() == "string")
                            criteria.AppendLine($" '{field.GetValue(data)}', ");
                        else if (field.PropertyType.Name.ToLower() == "boolean")
                        {
                            var value = field.GetValue(data).ToString() == "true" ? 1 : 0;
                            criteria.AppendLine($" {value}, ");
                        }
                        else if (field.Name != "Id")
                            criteria.AppendLine($" {field.GetValue(data)}, ");
                    }
                }

                inserts.AppendLine($" ({criteria.ToString().Remove(criteria.ToString().LastIndexOf(", "))}), ");
                criteria.Clear();
            }

            query.AppendLine($"Insert into [dbo].[{tableName}]");
            query.Append($"values {inserts.ToString().Remove(inserts.ToString().LastIndexOf(", "))}");

            return query.ToString();
        }

        public static string Select(T entity)
        {
            var tableName = GetTableName(entity);
            var tableFields = GetTableFields(entity);

            StringBuilder query = new StringBuilder();
            StringBuilder fields = new StringBuilder();
            StringBuilder criteria = new StringBuilder();

            foreach (var field in tableFields)
            {
                fields.AppendLine($"{field.Name}, ");

                if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "string")
                    criteria.AppendLine($"{field.Name} = '{field.GetValue(entity)}' and ");
                else if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "boolean")
                {
                    var value = field.GetValue(entity).ToString() == "true" ? 1 : 0;
                    criteria.AppendLine($"{field.Name} = {value} and");
                }
                else if (field.GetValue(entity) != null)
                    criteria.AppendLine($"{field.Name} = {field.GetValue(entity)} and ");
            }

            query.AppendLine($"Select {fields.ToString().Remove(fields.ToString().LastIndexOf(","))}");
            query.AppendLine($" from [dbo].[{tableName}]");
            query.AppendLine($" where {criteria.ToString().Remove(criteria.ToString().LastIndexOf("and"))}");

            return query.ToString();
        }

        public static string Delete(T entity)
        {
            var tableName = GetTableName(entity);
            var id = entity.GetType().GetProperty("Id");

            StringBuilder query = new StringBuilder();

            query.AppendLine($"Delete from [dbo].[{tableName}]");
            query.AppendLine($" where Id = {id.GetValue(entity)}");

            return query.ToString();
        }

        public static string Update(T entity)
        {
            var tableName = GetTableName(entity);
            var tableFields = GetTableFields(entity);
            var id = entity.GetType().GetProperty("Id");

            StringBuilder query = new StringBuilder();
            StringBuilder criteria = new StringBuilder();

            foreach (var field in tableFields)
            {
                if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "string" && field.Name != "Id")
                    criteria.AppendLine($"{field.Name} = '{field.GetValue(entity)}', ");
                else if (field.GetValue(entity) != null && field.PropertyType.Name.ToLower() == "boolean")
                {
                    var value = field.GetValue(entity).ToString() == "true" ? 1 : 0;
                    criteria.AppendLine($"{field.Name} = {value}, ");
                }
                else if (field.GetValue(entity) != null && field.Name != "Id")
                    criteria.AppendLine($"{field.Name} = {field.GetValue(entity)}, ");
            }

            query.AppendLine($"Update [dbo].[{tableName}]");
            query.Append($"Set {criteria.ToString().Remove(criteria.ToString().LastIndexOf(","))}");
            query.AppendLine($" where Id = {id.GetValue(entity)}");

            return query.ToString();
        }
    }
}
