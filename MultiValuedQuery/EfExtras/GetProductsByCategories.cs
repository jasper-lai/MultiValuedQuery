using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;

namespace MultiValuedQuery.EfExtras
{

    /// <summary>
    /// Extras : STEP 1 : Define a stored procedure class
    /// </summary>
    /// <remarks>
    /// https://github.com/Fodsuk/EntityFrameworkExtras
    /// </remarks>
    [StoredProcedure("usp_GetProductsByCategories")]
    public class GetProductsByCategories
    {
        /// <summary>
        /// 多筆的產品類別代碼
        ///  </summary>
        /// <remarks>
        /// 必須定義 ParameterName, 以供 Extras.EF6 在呼叫時作對應
        /// </remarks>
        [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "tbl_Categories")]
        public List<udt_CategoryId> Categories { get; set; }

        /// <summary>
        /// 產品名稱
        /// </summary>
        /// <remarks>
        /// 必須定義 ParameterName, 以供 Extras.EF6 在呼叫時作對應
        /// </remarks>
        [StoredProcedureParameter(SqlDbType.NVarChar, ParameterName = "pi_ProductName")]
        public string ProductName { get; set; }
    }

    /// <summary>
    /// Extras : STEP 2 : Define the user defined data type
    /// </summary>
    /// <remarks>
    /// 必須指定該 Class, 是對應至那一個 User Defined Data Type;
    /// 如果有多個, 就要建立多個不同的 Class
    /// </remarks>
    [UserDefinedTableType("udt_CategoryId")]
    public class udt_CategoryId
    {
        [UserDefinedTableTypeColumn(1)]
        public int CategoryId { get; set; }
    }

}
