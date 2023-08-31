using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectsComparator
{
    internal static class ObjectsComparator
    {
        public static bool ObjectsAreEquals<T>(T entity1, T entity2) where T : class
        {
            var props = entity1.GetType().GetProperties().ToList();

            foreach (var prop in props)
            {
                if (!IsSystemType(prop.PropertyType))
                {
                    if (!ObjectsAreEquals(prop.GetValue(entity1), prop.GetValue(entity2))) return false;
                }
                else if ((prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>)) ||
                        prop.PropertyType.IsArray)
                {
                    object[] list1 = ConvertToList(entity1, entity1.GetType().GetProperty(prop.Name));
                    object[] list2 = ConvertToList(entity2, entity2.GetType().GetProperty(prop.Name));

                    if (list1.Length != list2.Length) return false;

                    for (int i = 0; i < list1.Length; i++)
                        if (!ObjectsAreEquals(list1[i], list2[i])) return false;
                }
                else if (!prop.GetValue(entity1).Equals(prop.GetValue(entity2)))
                {
                    return false;
                }
            }

            return true;
        }

        private static object[] ConvertToList<T>(T entity2, PropertyInfo childPropsEntity2) where T : class
        {
            object listEntity2 = childPropsEntity2.GetValue(entity2);
            List<object> list2 = new List<object>();
            if (listEntity2 is IEnumerable enumerableEntity2)
                list2 = enumerableEntity2.Cast<object>().ToList();

            return list2.ToArray();
        }

        static bool IsSystemType(Type type)
        {
            var assembly = type.Assembly;

            if (assembly.FullName.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase) ||
                assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
