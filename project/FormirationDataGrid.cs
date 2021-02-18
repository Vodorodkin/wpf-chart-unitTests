using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    using System;
    using System.Data;

    public static class FormirationDataGrid
    {
        public static DataTable ToDataTable<T>(T[] arr,string namecol) //одномерный
        {
            
            var res = new DataTable();
            
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add($"{namecol}" + i, typeof(T));

            }
            var row = res.NewRow();

            for (int i = 0; i < arr.Length; i++)
            {
                
                row[i] = arr[i];
            }
            res.Rows.Add(row);

            return res;
        }
        public static DataTable ToDataTable<T>(T[,] matrix, string namecol) //двумерный
        {
            var res = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add($"{namecol}" + i, typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }
    }
}
