using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace VolkansUtility
{
    public static class Conversion
    {
        /// <summary>
        /// all of these methods are used as extension methods
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ListofArraytoDatatable<T>(this List<T[]> list)
        {
            DataTable table = new DataTable();

            //adding columns depending on the number for items in the array
            for (int i = 0; i < list[0].Length; i++)
            {
                table.Columns.Add("Column_" + i);
            }

            //add rows
            foreach (var arr in list)
            {
                table.Rows.Add(arr);
            }
            return table;
        }
        public static DataTable ListofSomeClassToDatatable<T>(this List<T> list)
        {
            //if experiencing performance problem, try on fastmember package
            DataTable table = new DataTable();

            //adding columns depending on the number for property of the class
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public static List<T> DatatableToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            T GetItem<T>(DataRow dr)
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }
                }
                return obj;
            }
            return data;
        }
        public static List<T> DatatableKolonToList<T>(this DataTable dt, int colindex)
        {
            return dt.Rows.OfType<DataRow>().Select(dr => dr.Field<T>(colindex)).ToList();
        }
        public static DataTable DictToDatatable<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Key");
            table.Columns.Add("Value");

            foreach (var kv in dict)
            {
                DataRow dr = table.NewRow();
                dr[0] = kv.Key;
                dr[1] = kv.Value;
                table.Rows.Add(dr);
            }
            return table;

        }
        public static ILookup<TKey, TValue> DatatabletoLookup<TKey, TValue>(this DataTable dt, int keyindex, int valueindex)
        {
            return dt.AsEnumerable().ToLookup<DataRow, TKey, TValue>(
                row => row.Field<TKey>(keyindex),
                row => row.Field<TValue>(valueindex)
                );
        }
        public static Dictionary<TKey, TValue> DatatabletoDictionary<TKey, TValue>(this DataTable dt, int keyindex, int valueindex)
        {
            return dt.AsEnumerable().ToDictionary<DataRow, TKey, TValue>(
                row => row.Field<TKey>(keyindex),
                row => row.Field<TValue>(valueindex)
                );
        }
        public static DataTable DatagridviewToDatatable(this DataGridView dgv)
        {
            return (DataTable)(dgv.DataSource);
        }
        public static List<T> DatagridviewKolonToList<T>(this DataGridView dgv,int colindex)
        {
            List<T> mylist = new List<T>();
            try
            {
                mylist = dgv.DataSource as List<T>;
                return mylist;
            }
            catch (Exception)
            {
                foreach (DataGridViewRow dgr in dgv.Rows)
                {
                    mylist.Add(Cast(dgr.Cells[colindex].Value, typeof(T)));
                }
                    dynamic Cast(dynamic obj, Type castTo)
                    {
                        return Convert.ChangeType(obj, castTo);
                    }
                return mylist;
            }
        }
        public static Dictionary<TKey,TValue> TwoListtoDictionary<TKey,TValue>(this List<TKey> list1,List<TValue> list2)
        {
            return list1.Zip(list2, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
            //or return Enumerable.Range(0, list1.Count).ToDictionary(i => list1[i], i => list2[i]);            
        }
        public static List<Tuple<T1,T2,T3>> DatatableToListOfTuples<T1,T2,T3>(this DataTable dt,int i, int j, int k)
        {
            List<Tuple<T1, T2, T3>> list = new List<Tuple<T1, T2, T3>>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(Tuple.Create((T1)dr[i], (T2)dr[j], (T3)dr[k]));
            }
            return list;
        }
        public static List<string> rangeToList(Excel.Range inputRng, bool isDistinct=false, bool isToLower=true)
        {
            object[,] cellValues = (object[,])inputRng.Value2;
            List<string> lst;
            if (isToLower)
                lst = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x).ToLower());
            else
                lst = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));

            if (isDistinct)
                lst = lst.Distinct().ToList();
            return lst;
        }
    } 
}
