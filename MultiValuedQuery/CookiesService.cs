using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiValuedQuery.Models.Database;

namespace MultiValuedQuery
{
    public class CookiesService
    {
        private readonly MyCookies1Entities _db = new MyCookies1Entities();

        /// <summary>
        /// 傳入多個商品類別查詢產品, 以 Linq Contains 語句進行處理
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public List<ViewProduct> GetProductsWithLinqContains(List<int> categories)
        {
            var products = new List<ViewProduct>();
            _db.Database.Log = Console.Write;       // Entity Framework 產生的 SQL 指令, 由 Console.Write 輸出

            products = _db.ViewProducts.Where(x => categories.Contains(x.CategoryId)).ToList();

            return products;
        }

        /// <summary>
        /// 傳入多個商品類別查詢產品, 以 T-SQL IN 語句進行處理
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        public List<ViewProduct> GetProductsWithSqlIn(List<int> categories)
        {

            var products = new List<ViewProduct>();
            _db.Database.Log = Console.Write;       // Entity Framework 產生的 SQL 指令, 由 Console.Write 輸出

            // -------------------
            // STEP 1: 原始的 sql 字串
            // -------------------
            string sql = @"
SELECT		A.ProductId
    ,       A.ProductName
    ,       A.CategoryId
    ,       A.Price
    ,       A.CategoryName
FROM		ViewProducts	A 
WHERE		A.CategoryId    IN	"
;

            // -------------------
            // STEP 2: 建立 IN 的參數
            // -------------------
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            int i = 1;
            foreach (var category in categories)
            {
                // IN clause
                sb.Append("@category_" + i + ",");
                // parameters
                parameters.Add(new SqlParameter("@category_" + i, SqlDbType.Int) { Value = category });
                i++;
            }

            //去除最後的 "," ; 並加上 左/右 括號 及分號
            string strIn = sb.ToString();
            strIn = "(" + strIn.Substring(0, strIn.Length - 1) + ");";

            // -------------------
            // STEP 3: 串成新的 sql
            // -------------------
            sql = sql + strIn;

            products = _db.Database.SqlQuery<ViewProduct>(sql, parameters.ToArray()).ToList();

            return products;
        }

        /// <summary>
        /// 傳入多個商品類別查詢產品, 以 Entity Framework 的 SqlQuery<T> 呼叫 stored procedure 進行處理
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public List<ViewProduct> GetProductsWithSpByEf(List<int> categories, string productName = "")
        {
            var result = new List<ViewProduct>();
            _db.Database.Log = Console.Write;       // Entity Framework 產生的 SQL 指令, 由 Console.Write 輸出

            //建立查詢條件的 DataTable (只包含 1 個 Column)
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("CategoryId", typeof(int)));
            DataRow row = null;
            foreach (var category in categories)
            {
                row = dt.NewRow();
                row["CategoryId"] = category;
                dt.Rows.Add(row);
            }

            //建立查詢參數
            var para1 = new SqlParameter("@tbl_Categories", SqlDbType.Structured) { Value = dt };
            var para2 = new SqlParameter("@pi_ProductName", SqlDbType.NVarChar, 30) { Value = productName };

            //設定 SqlDbType.Structured 那個參數對應的 User Defined Type
            para1.TypeName = "dbo.udt_CategoryId";
            result = _db.Database.SqlQuery<ViewProduct>("exec usp_GetProductsByCategories @tbl_Categories, @pi_ProductName", para1, para2).ToList();

            return result;
        }

        ///// <summary>
        ///// 傳入多個商品類別查詢產品, 以 Entity Framework 的 SqlQuery<T> 呼叫 stored procedure 進行處理
        ///// </summary>
        ///// <param name="categories"></param>
        ///// <param name="productName"></param>
        ///// <returns></returns>
        //public List<ViewProduct> GetProductsWithSpByEfExtras(List<int> categories, string productName = "")
        //{
        //    var result = new List<ViewProduct>();
        //    _db.Database.Log = Console.Write;       // Entity Framework 產生的 SQL 指令, 由 Console.Write 輸出

        //    //建立查詢條件的 DataTable (只包含 1 個 Column)
        //    DataTable dt = new DataTable("MyTable");
        //    dt.Columns.Add(new DataColumn("CategoryId", typeof(int)));
        //    DataRow row = null;
        //    foreach (var category in categories)
        //    {
        //        row = dt.NewRow();
        //        row["CategoryId"] = category;
        //        dt.Rows.Add(row);
        //    }

        //    //建立查詢參數
        //    var para1 = new SqlParameter("@tbl_Categories", SqlDbType.Structured) { Value = dt };
        //    var para2 = new SqlParameter("@pi_ProductName", SqlDbType.NVarChar, 30) { Value = productName };

        //    //設定 SqlDbType.Structured 那個參數對應的 User Defined Type
        //    para1.TypeName = "dbo.udt_CategoryId";
        //    result = _db.Database.SqlQuery<ViewProduct>("exec usp_GetProductsByCategories @tbl_Categories, @pi_ProductName", para1, para2).ToList();

        //    return result;
        //}

    }
}
