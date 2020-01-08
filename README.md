# MultiValuedQuery
## the sample program for multi-valued query
See [傑士伯的IT學習之路](https://jasper-it.blogspot.com/2020/01/c-how-to-query-with-table-valued.html) for details

目前的專案, 遇到需要傳多個值, 查出對應資料的需求, 例如: 傳入多個組織單位代號, 去取出對應的組織單位名稱; 或者傳入多個產品類別, 去取出對應的產品資料.

經上網查詢, 至少有以下4種解決方式.

* 方式一: 採用 LINQ 的 Contains 方法
* 方式二: 自行撰寫 WHERE IN 的 SQL 敘述
* 方式三: 採用 Stored Procedure, 自行傳入 Table-Valued Parameter
* 方式四: 採用 Stored Procedure, 利用 EntityFrameworkExtras.EF6, 傳入 Table-Valued Parameter

以下茲以 傳入多個產品類別, 去取出對應的產品資料 為例, 進行說明.
